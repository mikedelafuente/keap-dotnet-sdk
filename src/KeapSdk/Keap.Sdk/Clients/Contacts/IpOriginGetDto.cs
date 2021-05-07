using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;
using System;

namespace Keap.Sdk.Clients.Contacts
{
    internal class IpOriginGetDto
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        internal static IpOriginGetDto MapFrom(IpOrigin source)
        {
            if (source == null)
            {
                return null;
            }

            IpOriginGetDto r = new();
            r.Date = source.Date;
            r.IpAddress = source.IpAddress;
            return r;
        }

        internal IpOrigin MapTo()
        {
            IpOrigin r = new();
            r.Date = this.Date;
            r.IpAddress = this.IpAddress;
            return r;
        }
    }

    internal class IpOriginPutPostDto
    {
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        internal static IpOriginPutPostDto MapFrom(IpOrigin source)
        {
            if (source == null)
            {
                return null;
            }

            IpOriginPutPostDto r = new();
            r.IpAddress = source.IpAddress;
            return r;
        }
    }
}