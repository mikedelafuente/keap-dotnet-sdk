using Keap.Sdk.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Users
{
    public class User
    {
        /// <summary>
        /// Can be null. Address of the user.
        /// </summary>
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("created_by")]
        public long CreatedBy { get; set; }

        [JsonPropertyName("date_created")]
        public DateTimeOffset? DateCreated { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        [JsonPropertyName("fax_numbers")]
        public List<PhoneNumber> FaxNumbers { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("global_user_id")]
        public long GlobalUserId { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("infusionsoft_id")]
        public string InfusionsoftId { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonPropertyName("last_updated_by")]
        public long LastUpdatedBy { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("partner")]
        public bool Partner { get; set; }

        [JsonPropertyName("phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        [JsonPropertyName("preferred_name")]
        public string PreferredName { get; set; }

        /// <summary>
        /// Can be Active, Invited or Inactive
        /// </summary>
        [JsonPropertyName("status")]
        public UserStatus Status { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }
    }
}