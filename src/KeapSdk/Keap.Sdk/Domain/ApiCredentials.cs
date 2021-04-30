using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public class ApiCredentials
    {
        public ApiCredentials(string integrationName, string clientId, string clientSecret, string baseUrl)
        {
            IntegrationName = integrationName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            BaseUrl = baseUrl;
        }

        public string IntegrationName { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string BaseUrl { get; }
    }
}
