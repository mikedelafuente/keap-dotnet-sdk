using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Common
{
    public class Address
    {
        /// <summary>
        ///  Can be BILLING, SHIPPING or OTHER
        /// </summary>
        [JsonPropertyName("county_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("field")]
        public AddressType Field { get; set; }

        [JsonPropertyName("line1")]
        public string Line1 { get; set; }

        [JsonPropertyName("line2")]
        public string Line2 { get; set; }

        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

        [JsonPropertyName("zip_four")]
        public string ZipFour { get; set; }
    }
}