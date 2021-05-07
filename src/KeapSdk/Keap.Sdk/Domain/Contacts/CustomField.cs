using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Contacts
{
    public class CustomField
    {
        [JsonProperty("content")]
        public CustomFieldContent Content { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}