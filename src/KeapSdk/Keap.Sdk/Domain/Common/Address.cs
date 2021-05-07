using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Common
{
    // TODO: Add comments to properties and class
    public class Address
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Can be BILLING, SHIPPING or OTHER
        /// </summary>
        [JsonProperty("field")]
        public AddressType Field { get; set; }

        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Field used to store postal codes containing a combination of letters and numbers ex.
        /// 'EC1A', 'S1 2HE', '75000'
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Mainly used in the United States, this is typically numeric. ex. '85001', '90002' Note:
        /// this is to be used instead of 'postal_code', not in addition to.
        /// </summary>
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Last four of a full zip code ex. '8244', '4320'. This field is supplemental to the
        /// zip_code field, otherwise will be ignored.
        /// </summary>
        [JsonProperty("zip_four")]
        public string ZipFour { get; set; }
    }
}