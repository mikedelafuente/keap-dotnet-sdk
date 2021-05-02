using Keap.Sdk.Clients.Authentication.ResponseModels;
using Keap.Sdk.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Clients
{
    internal class RestApiClient : IRestApiClient
    {
        private HttpClient _restClient;

        internal RestApiClient(AccessTokenCredentials accessTokenCredentials)
        {
            if (accessTokenCredentials == null)
            {
                throw new Exceptions.KeapArgumentException(nameof(accessTokenCredentials));
            }

            AccessTokenCredentials = accessTokenCredentials;

            InitializeClient();
        }

        public AccessTokenCredentials AccessTokenCredentials { get; set; }

        public async Task<ServerResponse> DeleteAsync(string path)
        {
            ValidateToken();
            var httpResponseTask = _restClient.DeleteAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> GetAsync(string path)
        {
            ValidateToken();
            var httpResponseTask = _restClient.GetAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public StringContent GetJsonContentType(object value)
        {
            return new StringContent(SerializeRequest(value), Encoding.UTF8, "application/json");
        }

        public async Task<ServerResponse> PatchAsync(string path, object valueToSerialize)
        {
            ValidateToken();
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = _restClient.PatchAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PostAsync(string path, object valueToSerialize)
        {
            ValidateToken();
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = _restClient.PostAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PutAsync(string path, object valueToSerialize)
        {
            ValidateToken();
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = _restClient.PutAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        private static ServerResponse ParseHttpResponse(HttpResponseMessage httpResponse)
        {
            var serverResponse = new ServerResponse
            {
                StatusCode = httpResponse.StatusCode,
                ReasonPhrase = httpResponse.ReasonPhrase,
                IsSuccessStatusCode = httpResponse.IsSuccessStatusCode
            };

            if (serverResponse.IsSuccessStatusCode)
            {
                var stringTask = httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
                serverResponse.ResponseBody = stringTask.GetResult();
            }

            return serverResponse;
        }

        private static AccessTokenCredentials RefreshAccessToken(AccessTokenCredentials currentCredentials)
        {
            HttpResponseMessage httpResponse;
            DateTime createTime;
            // POST the code to the token endpoint
            using (HttpClient httpClient = new HttpClient())
            {
                var requestBody = new Dictionary<string, string>();
                requestBody.Add("grant_type", "refresh_token");
                requestBody.Add("refresh_token", currentCredentials.RefreshToken);

                var content = new FormUrlEncodedContent(requestBody);
                createTime = DateTime.UtcNow;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{currentCredentials.ClientId}:{currentCredentials.ClientSecret}")));
                var postTask = httpClient.PostAsync(currentCredentials.RefreshTokenRequestUrl, content).ConfigureAwait(false).GetAwaiter();
                httpResponse = postTask.GetResult();
            }

            // Parse the response
            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exceptions.KeapHttpRequestException("Unable to convert the OAuth2 code into an access token. Please try again.", new HttpRequestException(httpResponse.ReasonPhrase));
            }

            var responseContentTask = httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
            var responseContent = responseContentTask.GetResult();

            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var accessTokenResponse = JsonSerializer.Deserialize<AccessTokenResponse>(responseContent, options);

            AccessTokenCredentials credentials = new AccessTokenCredentials(currentCredentials.IntegrationName, currentCredentials.ClientId, currentCredentials.ClientSecret, currentCredentials.RestApiUrl, currentCredentials.XmlRpcApiUrl, currentCredentials.AuthorizationRequestUrl, currentCredentials.AccessTokenRequestUrl, currentCredentials.RefreshTokenRequestUrl, createTime, accessTokenResponse);
            return credentials;
        }

        private void InitializeClient()
        {
            _restClient = new HttpClient();
            _restClient.DefaultRequestHeaders.Accept.Clear();
            _restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _restClient.DefaultRequestHeaders.Add("User-Agent", AccessTokenCredentials.IntegrationName);
            _restClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessTokenCredentials.AccessToken);
            _restClient.BaseAddress = new Uri(AccessTokenCredentials.RestApiUrl);
        }

        private string SerializeRequest(object value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            string json = JsonSerializer.Serialize(value);
            LogEventManager.Info($"JSON request sent: {json}");
            return json;
        }

        private void ValidateToken()
        {
            if (AccessTokenCredentials.GetAccessTokenExpiration() < DateTime.UtcNow.AddMinutes(5))
            {
                try
                {
                    // We should refresh the token
                    AccessTokenCredentials = RefreshAccessToken(AccessTokenCredentials);
                    InitializeClient();
                    // Make sure to raise the event to Persist
                    EventHub.PersistAccessTokenCredentials(AccessTokenCredentials);
                }
                catch (Exception ex)
                {
                    LogEventManager.ErrorAndThrow(ex);
                }
            }
        }
    }
}