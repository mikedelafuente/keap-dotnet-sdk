using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Contacts
{
    public class EmailAddress
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        //[JsonProperty("email_opt_status")]
        //public EmailOptStatusType EmailOptStatus { get; set; }

        [JsonProperty("field")]
        public EmailFieldType Field { get; set; }

        //[JsonProperty("is_opt_in")]
        //public bool IsOptIn { get; set; }

        //[JsonProperty("opt_in_reason")]
        //public string OptInReason { get; set; }
    }
}