using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CustomFieldDto
    {
        [JsonProperty("content")]
        public CustomFieldContentDto Content { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        internal static CustomFieldDto MapFrom(CustomField source)
        {
            if (source == null)
            {
                return null;
            }

            CustomFieldDto r = new();
            r.Content = CustomFieldContentDto.MapFrom(source.Content);
            r.Id = source.Id;
            return r;
        }

        internal CustomField MapTo()
        {
            CustomField r = new();
            r.Content = this.Content?.MapTo();
            r.Id = this.Id;
            return r;
        }
    }
}