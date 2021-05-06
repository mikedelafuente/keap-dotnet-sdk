using Keap.Sdk.Domain.Contacts;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CustomFieldDto
    {
        [JsonPropertyName("content")]
        public CustomFieldContentDto Content { get; set; }

        [JsonPropertyName("id")]
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