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

        public string BaseUrl { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string IntegrationName { get; }
    }
}