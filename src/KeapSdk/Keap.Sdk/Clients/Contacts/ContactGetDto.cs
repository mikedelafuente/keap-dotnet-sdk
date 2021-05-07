using Keap.Sdk.Clients.Common;
using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Keap.Sdk.Clients.Contacts
{
    internal class ContactGetDto
    {
        [JsonProperty("addresses")]
        public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();

        [JsonProperty("anniversary")]
        public DateTimeOffset Anniversary { get; set; }

        [JsonProperty("birthday")]
        public DateTimeOffset Birthday { get; set; }

        [JsonProperty("company")]
        public CompanyGetDto Company { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("custom_fields")]
        public List<CustomFieldDto> CustomFields { get; set; } = new List<CustomFieldDto>();

        [JsonProperty("date_created")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("email_addresses")]
        public List<EmailAddressGetDto> EmailAddresses { get; set; } = new List<EmailAddressGetDto>();

        [JsonProperty("email_opted_in")]
        public bool EmailOptedIn { get; set; }

        [JsonProperty("email_status")]
        public string EmailStatus { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("fax_numbers")]
        public List<FaxNumberDto> FaxNumbers { get; set; } = new List<FaxNumberDto>();

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("lead_source_id")]
        public long LeadSourceId { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("opt_in_reason")]
        public string OptInReason { get; set; }

        [JsonProperty("origin")]
        public IpOriginGetDto Origin { get; set; }

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

        [JsonProperty("relationships")]
        public List<RelationshipDto> Relationships { get; set; } = new List<RelationshipDto>();

        [JsonProperty("ScoreValue")]
        public string ScoreValue { get; set; }

        [JsonProperty("social_accounts")]
        public List<SocialAccountDto> SocialAccounts { get; set; } = new List<SocialAccountDto>();

        [JsonProperty("source_type")]
        public string SourceType { get; set; }

        [JsonProperty("spouse_name")]
        public string SpouseName { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("tag_ids")]
        public List<long> TagIds { get; set; } = new List<long>();

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        internal Contact MapTo()
        {
            Contact r = new Contact();
            foreach (var item in this.Addresses)
            {
                r.Addresses.Add(item.MapTo());
            }
            r.Anniversary = this.Anniversary;
            r.Birthday = this.Birthday;
            r.Company = this.Company?.MapTo();
            r.CompanyName = this.CompanyName;
            r.ContactType = this.ContactType;
            if (this.CustomFields != null)
            {
                r.CustomFields.AddRange(this.CustomFields.Select(item => item.MapTo()));
            }

            r.DateCreated = this.DateCreated;
            if (this.EmailAddresses != null)
            {
                r.EmailAddresses.AddRange(this.EmailAddresses.Select(item => item.MapTo()));
            }
            r.EmailOptedIn = this.EmailOptedIn;
            r.EmailStatus = this.EmailStatus;
            r.FamilyName = this.FamilyName;
            if (this.FaxNumbers != null)
            {
                r.FaxNumbers.AddRange(this.FaxNumbers.Select(item => item.MapTo()));
            }
            r.GivenName = this.GivenName;
            r.Id = this.Id;
            r.JobTitle = this.JobTitle;
            r.LastUpdated = this.LastUpdated;
            r.LeadSourceId = this.LeadSourceId;
            r.MiddleName = this.MiddleName;
            r.OptInReason = this.OptInReason;
            r.Origin = this.Origin?.MapTo();
            r.OwnerId = this.OwnerId;
            if (this.PhoneNumbers != null)
            {
                r.PhoneNumbers.AddRange(this.PhoneNumbers.Select(item => item.MapTo()));
            }

            r.PreferredLocale = this.PreferredLocale;
            r.PreferredName = this.PreferredName;
            r.Prefix = this.Prefix;
            if (this.Relationships != null)
            {
                r.Relationships.AddRange(this.Relationships.Select(item => item.MapTo()));
            }
            r.ScoreValue = this.ScoreValue;
            if (this.SocialAccounts != null)
            {
                r.SocialAccounts.AddRange(this.SocialAccounts.Select(item => item.MapTo()));
            }
            r.SourceType = this.SourceType;
            r.SpouseName = this.SpouseName;
            r.Suffix = this.Suffix;
            r.TagIds = this.TagIds?.ToList();
            r.TimeZone = this.TimeZone;
            r.Website = this.Website;
            return r;
        }
    }
}