using Keap.Sdk.Clients.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keap.Sdk.Clients.AccountInfo
{
    internal class AccountProfileDto
    {
        [JsonProperty("address")]
        public AddressDto Address { get; set; }

        [JsonProperty("business_goals")]
        public List<string> BusinessGoals { get; set; }

        [JsonProperty("business_primary_color")]
        public string BusinessPrimaryColor { get; set; }

        [JsonProperty("business_secondary_color")]
        public string BusinessSecondaryColor { get; set; }

        [JsonProperty("business_type")]
        public string BusinessType { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("language_tag")]
        public string LanguageTag { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("phone_ext")]
        public string PhoneExt { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        internal static AccountProfileDto MapFrom(Domain.Account.AccountProfile source)
        {
            if (source == null)
            {
                return null;
            }

            AccountProfileDto result = new AccountProfileDto();
            result.Address = AddressDto.MapFrom(source.Address);
            result.BusinessGoals = source.BusinessGoals.GetClone();
            result.BusinessPrimaryColor = source.BusinessPrimaryColor;
            result.BusinessSecondaryColor = source.BusinessSecondaryColor;
            result.BusinessType = source.BusinessType;
            result.CurrencyCode = source.CurrencyCode;
            result.Email = source.Email;
            result.LanguageTag = source.LanguageTag;
            result.LogoUrl = source.LogoUrl;
            result.Name = source.Name;
            result.Phone = source.Phone;
            result.PhoneExt = source.PhoneExt;
            result.TimeZone = source.TimeZone;
            result.Website = source.Website;
            return result;
        }

        internal Domain.Account.AccountProfile MapTo()
        {
            Domain.Account.AccountProfile result = new Domain.Account.AccountProfile();
            result.Address = Address?.MapTo();
            result.BusinessGoals = BusinessGoals?.GetClone();
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