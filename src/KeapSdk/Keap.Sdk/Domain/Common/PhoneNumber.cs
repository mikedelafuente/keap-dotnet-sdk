﻿using Newtonsoft.Json;

namespace Keap.Sdk.Domain.Common
{
    // TODO: Add comments to properties and class

    public class PhoneNumber
    {
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}