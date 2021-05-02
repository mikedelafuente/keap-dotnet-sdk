using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain
{
    public interface IAccountInfoClient
    {
        public Account.AccountProfile GetAccountProfile();

        public Task<Account.AccountProfile> GetAccountProfileAsync();
    }
}