using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keap.Sdk.Clients.Locale
{
    internal class ProvincesDto
    {
        [JsonProperty("provinces")]
        public Dictionary<string, string> Provinces { get; set; }
    }
}