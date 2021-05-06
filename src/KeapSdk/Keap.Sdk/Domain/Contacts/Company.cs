using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Contacts
{
    public class Company
    {
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}