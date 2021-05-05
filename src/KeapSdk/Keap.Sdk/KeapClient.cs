using Keap.Sdk.Domain;

namespace Keap.Sdk
{
    /// <summary>
    /// The Client for the Keap API
    /// </summary>
    internal class KeapClient : IKeapClient
    {
        internal KeapClient(IRestApiClient apiClient)
        {
            if (apiClient == null)
            {
                throw new Exceptions.KeapArgumentException(nameof(apiClient));
            }

            ApiClient = apiClient;
            AccountInfo = new Clients.AccountInfo.AccountInfoClient(ApiClient);
            Locale = new Clients.Locale.LocaleClient(ApiClient);
            UserInfo = new Clients.UserInfo.UserInfoClient(ApiClient);
        }

        public IAccountInfoClient AccountInfo { get; }

        public ILocaleClient Locale { get; }

        public IUserInfoClient UserInfo { get; }

        internal IRestApiClient ApiClient { get; }
    }
}