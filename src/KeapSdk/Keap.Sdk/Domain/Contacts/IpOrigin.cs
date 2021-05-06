using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public class IpOrigin
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }
    }
}