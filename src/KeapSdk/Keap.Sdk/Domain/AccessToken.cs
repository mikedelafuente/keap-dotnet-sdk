﻿using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain
{
    public class AccessToken
    {
        public AccessToken(string integrationName, string clientId, string clientSecret, string baseUrl)
        {
            IntegrationName = integrationName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            BaseUrl = baseUrl;
        }

        [JsonPropertyName("access_token")]
        public string Token { get; set; }
        
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        


    }
}
