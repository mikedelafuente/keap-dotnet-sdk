using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Contacts
{
    internal class SocialAccountDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        internal SocialAccount MapTo()
        {
            SocialAccount r = new();
            r.Name = this.Name;
            r.Type = this.Type;
            return r;
        }
    }
}