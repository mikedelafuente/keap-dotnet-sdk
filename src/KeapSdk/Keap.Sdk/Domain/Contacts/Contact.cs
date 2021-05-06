using Keap.Sdk.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Keap.Sdk.Domain.Contacts
{
    public class Contact
    {
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; } = new List<Address>();

        [JsonProperty("anniversary")]
        public DateTimeOffset Anniversary { get; set; }

        [JsonProperty("birthday")]
        public DateTimeOffset Birthday { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();

        [JsonProperty("date_created")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("email_addresses")]
        public List<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();

        [JsonProperty("email_opted_in")]
        public bool EmailOptedIn { get; set; }

        [JsonProperty("email_status")]
        public string EmailStatus { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("fax_numbers")]
        public List<PhoneNumber> FaxNumbers { get; set; } = new List<PhoneNumber>();

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("lead_source_id")]
        public long LeadSourceId { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("opt_in_reason")]
        public string OptInReason { get; set; }

        [JsonProperty("origin")]
        public IpOrigin Origin { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("preferred_name")]
        public string PreferredName { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("relationships")]
        public List<Relationship> Relationships { get; set; }

        [JsonProperty("ScoreValue")]
        public string ScoreValue { get; set; }

        [JsonProperty("social_accounts")]
        public List<SocialAccount> SocialAccounts { get; set; } = new List<SocialAccount>();

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
    }
}