using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Domain.Contacts
{
    public class IpOrigin
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
    }
}