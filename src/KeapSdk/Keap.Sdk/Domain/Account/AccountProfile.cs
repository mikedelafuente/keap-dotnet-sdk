using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Account
{
    public class AccountProfile
    {
        [JsonPropertyName("address")]
        public Common.Address Address { get; set; }

        [JsonPropertyName("business_goals")]
        public List<string> BusinessGoals { get; set; }

        [JsonPropertyName("business_primary_color")]
        public string BusinessPrimaryColor { get; set; }

        [JsonPropertyName("business_secondary_color")]
        public string BusinessSecondaryColor { get; set; }

        [JsonPropertyName("business_type")]
        public string BusinessType { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("language_tag")]
        public string LanguageTag { get; set; }

        [JsonPropertyName("logo_url")]
        public string LogoUrl { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phone_ext")]
        public string PhoneExt { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }
    }
}