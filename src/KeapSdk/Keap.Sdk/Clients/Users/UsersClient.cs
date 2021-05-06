using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using Keap.Sdk.Domain.Common;
using Keap.Sdk.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Users
{
    internal class UsersClient : IUsersClient
    {
        private readonly IRestApiClient apiClient;

        public UsersClient(Domain.IRestApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public EmailSignature GetUserEmailSignature(int userId)
        {
            var responseTask = GetUserEmailSignatureAsync(userId).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();
            return result;
        }

        public async Task<EmailSignature> GetUserEmailSignatureAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new Exceptions.KeapArgumentException(nameof(userId), "Value should be greater than 0.");
            }

            string path = $"users/{userId}/signature";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;

            EmailSignature result = null;

            // This does not match the standard JSON return format. A 200(OK) will have an HTML body
            // only which is the HTML snippet for the signature
            if (response.IsSuccessStatusCode)
            {
                result = new EmailSignature();
                result.HtmlSignature = response.ResponseBody;
            }

            return result;
        }

        public ResultPage<User> GetUsers(bool includeInactive = true, bool includePartners = true, int pageSize = 1000)
        {
            var responseTask = GetUsersAsync(includeInactive, includePartners, pageSize).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();
            return result;
        }

        public ResultPage<User> GetUsers(string nextPageToken)
        {
            var responseTask = GetUsersAsync(nextPageToken).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();
            return result;
        }

        public async Task<ResultPage<User>> GetUsersAsync(bool includeInactive = true, bool includePartners = true, int pageSize = 1000)
        {
            // Client side enforcement of limits
            return await GetUsersAsync(includeInactive, includePartners, pageSize, 0);
        }

        public async Task<ResultPage<User>> GetUsersAsync(string nextPageToken)
        {
            bool includeInactive = true;
            bool includePartners = true;
            int pageSize = 1000;
            int offset = 0;

            if (!string.IsNullOrWhiteSpace(nextPageToken))
            {
                var nvp = RestHelper.ConvertPageTokenToNameValueCollection(nextPageToken);

                if (nvp["limit"] != null)
                {
                    pageSize = int.Parse(nvp["limit"]);
                }

                if (nvp["offset"] != null)
                {
                    offset = int.Parse(nvp["offset"]);
                }

                if (nvp["include_partners"] != null)
                {
                    includePartners = bool.Parse(nvp["include_partners"]);
                }

                if (nvp["include_inactive"] != null)
                {
                    includeInactive = bool.Parse(nvp["include_inactive"]);
                }
            }

            return await GetUsersAsync(includeInactive, includePartners, pageSize, offset);
        }

        public User InviteUser(string email, string fullName, bool isAdmin, bool isPartner)
        {
            var responseTask = InviteUserAsync(email, fullName, isAdmin, isPartner).ConfigureAwait(false).GetAwaiter();
            var result = responseTask.GetResult();
            return result;
        }

        public async Task<User> InviteUserAsync(string email, string fullName, bool isAdmin, bool isPartner)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exceptions.KeapNullOrWhitespaceArgumentException(nameof(email));
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new Exceptions.KeapNullOrWhitespaceArgumentException(nameof(fullName));
            }

            string path = "users";

            var inviteUserDto = new Users.InviteUserDto
            {
                Email = email,
                GivenName = fullName,
                Admin = isAdmin,
                Partner = isPartner
            };

            var responseTask = apiClient.PostAsync(path, inviteUserDto);
            var response = await responseTask;
            // TODO: Currently if we hit the license limit, a 400 is returned which is difficult to discern from other 400s for missing email

            if (!response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.BadRequest && response.ResponseBody.Contains("licenses"))
            {
                var message = RestHelper.AttemptToGetErrorMessage(response);
                if (!String.IsNullOrWhiteSpace(message))
                {
                    throw new Exceptions.KeapLicenseException(message);
                }
            }
            var resultDto = Domain.Clients.RestHelper.ProcessResults<UserDto>(response);

            var result = resultDto.MapTo();

            return result;
        }

        private async Task<ResultPage<User>> GetUsersAsync(bool includeInactive, bool includePartners, int pageSize, int offset)
        {
            // Client side enforcement of limits
            if (pageSize <= 0 || pageSize > 1000)
            {
                pageSize = 1000;
            }

            string path = $"users?include_inactive={includeInactive}&include_partners={includePartners}&limit={pageSize}&offset={offset}";

            var responseTask = apiClient.GetAsync(path);
            var response = await responseTask;
            var resultDto = Domain.Clients.RestHelper.ProcessResults<UserListDto>(response);

            ResultPage<User> result = new ResultPage<User>();
            if (resultDto.Users != null && resultDto.Users.Length > 0)
            {
                result.NextPageToken = resultDto.GetNextPageToken($"include_inactive={includeInactive}&include_partners={includePartners}");

                foreach (var item in resultDto.Users)
                {
                    result.Items.Add(item.MapTo());
                }
            }

            return result;
        }
    }
}