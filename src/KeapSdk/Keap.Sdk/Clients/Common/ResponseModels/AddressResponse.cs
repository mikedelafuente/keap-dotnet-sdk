﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Common.ResponseModels
{
    internal class AddressResponse
    {
        public AddressResponse()
        {
        }

        /// <summary>
        /// Can be BILLING, SHIPPING or OTHER
        /// </summary>
        [JsonPropertyName("county_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("field")]
        public string Field { get; set; }

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

        internal static AddressResponse MapFrom(Domain.Common.Address value)
        {
            AddressResponse result = new AddressResponse();
            result.CountryCode = value.CountryCode;
            result.Field = value.Field.ToString();
            result.Line1 = value.Line1;
            result.Line2 = value.Line2;
            result.Locality = value.Locality;
            result.PostalCode = value.PostalCode;
            result.Region = value.Region;
            result.ZipCode = value.ZipCode;
            result.ZipFour = value.ZipFour;
            return result;
        }

        internal Domain.Common.Address MapTo()
        {
            Domain.Common.Address result = new Domain.Common.Address();
            result.CountryCode = this.CountryCode;
            result.Field = Enum.Parse<Domain.Common.AddressType>(this.Field, true);
            result.Line1 = this.Line1;
            result.Line2 = this.Line2;
            result.Locality = this.Locality;
            result.PostalCode = this.PostalCode;
            result.Region = this.Region;
            result.ZipCode = this.ZipCode;
            result.ZipFour = this.ZipFour;
            return result;
        }
    }
}