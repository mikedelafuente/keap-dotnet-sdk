using Keap.Sdk.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IAccountInfoClient
    {
        /// <summary>
        /// Retrieves profile/company info for an account.
        /// </summary>
        /// <returns>The account profile for the current app.</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>

        public Account.AccountProfile GetAccountProfile();

        /// <summary>
        /// Retrieves profile/company info for an account.
        /// </summary>
        /// <returns>The account profile for the current app.</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        public Task<Account.AccountProfile> GetAccountProfileAsync();

        /// <summary>
        /// Updates profile/company info for an account.
        /// </summary>
        /// <returns>The updated account profile for the current app.</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        AccountProfile UpdateAccountProfile(AccountProfile updatedAccountProfile);

        /// <summary>
        /// Updates profile/company info for an account.
        /// </summary>
        /// <returns>The updated account profile for the current app.</returns>
        /// <exception cref="Keap.Sdk.Exceptions.KeapException"></exception>
        Task<AccountProfile> UpdateAccountProfileAsync(AccountProfile updatedAccountProfile);
    }
}