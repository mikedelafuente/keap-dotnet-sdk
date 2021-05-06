using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CustomFieldDto
    {
        [JsonProperty("content")]
        public CustomFieldContentDto Content { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        internal CustomField MapTo()
        {
            CustomField r = new();
            r.Content = this.Content?.MapTo();
            r.Id = this.Id;
            return r;
        }
    }
}