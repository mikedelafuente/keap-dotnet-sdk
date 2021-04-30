using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain
{
    internal class RestClient : IRestClient
    {
        public AccessToken AccessToken { get; set; }
    }

    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string Scope { get; set; }
        public string RefreshToken { get; set; }

    }

    public interface IRestClient
    {
        AccessToken AccessToken { get; set; }

    }
}
