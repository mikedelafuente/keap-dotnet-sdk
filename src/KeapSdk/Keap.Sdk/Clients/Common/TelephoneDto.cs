using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Common
{
    internal abstract class TelephoneDto
    {
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}