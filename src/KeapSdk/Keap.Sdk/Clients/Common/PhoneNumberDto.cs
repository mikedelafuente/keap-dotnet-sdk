using Keap.Sdk.Domain.Common;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients.Common
{
    // TODO: Add comments to properties and class

    public class PhoneNumberDto
    {
        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        internal PhoneNumber MapTo()
        {
            var result = new PhoneNumber
            {
                Extension = this.Extension,
                Field = this.Field,
                Number = this.Number,
                Type = this.Type
            };

            return result;
        }
    }
}