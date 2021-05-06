using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class IpOriginDto
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("ip_address")]
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