using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class SocialAccountDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        internal static SocialAccountDto MapFrom(SocialAccount source)
        {
            if (source == null)
            {
                return null;
            }

            SocialAccountDto r = new();
            r.Name = source.Name;
            r.Type = source.Type.ToString();
            return r;
        }

        internal SocialAccount MapTo()
        {
            SocialAccount r = new();
            r.Name = this.Name;
            r.Type = Enum.Parse<SocialAccountType>(this.Type);
            return r;
        }
    }
}