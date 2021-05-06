using Keap.Sdk.Domain.Common;
using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Common
{
    // TODO: Add comments to properties and class

    internal class PhoneNumberDto
    {
        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
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