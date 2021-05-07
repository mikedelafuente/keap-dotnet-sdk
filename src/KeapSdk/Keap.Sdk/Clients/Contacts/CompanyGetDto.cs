using Keap.Sdk.Domain.Contacts;
using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Contacts
{
    internal class CompanyGetDto
    {
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        internal static CompanyGetDto MapFrom(Company source)
        {
            if (source == null)
            {
                return null;
            }

            CompanyGetDto r = new CompanyGetDto();
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

    internal class CompanyPutPostDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        internal static CompanyPutPostDto MapFrom(Company source)
        {
            if (source == null)
            {
                return null;
            }

            CompanyPutPostDto r = new CompanyPutPostDto();
            r.Id = source.Id;
            return r;
        }
    }
}