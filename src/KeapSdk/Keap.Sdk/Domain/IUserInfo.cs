using Keap.Sdk.Domain.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IUserInfoClient
    {
        /// <summary>
        /// Retrieves information for the current authenticated end-user, as outlined by the OpenID
        /// Connect specification.
        /// </summary>
        /// <returns></returns>
        CurrentUser GetCurrentUser();

        /// <summary>
        /// Retrieves information for the current authenticated end-user, as outlined by the OpenID
        /// Connect specification.
        /// </summary>
        /// <returns></returns>
        Task<CurrentUser> GetCurrentUserAsync();
    }
}