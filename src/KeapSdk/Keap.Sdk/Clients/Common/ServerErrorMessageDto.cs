using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keap.Sdk.Clients.Common
{
    internal class ServerErrorMessageDto
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}