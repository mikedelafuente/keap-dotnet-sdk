using Keap.Sdk.Domain.Contacts;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Contacts
{
    internal class EmailAddressDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("email_opt_status")]
        public string EmailOptStatus { get; set; }

        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("is_opt_in")]
        public bool IsOptIn { get; set; }

        [JsonPropertyName("opt_in_reason")]
        public string OptInReason { get; set; }

        internal EmailAddress MapTo()
        {
            throw new NotImplementedException();
        }
    }
}