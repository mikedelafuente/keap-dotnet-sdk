using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Keap.Sdk.Domain.Clients
{
    internal static class RestHelper
    {
        internal static System.Collections.Specialized.NameValueCollection ConvertPageTokenToNameValueCollection(string nextPageToken)
        {
            var queryString = Encoding.UTF8.GetString(Convert.FromBase64String(nextPageToken));
            var nvp = System.Web.HttpUtility.ParseQueryString(queryString);
            return nvp;
        }

        internal static T ProcessResults<T>(ServerResponse serverResponse)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            if (serverResponse.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<T>(serverResponse.ResponseBody, options);
                return result;
            }

            // TODO: Make the return type nullable
            //return default(T);
            throw new Exceptions.KeapException($"There was an unsuccesful status code returned: " +
                $"{System.Environment.NewLine}Status Code: {(int)serverResponse.StatusCode} ({serverResponse.StatusCode}) " +
                $"{System.Environment.NewLine}Reason Phrase: {serverResponse.ReasonPhrase}" +
                $"{System.Environment.NewLine}BODY: {serverResponse.ResponseBody}" +
                $"{System.Environment.NewLine}",
                new HttpRequestException(serverResponse.ReasonPhrase, null, serverResponse.StatusCode));
        }
    }
}