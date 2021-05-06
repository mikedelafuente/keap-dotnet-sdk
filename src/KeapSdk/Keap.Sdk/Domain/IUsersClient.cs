using Keap.Sdk.Domain.Common;
using Keap.Sdk.Domain.Users;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IUsersClient
    {
        /// <summary>
        /// Retrieves a HTML snippet that contains the user's email signature.
        /// </summary>
        /// <param name="userId">ID of the user</param>
        /// <returns><see cref="EmailSignature"/> that contains the HTML snippet for the signature</returns>
        EmailSignature GetUserEmailSignature(int userId);

        /// <summary>
        /// Retrieves a HTML snippet that contains the user's email signature.
        /// </summary>
        /// <param name="userId">ID of the user</param>
        /// <returns><see cref="EmailSignature"/> that contains the HTML snippet for the signature</returns>
        Task<EmailSignature> GetUserEmailSignatureAsync(int userId);

        /// <summary>
        /// Retrieves the next page of users
        /// </summary>
        /// <param name="nextPageToken">The token returned by a previous request to get users</param>
        /// <returns>
        /// A page of users with a next page token. If there are no users returned, the next page
        /// token will be empty or null.
        /// </returns>
        ResultPage<Users.User> GetUsers(string nextPageToken);

        /// <summary>
        /// Retrieves a list of all users up to the specified page size
        /// </summary>
        /// <param name="includeInactive">If true, includes inactive users. Default is true.</param>
        /// <param name="includePartners">
        /// If true, includes users that are also partners. Default is true.
        /// </param>
        /// <param name="pageSize">
        /// Limit is 1000. Any value greater than 1000 or less than 0 will be set to 1000.
        /// </param>
        /// <returns>
        /// A page of users with a next page token. If there are no users returned, the next page
        /// token will be empty or null.
        /// </returns>
        ResultPage<Users.User> GetUsers(bool includeInactive = true, bool includePartners = true, int pageSize = 1000);

        /// <summary>
        /// Retrieves the next page of users
        /// </summary>
        /// <param name="nextPageToken">The token returned by a previous request to get users</param>
        /// <returns>
        /// A page of users with a next page token. If there are no users returned, the next page
        /// token will be empty or null.
        /// </returns>
        Task<ResultPage<Users.User>> GetUsersAsync(string nextPageToken);

        /// <summary>
        /// Retrieves a list of all users up to the specified page size
        /// </summary>
        /// <param name="includeInactive">If true, includes inactive users. Default is true.</param>
        /// <param name="includePartners">
        /// If true, includes users that are also partners. Default is true.
        /// </param>
        /// <param name="pageSize">
        /// Limit is 1000. Any value greater than 1000 or less than 0 will be set to 1000.
        /// </param>
        /// <returns>
        /// A page of users with a next page token. If there are no users returned, the next page
        /// token will be empty or null.
        /// </returns>
        Task<ResultPage<Users.User>> GetUsersAsync(bool includeInactive = true, bool includePartners = true, int pageSize = 1000);
    }
}