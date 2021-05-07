using Newtonsoft.Json;

namespace Keap.Sdk.Clients.Common
{
    internal class ServerErrorMessageDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}