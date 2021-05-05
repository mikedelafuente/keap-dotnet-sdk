using Keap.Sdk.Domain.Common;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IUsersClient
    {
        ResultPage<Users.User> GetUsers(string nextPageToken);

        ResultPage<Users.User> GetUsers(bool includeInactive = true, bool includePartners = true, int pageSize = 1000);

        Task<ResultPage<Users.User>> GetUsersAsync(string nextPageToken);

        Task<ResultPage<Users.User>> GetUsersAsync(bool includeInactive = true, bool includePartners = true, int pageSize = 1000);
    }
}