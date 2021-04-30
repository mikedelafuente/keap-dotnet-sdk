using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;

namespace Keap.Sdk
{
    public class Authentication
    {
        public static KeapClient GetClientUsingOAuth2(string integrationName, string clientId, string clientSecret, string baseUrl, IApiClient apiClient = null)
        {
            if (string.IsNullOrWhiteSpace(integrationName))
            {
                throw new Common.KeapArgumentException(nameof(integrationName));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new Common.KeapArgumentException(nameof(clientSecret));
            }

            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new Common.KeapArgumentException(nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new Common.KeapArgumentException(nameof(baseUrl));
            }

            if (apiClient == null)
            {
                ApiCredentials credentials = new ApiCredentials(integrationName, clientId, clientSecret, baseUrl);

                // TODO: Get the access token
                // TODO: trigger opening a browser or raise an event to make this happen or take in delegates as an argument
                AccessToken token = null;

                apiClient = new ApiClient(credentials, token);
            }

            return new KeapClient(apiClient);
        }
    }
}