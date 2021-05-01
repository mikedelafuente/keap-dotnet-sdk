using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain
{
    /// <summary>
    ///  A combination of both the developer credentials and the access token. Store this information in your system to reuse the tokens.
    /// </summary>
    public class AccessTokenCredentials
    {
        public AccessTokenCredentials(string integrationName, string clientId, string clientSecret, string baseUrl, string accessToken, string refreshToken, int expiresIn, DateTime createTime)
        {
            AccessToken = accessToken;
            BaseUrl = baseUrl;
            ClientId = clientId;
            ClientSecret = clientSecret;
            CreateTime = createTime;
            ExpiresIn = expiresIn;
            IntegrationName = integrationName;
            RefreshToken = refreshToken;

            // Calculated value
        }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("base_url")]
        public string BaseUrl { get; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; }

        [JsonPropertyName("expires_at")]
        public System.DateTime CreateTime { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("integration_name")]
        public string IntegrationName { get; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        public System.DateTime GetAccessTokenExpiration()
        {
            return CreateTime.AddSeconds(ExpiresIn);
        }

        public System.DateTime GetRefreshTokenExpiration()
        {
            return CreateTime.AddMilliseconds(3922560000); // Per Apigee and the Keap team
        }

        internal bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(AccessToken))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(BaseUrl))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(ClientId))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(ClientSecret))
            {
                return false;
            }

            if (ExpiresIn <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(IntegrationName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(RefreshToken))
            {
                return false;
            }
            return true;
        }
    }
}