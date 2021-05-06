using Keap.Sdk.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public class Contact
    {
        [JsonPropertyName("addresses")]
        public List<Address> Addresses { get; set; } = new List<Address>();

        [JsonPropertyName("anniversary")]
        public DateTimeOffset Anniversary { get; set; }

        [JsonPropertyName("birthday")]
        public DateTimeOffset Birthday { get; set; }

        [JsonPropertyName("company")]
        public Company Company { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("contact_type")]
        public string ContactType { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();

        [JsonPropertyName("date_created")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonPropertyName("email_addresses")]
        public List<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();

        [JsonPropertyName("email_opted_in")]
        public bool EmailOptedIn { get; set; }

        [JsonPropertyName("email_status")]
        public string EmailStatus { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        [JsonPropertyName("fax_numbers")]
        public List<PhoneNumber> FaxNumbers { get; set; } = new List<PhoneNumber>();

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
        public IpOrigin Origin { get; set; }

        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

        [JsonPropertyName("phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

        [JsonPropertyName("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonPropertyName("preferred_name")]
        public string PreferredName { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("relationships")]
        public List<Relationship> Relationships { get; set; }

        [JsonPropertyName("ScoreValue")]
        public string ScoreValue { get; set; }

        [JsonPropertyName("social_accounts")]
        public List<SocialAccount> SocialAccounts { get; set; } = new List<SocialAccount>();

        [JsonPropertyName("source_type")]
        public string SourceType { get; set; }

        [JsonPropertyName("spouse_name")]
        public string SpouseName { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("tag_ids")]
        public List<long> TagIds { get; set; } = new List<long>();

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }
    }
}