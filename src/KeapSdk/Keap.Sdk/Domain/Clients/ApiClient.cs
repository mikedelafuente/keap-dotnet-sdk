using Keap.Sdk.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Clients
{
    internal class ApiClient : IApiClient
    {
        private HttpClient _restClient;

        internal ApiClient(AccessTokenCredentials accessTokenCredentials)
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
            var httpResponseTask = _restClient.DeleteAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> GetAsync(string path)
        {
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
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = _restClient.PatchAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PostAsync(string path, object valueToSerialize)
        {
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = _restClient.PostAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PutAsync(string path, object valueToSerialize)
        {
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

        private void InitializeClient()
        {
            _restClient = new HttpClient();
            _restClient.DefaultRequestHeaders.Accept.Clear();
            _restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _restClient.DefaultRequestHeaders.Add("User-Agent", AccessTokenCredentials.IntegrationName);
            _restClient.BaseAddress = new Uri(AccessTokenCredentials.RestUrl);
        }

        private string SerializeRequest(object value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            string json = JsonSerializer.Serialize(value);
            LogEventManager.Info($"JSON request sent: {json}");
            return json;
        }
    }
}