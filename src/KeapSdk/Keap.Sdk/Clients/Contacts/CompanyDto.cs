using Keap.Sdk.Domain.Contacts;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CompanyDto
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        internal static CompanyDto MapFrom(Company source)
        {
            CompanyDto r = new CompanyDto();
            r.CompanyName = source.CompanyName;
            r.Id = source.Id;
            return r;
        }

        internal Company MapTo()
        {
            Company r = new Company();
            r.CompanyName = this.CompanyName;
            r.Id = this.Id;
            return r;
        }
    }
}