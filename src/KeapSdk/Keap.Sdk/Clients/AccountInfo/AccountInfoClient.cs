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
            var resultDto = Domain.Clients.RestHelper.ProcessResults<ResponseModels.AccountProfileResponse>(response);

            var result = resultDto.MapTo();

            return result;
        }
    }
}