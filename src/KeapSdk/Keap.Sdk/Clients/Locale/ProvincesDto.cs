using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Locale
{
    internal class ProvincesDto
    {
        [JsonPropertyName("provinces")]
        public Dictionary<string, string> Provinces { get; set; }
    }
}