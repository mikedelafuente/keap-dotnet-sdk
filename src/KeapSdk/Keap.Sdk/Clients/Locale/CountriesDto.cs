using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keap.Sdk.Clients.Locale
{
    internal class CountriesDto
    {
        [JsonProperty("countries")]
        public Dictionary<string, string> Countries { get; set; }
    }
}