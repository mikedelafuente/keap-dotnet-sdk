using Keap.Sdk.Clients.Authentication.ResponseModels;
using System;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Domain
{
    /// <summary>
    /// A combination of both the developer credentials and the access token. Store this information
    /// in your system to reuse the tokens.
    /// </summary>
    public class AccessTokenCredentials
    {
        public AccessTokenCredentials()
        {
        }

        internal AccessTokenCredentials(string integrationName, string integratorUniqueIdentifier, string clientId, string clientSecret, string restApiUrl, string xmlRpcApiUrl, string authorizationRequestUrl, string accessTokenRequestUrl, string refreshTokenRequestUrl, DateTime createTime, AccessTokenDto accessTokenResponse)
        {
            AccessToken = accessTokenResponse.AccessToken;
            ExpiresIn = accessTokenResponse.ExpiresIn;
            RefreshToken = accessTokenResponse.RefreshToken;
            Scope = accessTokenResponse.Scope;
            TokenType = accessTokenResponse.TokenType;

            RestApiUrl = restApiUrl;
            XmlRpcApiUrl = xmlRpcApiUrl;
            ClientId = clientId;
            ClientSecret = clientSecret;
            CreateTime = createTime;
            IntegratorUniqueIdentifier = integratorUniqueIdentifier;
            IntegrationName = integrationName;
            AuthorizationRequestUrl = authorizationRequestUrl;
            AccessTokenRequestUrl = accessTokenRequestUrl;
            RefreshTokenRequestUrl = refreshTokenRequestUrl;
        }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("access_token_request_url")]
        public string AccessTokenRequestUrl { get; set; }

        [JsonPropertyName("authorization_request_url")]
        public string AuthorizationRequestUrl { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("created_at")]
        public System.DateTime CreateTime { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("integration_name")]
        public string IntegrationName { get; set; }

        /// <summary>
        /// This can be anything or empty. Use it to flow an identity of a user in your system to
        /// this token.
        /// </summary>
        [JsonPropertyName("integrator_unique_identifier")]
        public string IntegratorUniqueIdentifier { get; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("refresh_token_request_url")]
        public string RefreshTokenRequestUrl { get; set; }

        [JsonPropertyName("rest_api_url")]
        public string RestApiUrl { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("xml_rpc_api_url")]
        public string XmlRpcApiUrl { get; set; }

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

            if (string.IsNullOrWhiteSpace(RestApiUrl))
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