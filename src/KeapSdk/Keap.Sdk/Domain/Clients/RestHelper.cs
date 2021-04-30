using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Clients
{
    internal static class RestHelper
    {
        internal static T ProcessResults<T>(ServerResponse serverResponse)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            if (serverResponse.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<T>(serverResponse.ResponseBody, options);
                return result;
            }

            // TODO: Make the return type nullable 
            //return default(T);
            throw new HttpRequestException(serverResponse.ReasonPhrase, null, serverResponse.StatusCode);

        }
    }
}
