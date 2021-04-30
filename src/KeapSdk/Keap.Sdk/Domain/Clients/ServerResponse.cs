using System.Net.Http;
using System.Text.Json;

namespace Keap.Sdk.Domain.Clients
{
    public class ServerResponse
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }

        public string ResponseBody { get; set; }
        public string ReasonPhrase { get; internal set; }

        bool? isSuccessStatusCode = null;

        public bool IsSuccessStatusCode
        {
            get
            {
                // If the value was explicitly set, use that value otherwise parse for 2xx codes
                if (isSuccessStatusCode.HasValue)
                {
                    return isSuccessStatusCode.Value;
                }
                else
                {
                    int statusCode = (int)StatusCode;
                    return statusCode >= 200 && statusCode < 300;
                }
            }
            internal set { isSuccessStatusCode = value; }
        }
    }
}