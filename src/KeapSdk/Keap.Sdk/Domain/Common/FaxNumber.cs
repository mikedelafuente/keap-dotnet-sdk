using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Common
{
    public class FaxNumber
    {
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("field")]
        public FaxFieldType Field { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}