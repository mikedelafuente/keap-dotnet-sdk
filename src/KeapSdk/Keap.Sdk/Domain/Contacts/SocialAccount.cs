using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Contacts
{
    public class SocialAccount
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}