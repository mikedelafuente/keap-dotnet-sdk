using Keap.Sdk.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Keap.Sdk.Domain.Users
{
    public class User
    {
        /// <summary>
        /// Can be null. Address of the user.
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("created_by")]
        public long CreatedBy { get; set; }

        [JsonProperty("date_created")]
        public DateTimeOffset? DateCreated { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("fax_numbers")]
        public List<PhoneNumber> FaxNumbers { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("global_user_id")]
        public long GlobalUserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("infusionsoft_id")]
        public string InfusionsoftId { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("last_updated_by")]
        public long LastUpdatedBy { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("partner")]
        public bool Partner { get; set; }

        [JsonProperty("phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        [JsonProperty("preferred_name")]
        public string PreferredName { get; set; }

        /// <summary>
        /// Can be Active, Invited or Inactive
        /// </summary>
        [JsonProperty("status")]
        public UserStatus Status { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }
}