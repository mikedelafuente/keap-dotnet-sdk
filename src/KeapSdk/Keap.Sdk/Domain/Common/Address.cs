using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Common
{
    // TODO: Add comments to properties and class
    public class Address
    {
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Can be BILLING, SHIPPING or OTHER
        /// </summary>
        [JsonPropertyName("field")]
        public AddressType Field { get; set; }

        [JsonPropertyName("line1")]
        public string Line1 { get; set; }

        [JsonPropertyName("line2")]
        public string Line2 { get; set; }

        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Field used to store postal codes containing a combination of letters and numbers ex.
        /// 'EC1A', 'S1 2HE', '75000'
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Mainly used in the United States, this is typically numeric. ex. '85001', '90002' Note:
        /// this is to be used instead of 'postal_code', not in addition to.
        /// </summary>
        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Last four of a full zip code ex. '8244', '4320'. This field is supplemental to the
        /// zip_code field, otherwise will be ignored.
        /// </summary>
        [JsonPropertyName("zip_four")]
        public string ZipFour { get; set; }
    }
}