using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Keap.Sdk.Clients.Users
{
    internal class UserDto
    {
        [JsonProperty("address")]
        public Common.AddressDto Address { get; set; }

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
        public Common.PhoneNumberDto[] FaxNumbers { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        // TODO: Use [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonProperty("global_user_id")]
        public long? GlobalUserId { get; set; }

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
        public Common.PhoneNumberDto[] PhoneNumbers { get; set; }

        [JsonProperty("preferred_name")]
        public string PreferredName { get; set; }

        /// <summary>
        /// Can be Active, Invited or Inactive
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("website")]
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