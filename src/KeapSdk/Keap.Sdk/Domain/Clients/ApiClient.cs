using Keap.Sdk.Domain;
using Keap.Sdk.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Clients
{
    internal class ApiClient : IApiClient
    {

        internal ApiClient(string consumingApplicationName, string apiBaseAddress)
        {
            InitializeClient(consumingApplicationName, apiBaseAddress);
        }

        private void InitializeClient(string consumingApplicationName, string apiBaseAddress)
        {
            restClient = new HttpClient();
            restClient.DefaultRequestHeaders.Accept.Clear();
            restClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            restClient.DefaultRequestHeaders.Add("User-Agent", consumingApplicationName);
            restClient.BaseAddress = new Uri(apiBaseAddress);
        }

        private HttpClient restClient;

        public StringContent GetJsonContentType(object value)
        {
            return new StringContent(SerializeRequest(value), Encoding.UTF8, "application/json");
        }

        private string SerializeRequest(object value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            string json = JsonSerializer.Serialize(value);
            LogEventManager.Info($"JSON request sent: {json}");
            return json;
        }



        public async Task<ServerResponse> GetAsync(string path)
        {
            var httpResponseTask = restClient.GetAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PostAsync(string path, object valueToSerialize)
        {
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = restClient.PostAsync(path, jsonContent);
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

        public async Task<ServerResponse> DeleteAsync(string path)
        {
            var httpResponseTask = restClient.DeleteAsync(path);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PutAsync(string path, object valueToSerialize)
        {
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = restClient.PutAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }

        public async Task<ServerResponse> PatchAsync(string path, object valueToSerialize)
        {
            var jsonContent = GetJsonContentType(valueToSerialize);

            var httpResponseTask = restClient.PatchAsync(path, jsonContent);
            var httpResponse = await httpResponseTask;

            return ParseHttpResponse(httpResponse);
        }
    }
}
