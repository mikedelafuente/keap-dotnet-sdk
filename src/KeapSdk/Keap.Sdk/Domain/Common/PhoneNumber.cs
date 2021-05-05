using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Common
{
    // TODO: Add comments to properties and class

    public class PhoneNumber
    {
        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}