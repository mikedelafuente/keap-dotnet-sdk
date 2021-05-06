using Keap.Sdk.Domain.Contacts;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Contacts
{
    internal class IpOriginDto
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }

        internal IpOrigin MapTo()
        {
            IpOrigin r = new();
            r.Date = this.Date;
            r.IpAddress = this.IpAddress;
            return r;
        }
    }
}