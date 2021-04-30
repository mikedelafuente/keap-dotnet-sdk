using Keap.Sdk.Domain;
using System;

namespace Keap.Sdk
{
    public class Authentication
    {
        public static KeapClient GetClientUsingOAuth2(string integrationName, string clientId, string clientSecret, string baseUrl, IRestClient restClient = null)
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

            if (restClient == null)
            {
                AccessToken token = new AccessToken(integrationName, clientId, clientSecret, baseUrl);

                // TODO: trigger opening a 
                restClient = new RestClient(null);
            }
            
            return new KeapClient(restClient);
        }
    }
}
