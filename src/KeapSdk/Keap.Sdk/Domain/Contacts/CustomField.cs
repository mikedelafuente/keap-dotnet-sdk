using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public class CustomField
    {
        [JsonPropertyName("content")]
        public CustomFieldContent Content { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}