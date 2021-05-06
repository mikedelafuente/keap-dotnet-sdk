using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public class SocialAccount
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}