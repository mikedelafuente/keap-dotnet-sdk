using Keap.Sdk.Domain.Contacts;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Contacts
{
    internal class SocialAccountDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
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