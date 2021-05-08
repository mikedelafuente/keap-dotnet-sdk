using Keap.Sdk.Clients.Authentication.ResponseModels;
using Keap.Sdk.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

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
            path = RestHelper.CleanupPathAndQueryString(path);
            LogEventManager.Info($"DELETE {path}");
            ValidateToken();
            var httpResponseTask = _restClient.DeleteAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> GetAsync(string path)
        {
            path = RestHelper.CleanupPathAndQueryString(path);
            LogEventManager.Info($"GET {path}");
            ValidateToken();
            var httpResponseTask = _restClient.GetAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public StringContent GetJsonContentType(object value)
        {
            return new StringContent(SerializeRequest(value), Encoding.UTF8, "application/json");
        }

        public async Task<ServerResponse> PatchAsync(string path, object dtoToSerialize)
        {
            path = RestHelper.CleanupPathAndQueryString(path);
            LogEventManager.Info($"PATCH {path}");

            ValidateToken();
            var jsonContent = GetJsonContentType(dtoToSerialize);

            var httpResponseTask = _restClient.PatchAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PostAsync(string path, object dtoToSerialize)
        {
            path = RestHelper.CleanupPathAndQueryString(path);
            LogEventManager.Info($"POST {path}");

            ValidateToken();
            var jsonContent = GetJsonContentType(dtoToSerialize);

            var httpResponseTask = _restClient.PostAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PutAsync(string path, object dtoToSerialize)
        {
            path = RestHelper.CleanupPathAndQueryString(path);
            LogEventManager.Info($"PUT {path}");

            ValidateToken();
            var jsonContent = GetJsonContentType(dtoToSerialize);

            var httpResponseTask = _restClient.PutAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        private static string JsonPrettify(string json)
        {
            string output = json;
            if (!String.IsNullOrWhiteSpace(json) && json.Trim().StartsWith("{"))
            {
                try
                {
                    using (var stringReader = new StringReader(json))
                    {
                        using (var stringWriter = new StringWriter())
                        {
                            var jsonReader = new JsonTextReader(stringReader);
                            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                            jsonWriter.WriteToken(jsonReader);
                            output = stringWriter.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogEventManager.Info($"Could not parse JSON:{Environment.NewLine}{json}");
                    LogEventManager.Error(ex);
                }
            }
            return output;
        }

        private static ServerResponse ParseHttpResponse(HttpResponseMessage httpResponse)
        {
            var serverResponse = new ServerResponse
            {
                StatusCode = httpResponse.StatusCode,
                ReasonPhrase = httpResponse.ReasonPhrase,
                IsSuccessStatusCode = httpResponse.IsSuccessStatusCode
            };

            try
            {
                // TODO: Parse non-success codes to JSON to see if there is an error message in the format of: { "message":"blah" }
                // Store that message as an "Error reason"

                var stringTask = httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
                serverResponse.ResponseBody = stringTask.GetResult();
            }
            catch (Exception ex)
            {
                LogEventManager.Error(ex);
                if (serverResponse.IsSuccessStatusCode)
                {
                    // We should not be in a failing state
                    throw;
                }
            }
            LogEventManager.Info($"Response: {(int)serverResponse.StatusCode} ({serverResponse.StatusCode})");
            LogEventManager.Info($"Response Body: {Environment.NewLine}{JsonPrettify(serverResponse.ResponseBody)}");
            return serverResponse;
        }

        private static AccessTokenCredentials RefreshAccessToken(AccessTokenCredentials currentCredentials)
        {
            LogEventManager.Info($"Refreshing Access Token");
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
                throw new Exceptions.KeapHttpRequestException("Unable to convert the OAuth2 code into an access token. Please try again.", httpResponse.StatusCode, new HttpRequestException(httpResponse.ReasonPhrase));
            }

            var responseContentTask = httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
            var responseContent = responseContentTask.GetResult();

            JsonSerializerSettings options = new JsonSerializerSettings() { Formatting = Formatting.Indented };
            var accessTokenResponse = JsonConvert.DeserializeObject<AccessTokenDto>(responseContent, options);

            AccessTokenCredentials credentials = new AccessTokenCredentials(currentCredentials.IntegrationName, currentCredentials.IntegratorUniqueIdentifier, currentCredentials.ClientId, currentCredentials.ClientSecret, currentCredentials.RestApiUrl, currentCredentials.XmlRpcApiUrl, currentCredentials.AuthorizationRequestUrl, currentCredentials.AccessTokenRequestUrl, currentCredentials.RefreshTokenRequestUrl, createTime, accessTokenResponse);
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
            JsonSerializerSettings options = new JsonSerializerSettings() { Formatting = Formatting.Indented };
            string json = JsonConvert.SerializeObject(value, options);
            LogEventManager.Info($"JSON request sent:{Environment.NewLine}{json}");
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