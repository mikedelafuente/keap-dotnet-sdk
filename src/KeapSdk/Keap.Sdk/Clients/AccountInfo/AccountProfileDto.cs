using Keap.Sdk.Clients.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.AccountInfo
{
    internal class AccountProfileDto
    {

        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }

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

        internal static AccountProfileDto MapFrom(Domain.Account.AccountProfile value)
        {
            AccountProfileDto result = new AccountProfileDto();
            result.Address = AddressDto.MapFrom(value.Address);
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
            result.Address = Address.MapTo();
            result.BusinessGoals = BusinessGoals.GetClone();
            result.BusinessPrimaryColor = BusinessPrimaryColor;
            result.BusinessSecondaryColor = BusinessSecondaryColor;
            result.BusinessType = BusinessType;
            result.CurrencyCode = CurrencyCode;
            result.Email = Email;
            result.LanguageTag = LanguageTag;
            result.LogoUrl = LogoUrl;
            result.Name = Name;
            result.Phone = Phone;
            result.PhoneExt = PhoneExt;
            result.TimeZone = TimeZone;
            result.Website = Website;
            return result;
        }
    }
}