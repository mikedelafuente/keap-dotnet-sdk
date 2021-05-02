using Keap.Sdk.Domain;

namespace Keap.Sdk
{
    /// <summary>
    /// The Client for the Keap API
    /// </summary>
    public class KeapClient
    {
        internal KeapClient(IRestApiClient apiClient)
        {
            if (apiClient == null)
            {
                throw new Exceptions.KeapArgumentException(nameof(apiClient));
            }

            ApiClient = apiClient;
            AccountInfo = new Clients.AccountInfo.AccountInfoClient(ApiClient);
        }

        public IAccountInfoClient AccountInfo { get; }

        internal IRestApiClient ApiClient { get; }
    }
}