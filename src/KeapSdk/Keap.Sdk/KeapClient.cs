using Keap.Sdk.Domain.Clients;

namespace Keap.Sdk
{
    /// <summary>
    /// The Client for the Keap API
    /// </summary>
    public class KeapClient
    {
        internal KeapClient(IApiClient apiClient)
        {
            if (apiClient == null)
            {
                throw new Exceptions.KeapArgumentException(nameof(apiClient));
            }

            ApiClient = apiClient;
        }

        public IApiClient ApiClient { get; }
    }
}