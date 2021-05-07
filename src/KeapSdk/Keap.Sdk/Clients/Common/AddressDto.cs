using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Common
{
    internal class AddressDto
    {
        public AddressDto()
        {
        }

        /// <summary>
        /// Can be BILLING, SHIPPING or OTHER
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("zip_four")]
        public string ZipFour { get; set; }

        internal static AddressDto MapFrom(Domain.Common.Address source)
        {
            if (source == null)
            {
                return null;
            }

            AddressDto result = new AddressDto();
            result.CountryCode = source.CountryCode;
            result.Field = source.Field.ToString();
            result.Line1 = source.Line1;
            result.Line2 = source.Line2;
            result.Locality = source.Locality;
            result.PostalCode = source.PostalCode;
            result.Region = source.Region;
            result.ZipCode = source.ZipCode;
            result.ZipFour = source.ZipFour;
            return result;
        }

        internal Domain.Common.Address MapTo()
        {
            Domain.Common.Address result = new Domain.Common.Address();
            result.CountryCode = CountryCode;
            result.Field = Enum.Parse<Domain.Common.AddressType>(Field, true);
            result.Line1 = Line1;
            result.Line2 = Line2;
            result.Locality = Locality;
            result.PostalCode = PostalCode;
            result.Region = Region;
            result.ZipCode = ZipCode;
            result.ZipFour = ZipFour;
            return result;
        }
    }
}