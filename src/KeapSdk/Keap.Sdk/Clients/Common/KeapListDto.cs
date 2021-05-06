using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Keap.Sdk.Clients.Common
{
    internal abstract class KeapListDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        public string GetNextPageToken(string additionalParameters = null)
        {
            // TODO: parse the string from the "Next" item and grab out the limit and offset
            //"next": "https://api.infusionsoft.com/crm/rest/v1/users/?limit=1&offset=1000",
            string toEncode = string.Empty;
            if (this.Next.Contains("?") && this.Next.StartsWith("http"))
            {
                Uri link = new Uri(this.Next);
                var originalParts = HttpUtility.ParseQueryString(CleanupQueryString(link.Query));

                // Only add
                if (!string.IsNullOrWhiteSpace(additionalParameters))
                {
                    var additionalParts = HttpUtility.ParseQueryString(CleanupQueryString(additionalParameters));
                    originalParts.Add(additionalParts);
                }

                toEncode = originalParts.ToString();
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));
        }

        /// <summary>
        /// Removes any leading question mark or trailing ampersand
        /// </summary>
        /// <param name="value">Value to cleanup</param>
        /// <returns></returns>
        private static string CleanupQueryString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (value.StartsWith("?"))
            {
                if (value.Length > 1)
                {
                    // Changes '?param1=val1&param2=val2&' to 'param1=val1&param2=val2&'
                    value = value.Substring(1);
                }
                else
                {
                    // Changes '?' to ''
                    value = string.Empty;
                }
            }

            if (value.EndsWith("&"))
            {
                // Changes 'param1=val1&param2=val2&' to 'param1=val1&param2=val2&'
                if (value.Length > 1)
                {
                    value = value.Substring(0, value.Length - 1);
                }
                else
                {
                    // Changes '&' to ''
                    value = string.Empty;
                }
            }

            return value;
        }
    }
}