using Keap.Sdk.Domain.Clients;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Web;

namespace Keap.Sdk.Clients.Common
{
    internal abstract class KeapListDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        public string GetNextPageToken(string additionalParameters = null)
        {
            // TODO: parse the string from the "Next" item and grab out the limit and offset
            //"next": "https://api.infusionsoft.com/crm/rest/v1/users/?limit=1&offset=1000",
            string toEncode = string.Empty;
            if (this.Next.Contains("?") && this.Next.StartsWith("http"))
            {
                Uri link = new Uri(this.Next);
                var originalParts = HttpUtility.ParseQueryString(RestHelper.CleanupQueryString(link.Query));

                // Only add
                if (!string.IsNullOrWhiteSpace(additionalParameters))
                {
                    var additionalParts = HttpUtility.ParseQueryString(RestHelper.CleanupQueryString(additionalParameters));
                    originalParts.Add(additionalParts);
                }

                toEncode = originalParts.ToString();
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));
        }
    }
}