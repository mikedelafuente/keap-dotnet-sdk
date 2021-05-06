using Keap.Sdk.Clients.Common;
using Keap.Sdk.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Contacts
{
    internal class ContactDto
    {
        [JsonPropertyName("addresses")]
        public AddressDto[] Addresses { get; set; }

        [JsonPropertyName("anniversary")]
        public DateTimeOffset Anniversary { get; set; }

        [JsonPropertyName("birthday")]
        public DateTimeOffset Birthday { get; set; }

        [JsonPropertyName("company")]
        public CompanyDto Company { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("contact_type")]
        public string ContactType { get; set; }

        [JsonPropertyName("custom_fields")]
        public CustomFieldDto[] CustomFields { get; set; }

        [JsonPropertyName("date_created")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonPropertyName("email_addresses")]
        public EmailAddressDto[] EmailAddresses { get; set; }

        [JsonPropertyName("email_opted_in")]
        public bool EmailOptedIn { get; set; }

        [JsonPropertyName("email_status")]
        public string EmailStatus { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        [JsonPropertyName("fax_numbers")]
        public PhoneNumberDto[] FaxNumbers { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonPropertyName("lead_source_id")]
        public long LeadSourceId { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("opt_in_reason")]
        public string OptInReason { get; set; }

        [JsonPropertyName("origin")]
        public IpOriginDto Origin { get; set; }

        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

        [JsonPropertyName("phone_numbers")]
        public PhoneNumberDto[] PhoneNumbers { get; set; }

        [JsonPropertyName("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonPropertyName("preferred_name")]
        public string PreferredName { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("relationships")]
        public RelationshipDto[] Relationships { get; set; }

        [JsonPropertyName("ScoreValue")]
        public string ScoreValue { get; set; }

        [JsonPropertyName("social_accounts")]
        public SocialAccountDto[] SocialAccounts { get; set; }

        [JsonPropertyName("source_type")]
        public string SourceType { get; set; }

        [JsonPropertyName("spouse_name")]
        public string SpouseName { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("tag_ids")]
        public long[] TagIds { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("website")]
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
            foreach (var item in this.CustomFields)
            {
                r.CustomFields.Add(item.MapTo());
            }

            r.DateCreated = this.DateCreated;
            foreach (var item in this.EmailAddresses)
            {
                r.EmailAddresses.Add(item.MapTo());
            }

            r.EmailOptedIn = this.EmailOptedIn;
            r.EmailStatus = this.EmailStatus;
            r.FamilyName = this.FamilyName;
            foreach (var item in this.FaxNumbers)
            {
                r.FaxNumbers.Add(item.MapTo());
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
            foreach (var item in this.PhoneNumbers)
            {
                r.PhoneNumbers.Add(item.MapTo());
            }
            r.PreferredLocale = this.PreferredLocale;
            r.PreferredName = this.PreferredName;
            r.Prefix = this.Prefix;
            foreach (var item in this.Relationships)
            {
                r.Relationships.Add(item.MapTo());
            }
            r.ScoreValue = this.ScoreValue;

            foreach (var item in this.SocialAccounts)
            {
                r.SocialAccounts.Add(item.MapTo());
            }

            r.SpouseName = this.SpouseName;
            r.Suffix = this.Suffix;
            r.TagIds = this.TagIds?.ToList();
            r.TimeZone = this.TimeZone;
            r.Website = this.Website;
            return r;
        }
    }
}