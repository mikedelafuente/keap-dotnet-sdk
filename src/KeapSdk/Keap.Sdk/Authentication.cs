using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using System;

namespace Keap.Sdk
{
    public delegate AccessTokenCredentials OAuth2BrowserHandler(string integrationName, string clientId, string clientSecret, string baseUrl);

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
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="baseUrl">The base URL.</param>
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
        public static KeapClient GetClientUsingOAuth2(string integrationName, string clientId, string clientSecret, string baseUrl, OAuth2BrowserHandler browserDelegate, IApiClient apiClient = null)
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

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new Exceptions.KeapArgumentException(nameof(baseUrl));
            }

            if (apiClient == null)
            {
                // TODO: Get the access token
                // TODO: trigger opening a browser or raise an event to make this happen or take in delegates as an argument
                AccessTokenCredentials token = browserDelegate(integrationName, clientSecret, clientSecret, baseUrl);

                apiClient = new ApiClient(token);
            }

            return new KeapClient(apiClient);
        }
    }
}