using Keap.Sdk.Clients.Common;
using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Contacts
{
    internal class ContactPutPostDto
    {
        [JsonProperty("addresses")]
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();

        [JsonProperty("anniversary")]
        public DateTimeOffset Anniversary { get; set; }

        [JsonProperty("birthday")]
        public DateTimeOffset Birthday { get; set; }

        [JsonProperty("company")]
        public CompanyPutPostDto Company { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("custom_fields")]
        public List<CustomFieldDto> CustomFields { get; set; } = new List<CustomFieldDto>();

        [JsonProperty("email_addresses")]
        public List<EmailAddressPutPostDto> EmailAddresses { get; set; } = new List<EmailAddressPutPostDto>();

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("fax_numbers")]
        public List<FaxNumberDto> FaxNumbers { get; set; } = new List<FaxNumberDto>();

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("lead_source_id")]
        public long LeadSourceId { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("opt_in_reason")]
        public string OptInReason { get; set; }

        [JsonProperty("origin")]
        public IpOriginPutPostDto Origin { get; set; }

        [JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
        public long OwnerId { get; set; }

        [JsonProperty("phone_numbers")]
        public List<PhoneNumberDto> PhoneNumbers { get; set; } = new List<PhoneNumberDto>();

        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("preferred_name")]
        public string PreferredName { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("social_accounts")]
        public List<SocialAccountDto> SocialAccounts { get; set; } = new List<SocialAccountDto>();

        [JsonProperty("source_type")]
        public string SourceType { get; set; }

        [JsonProperty("spouse_name")]
        public string SpouseName { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        internal static ContactPutPostDto MapFrom(Contact source)
        {
            if (source == null)
            {
                return null;
            }

            ContactPutPostDto r = new ContactPutPostDto();
            foreach (var item in source.Addresses)
            {
                r.Addresses.Add(AddressDto.MapFrom(item));
            }
            r.Anniversary = source.Anniversary;
            r.Birthday = source.Birthday;
            r.Company = CompanyPutPostDto.MapFrom(source.Company);
            r.ContactType = source.ContactType;
            if (source.CustomFields != null)
            {
                r.CustomFields.AddRange(source.CustomFields.Select(item => CustomFieldDto.MapFrom(item)));
            }

            if (source.EmailAddresses != null)
            {
                r.EmailAddresses.AddRange(source.EmailAddresses.Select(item => EmailAddressPutPostDto.MapFrom(item)));
            }
            r.FamilyName = source.FamilyName;
            if (source.FaxNumbers != null)
            {
                r.FaxNumbers.AddRange(source.FaxNumbers.Select(item => FaxNumberDto.MapFrom(item)));
            }
            r.GivenName = source.GivenName;
            r.JobTitle = source.JobTitle;
            r.LeadSourceId = source.LeadSourceId;
            r.MiddleName = source.MiddleName;
            r.OptInReason = source.OptInReason;
            r.Origin = IpOriginPutPostDto.MapFrom(source.Origin);
            r.OwnerId = source.OwnerId;
            if (source.PhoneNumbers != null)
            {
                r.PhoneNumbers.AddRange(source.PhoneNumbers.Select(item => PhoneNumberDto.MapFrom(item)));
            }

            r.PreferredLocale = source.PreferredLocale;
            r.PreferredName = source.PreferredName;
            r.Prefix = source.Prefix;
            if (source.SocialAccounts != null)
            {
                r.SocialAccounts.AddRange(source.SocialAccounts.Select(item => SocialAccountDto.MapFrom(item)));
            }
            r.SourceType = source.SourceType;
            r.SpouseName = source.SpouseName;
            r.Suffix = source.Suffix;
            r.TimeZone = source.TimeZone;
            r.Website = source.Website;
            return r;
        }
    }
}