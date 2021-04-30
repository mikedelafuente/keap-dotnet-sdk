using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain
{
    public class AccessToken
    {
        [JsonPropertyName("expires_at")]
        public System.DateTime ExpiresAt { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}