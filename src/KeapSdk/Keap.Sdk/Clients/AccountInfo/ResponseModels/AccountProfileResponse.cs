using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.AccountInfo.ResponseModels
{
    internal class AccountProfileResponse
    {
        [JsonPropertyName("address")]
        public Common.ResponseModels.AddressResponse Address { get; set; }

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

        internal static AccountProfileResponse MapFrom(Domain.Account.AccountProfile value)
        {
            AccountProfileResponse result = new AccountProfileResponse();
            result.Address = Common.ResponseModels.AddressResponse.MapFrom(value.Address);
            result.BusinessGoals = value.BusinessGoals.GetClone();
            result.BusinessPrimaryColor = value.BusinessPrimaryColor;
            result.BusinessSecondaryColor = value.BusinessSecondaryColor;
            result.BusinessType = value.BusinessType;
            result.CurrencyCode = value.CurrencyCode;
            result.Email = value.Email;
            result.LanguageTag = value.LanguageTag;
            result.LogoUrl = value.LogoUrl;
            result.Name = value.Name;
            result.Phone = value.Phone;
            result.PhoneExt = value.PhoneExt;
            result.TimeZone = value.TimeZone;
            result.Website = value.Website;
            return result;
        }

        internal Domain.Account.AccountProfile MapTo()
        {
            Domain.Account.AccountProfile result = new Domain.Account.AccountProfile();
            result.Address = this.Address.MapTo();
            result.BusinessGoals = this.BusinessGoals.GetClone();
            result.BusinessPrimaryColor = this.BusinessPrimaryColor;
            result.BusinessSecondaryColor = this.BusinessSecondaryColor;
            result.BusinessType = this.BusinessType;
            result.CurrencyCode = this.CurrencyCode;
            result.Email = this.Email;
            result.LanguageTag = this.LanguageTag;
            result.LogoUrl = this.LogoUrl;
            result.Name = this.Name;
            result.Phone = this.Phone;
            result.PhoneExt = this.PhoneExt;
            result.TimeZone = this.TimeZone;
            result.Website = this.Website;
            return result;
        }
    }
}