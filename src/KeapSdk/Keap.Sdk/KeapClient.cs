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
            Contacts = new Clients.Contacts.ContactsClient(ApiClient);
            Locale = new Clients.Locale.LocaleClient(ApiClient);
            UserInfo = new Clients.UserInfo.UserInfoClient(ApiClient);
            Users = new Clients.Users.UsersClient(ApiClient);
        }

        public IAccountInfoClient AccountInfo { get; }
        public IContactsClient Contacts { get; }
        public ILocaleClient Locale { get; }
        public IUserInfoClient UserInfo { get; }
        public IUsersClient Users { get; }
        internal IRestApiClient ApiClient { get; }
    }
}