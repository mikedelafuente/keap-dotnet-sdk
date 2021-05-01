using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using System;

namespace Keap.Sdk
{
    public delegate AccessTokenCredentials OAuth2BrowserHandler(string redirectUri);

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

            if (apiClient == null)
            {
                // TODO: Get the access token
                // TODO: trigger opening a browser or raise an event to make this happen or take in delegates as an argument

                string browserDelegateRedirectUri = $"{authorizationRequestUrl}?client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope=full";
                AccessTokenCredentials token = browserDelegate(browserDelegateRedirectUri);

                apiClient = new ApiClient(token);
            }

            return new KeapClient(apiClient);
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