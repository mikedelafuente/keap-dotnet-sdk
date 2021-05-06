using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain.Contacts
{
    public class Company
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}