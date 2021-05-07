using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Common
{
    public class PhoneNumber
    {
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("field")]
        public PhoneFieldType Field { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}