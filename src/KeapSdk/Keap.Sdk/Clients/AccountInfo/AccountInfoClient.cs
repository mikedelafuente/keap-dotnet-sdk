using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Account;
using System;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.AccountInfo
{
    internal class AccountInfoClient : Domain.IAccountInfoClient
    {
        private readonly IRestApiClient apiClient;

        public AccountInfoClient(Domain.IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public AccountProfile GetAccountProfile()
        {
            var responseTask = GetAccountProfileAsync().ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<AccountProfile> GetAccountProfileAsync()
        {
            string path = "account/profile";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<AccountProfileDto>(response);

            var result = resultDto.MapTo();

            return result;
        }

        public AccountProfile UpdateAccountProfile(AccountProfile updatedAccountProfile)
        {
            var responseTask = UpdateAccountProfileAsync(updatedAccountProfile).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<AccountProfile> UpdateAccountProfileAsync(AccountProfile updatedAccountProfile)
        {
            string path = "account/profile";

            var requestDto = AccountProfileDto.MapFrom(updatedAccountProfile);
            var responseTask = apiClient.PutAsync(path, requestDto);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<AccountProfileDto>(response);

            var result = resultDto.MapTo();

            return result;
        }
    }
}