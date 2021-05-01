using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Keap.Sdk
{
    /// <summary>
    /// As the developer, you are responsible to redirect the user's browser to a URL that will then return the code for use by the SDK.
    /// </summary>
    /// <param name="authorizationUri">The URI to redirect a user's browser to</param>
    /// <returns>The 'Code' found in the redirect uri once the user has approved the integration.</returns>
    public delegate string OAuth2BrowserHandler(string authorizationUri);

    /// <summary>
    /// Start here. This is used to get a <see cref="KeapClient"/> which allows you to make calls to the Keap API
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Gets the client using access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiClient">Optional. Used for mocking out HTTP calls for unit testing.</param>
        /// <returns></returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapArgumentException">A null accessToken was passed in</exception>
        /// <exception cref="Keap.Sdk.Exceptions.KeapInvalidTokenException">The access token is invalid. Please re-authorize and get a new token.</exception>
        public static KeapClient GetClientUsingAccessToken(AccessTokenCredentials accessToken, IApiClient apiClient = null)
        {
            if (accessToken == null)
            {
                throw new Exceptions.KeapArgumentException(nameof(accessToken));
            }

            if (!accessToken.IsValid())
            {
                throw new Exceptions.KeapInvalidTokenException("The access token is invalid. Please re-authorize and get a new token.");
            }

            if (apiClient == null)
            {
                // TODO: Get the access token
                // TODO: trigger opening a browser or raise an event to make this happen or take in delegates as an argument

                apiClient = new ApiClient(accessToken);
            }

            return new KeapClient(apiClient);
        }

        /// <summary>
        /// Gets the client using o auth2.
        /// </summary>
        /// <param name="integrationName">Name of the integration.</param>
        /// <param name="clientId">Application client ID. Found in the developer portal.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="redirectUri">This is the callback URL that Keap will redirect the users back to after authorization(must be HTTPS). Users will not be redirect to any other URLs during the authentication process so it is important to use the site that users can visit and has a script to capture the authorization code.</param>
        /// <param name="apiClient">The API client.</param>
        /// <returns></returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapArgumentException">
        /// Null or white space for integrationName
        /// or
        /// Null or white space for clientSecret
        /// or
        /// Null or white space for clientId
        /// or
        /// Null or white space for baseUrl
        /// </exception>
        public static KeapClient GetClientUsingOAuth2(string integrationName,
                string clientId,
                string clientSecret,
                string redirectUri,
                OAuth2BrowserHandler browserDelegate,
                string authorizationRequestUrl = "https://accounts.infusionsoft.com/app/oauth/authorize",
                string accessTokenRequestUrl = "https://api.infusionsoft.com/token",
                string refreshTokenRequestUrl = "https://api.infusionsoft.com/token",
                string restApiUrl = "https://api.infusionsoft.com/crm/rest/v1",
                string xmlRpcApiUrl = "https://api.infusionsoft.com/crm/xmlrpc/v1",
                IApiClient apiClient = null)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(integrationName))
            {
                throw new Exceptions.KeapArgumentException(nameof(integrationName));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new Exceptions.KeapArgumentException(nameof(clientSecret));
            }

            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new Exceptions.KeapArgumentException(nameof(clientId));
            }

            ValidateUrlWithThrow(nameof(authorizationRequestUrl), authorizationRequestUrl);
            ValidateUrlWithThrow(nameof(accessTokenRequestUrl), accessTokenRequestUrl);
            ValidateUrlWithThrow(nameof(refreshTokenRequestUrl), refreshTokenRequestUrl);
            ValidateUrlWithThrow(nameof(restApiUrl), restApiUrl);
            ValidateUrlWithThrow(nameof(xmlRpcApiUrl), xmlRpcApiUrl);

            // if a client wasn't injected or if we are missing access token credentials, we need to get them
            if (apiClient == null || apiClient.AccessTokenCredentials == null)
            {
                // Create the url to redirect the user's browser to
                string browserDelegateRedirectUri = $"{authorizationRequestUrl}?client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope=full";

                // Call the delegate
                string code = browserDelegate(browserDelegateRedirectUri);

                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exceptions.KeapInvalidOAuth2CodeException("Invalid code was returned from the delegate. Have the Keap user grant access again.");
                }

                var accessTokenCredentials = GetAccessToken(code, redirectUri, accessTokenRequestUrl, clientId, clientSecret, integrationName, restApiUrl, xmlRpcApiUrl);

                if (accessTokenCredentials == null || !accessTokenCredentials.IsValid())
                {
                    throw new Exceptions.KeapArgumentException(nameof(accessTokenCredentials), "Invalid token was returned from the access token endpoint."); ;
                }

                if (apiClient == null)
                {
                    apiClient = new ApiClient(accessTokenCredentials);
                }
                else
                {
                    // IF we remove this, then we should set the AccessTokenCredentials back to read-only on the interface.
                    apiClient.AccessTokenCredentials = accessTokenCredentials;
                }
            }

            return new KeapClient(apiClient);
        }

        private static AccessTokenCredentials GetAccessToken(string code, string originalRedirectUri, string accessTokenRequestUrl, string clientId, string clientSecret, string integrationName, string restApiUrl, string xmlRpcUrl)
        {
            HttpResponseMessage httpResponse;
            DateTime createTime;
            // POST the code to the token endpoint
            using (HttpClient httpClient = new HttpClient())
            {
                var requestBody = new Dictionary<string, string>();
                requestBody.Add("client_id", clientId);
                requestBody.Add("client_secret", clientSecret);
                requestBody.Add("grant_type", "authorization_code");
                requestBody.Add("redirect_uri", originalRedirectUri);
                requestBody.Add("code", code);

                var content = new FormUrlEncodedContent(requestBody);
                createTime = DateTime.UtcNow;
                var postTask = httpClient.PostAsync(accessTokenRequestUrl, content).ConfigureAwait(false).GetAwaiter();
                httpResponse = postTask.GetResult();
            }

            // Parse the response
            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exceptions.KeapHttpRequestException("Unable to convert the OAuth2 code into an access token. Please try again.", new HttpRequestException(httpResponse.ReasonPhrase));
            }

            var responseContentTask = httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
            var responseContent = responseContentTask.GetResult();

            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var accessTokenResponse = JsonSerializer.Deserialize<Domain.Clients.Authentication.AccessTokenResponse>(responseContent, options);

            AccessTokenCredentials credentials = new AccessTokenCredentials(integrationName, clientId, clientSecret, restApiUrl, xmlRpcUrl, createTime, accessTokenResponse);
            return credentials;
        }

        private static void ValidateUrlWithThrow(string nameOfParam, string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new Exceptions.KeapArgumentException(nameOfParam);
            }

            if (!url.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exceptions.KeapArgumentException(nameOfParam, "Expected the uri to start with 'http'");
            }
        }
    }
}