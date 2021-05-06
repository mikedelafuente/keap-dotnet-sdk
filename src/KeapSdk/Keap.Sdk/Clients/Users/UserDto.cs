using Keap.Sdk.Clients.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Users
{
    internal class UserDto
    {
        [JsonPropertyName("address")]
        public Common.AddressDto Address { get; set; }

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
        public Common.PhoneNumberDto[] FaxNumbers { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("global_user_id")]
        public long? GlobalUserId { get; set; }

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
        public Common.PhoneNumberDto[] PhoneNumbers { get; set; }

        [JsonPropertyName("preferred_name")]
        public string PreferredName { get; set; }

        /// <summary>
        /// Can be Active, Invited or Inactive
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        internal Domain.Users.User MapTo()
        {
            Domain.Users.User result = new();

            if (Address != null)
            {
                result.Address = this.Address.MapTo();
            }
            result.CompanyName = this.CompanyName;
            result.CreatedBy = this.CreatedBy;
            result.DateCreated = this.DateCreated;
            result.EmailAddress = this.EmailAddress;
            result.FamilyName = this.FamilyName;
            result.GivenName = this.GivenName;
            if (this.GlobalUserId.HasValue)
            {
                result.GlobalUserId = this.GlobalUserId.Value;
            }

            result.Id = this.Id;
            result.InfusionsoftId = this.InfusionsoftId;
            result.JobTitle = this.JobTitle;
            result.LastUpdated = this.LastUpdated;
            result.LastUpdatedBy = this.LastUpdatedBy;
            result.MiddleName = this.MiddleName;
            result.Partner = this.Partner;
            result.PreferredName = this.PreferredName;
            result.TimeZone = this.TimeZone;
            result.Website = this.Website;
            result.FaxNumbers = new List<Domain.Common.PhoneNumber>();
            result.PhoneNumbers = new List<Domain.Common.PhoneNumber>();

            foreach (var item in this.FaxNumbers)
            {
                result.FaxNumbers.Add(item.MapTo());
            }

            foreach (var item in this.PhoneNumbers)
            {
                result.PhoneNumbers.Add(item.MapTo());
            }

            if (Enum.TryParse(this.Status, out Domain.Users.UserStatus parsedStatus))
            {
                result.Status = parsedStatus;
            }

            return result;
        }
    }
}