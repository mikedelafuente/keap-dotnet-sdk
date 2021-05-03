using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Locale
{
    internal class CountriesDto
    {
        [JsonPropertyName("countries")]
        public Dictionary<string, string> Countries { get; set; }
    }
}