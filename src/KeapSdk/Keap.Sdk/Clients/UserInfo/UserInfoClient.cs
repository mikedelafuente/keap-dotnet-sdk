using Keap.Sdk.Domain;
using Keap.Sdk.Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.UserInfo
{
    internal class UserInfoClient : Domain.IUserInfoClient

    {
        private readonly IRestApiClient apiClient;

        public UserInfoClient(Domain.IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public CurrentUser GetCurrentUser()
        {
            var responseTask = GetCurrentUserAsync().ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();

            return result;
        }

        public async Task<CurrentUser> GetCurrentUserAsync()
        {
            string path = "oauth/connect/userinfo";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<CurrentUserDto>(response);

            var result = resultDto.MapTo();

            return result;
        }
    }
}