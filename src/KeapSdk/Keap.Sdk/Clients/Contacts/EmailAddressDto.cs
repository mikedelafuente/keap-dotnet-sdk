using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class EmailAddressDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_opt_status")]
        public string EmailOptStatus { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("is_opt_in")]
        public bool IsOptIn { get; set; }

        // TODO: Does clearing the opt-in reason set IsOptIn to false?
        [JsonProperty("opt_in_reason")]
        public string OptInReason { get; set; }

        internal EmailAddress MapTo()
        {
            EmailAddress r = new();
            r.Email = this.Email;
            r.EmailOptStatus = this.EmailOptStatus;
            r.Field = this.Field;
            r.IsOptIn = this.IsOptIn;
            r.OptInReason = this.OptInReason;
            return r;
        }
    }
}