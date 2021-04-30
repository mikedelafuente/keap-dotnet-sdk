using Keap.Sdk.Common;
using Keap.Sdk.Domain;
using Keap.Sdk.Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk
{
    /// <summary>
    /// The Client for the Keap API
    /// </summary>
    public class KeapClient
    {
        
        internal KeapClient(IApiClient apiClient)
        {
            if (apiClient == null)
            {
                throw new KeapArgumentException(nameof(apiClient));
            }

            ApiClient = apiClient;
        }

        public IApiClient ApiClient { get; }
    }
}
