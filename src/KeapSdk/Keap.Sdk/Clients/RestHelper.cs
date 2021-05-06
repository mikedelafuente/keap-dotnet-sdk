using Keap.Sdk.Clients.Common;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Keap.Sdk.Domain.Clients
{
    internal static class RestHelper
    {
        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public static string AttemptToGetErrorMessage(ServerResponse serverResponse)
        {
            string message = string.Empty;
            if (serverResponse.ResponseBody.Contains("{") && serverResponse.ResponseBody.Contains("\"message\""))
            {
                var messageDto = JsonSerializer.Deserialize<ServerErrorMessageDto>(serverResponse.ResponseBody, serializerOptions);
                if (messageDto != null)
                {
                    message = messageDto.Message;
                }
            }

            return message;
        }

        internal static System.Collections.Specialized.NameValueCollection ConvertPageTokenToNameValueCollection(string nextPageToken)
        {
            var queryString = Encoding.UTF8.GetString(Convert.FromBase64String(nextPageToken));
            var nvp = System.Web.HttpUtility.ParseQueryString(queryString);
            return nvp;
        }

        internal static T ProcessResults<T>(ServerResponse serverResponse)
        {
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<T>(serverResponse.ResponseBody, serializerOptions);
                return result;
            }
            else
            {
                var errorMessage = AttemptToGetErrorMessage(serverResponse);
                if (!String.IsNullOrWhiteSpace(errorMessage))
                {
                    throw new Exceptions.KeapHttpRequestException(errorMessage, serverResponse.StatusCode, new HttpRequestException(GenerateHttpExceptionReason(serverResponse), null, serverResponse.StatusCode));
                }
            }

            throw new Exceptions.KeapException(GenerateHttpExceptionReason(serverResponse),
               new HttpRequestException(serverResponse.ReasonPhrase, null, serverResponse.StatusCode));
        }

        private static string GenerateHttpExceptionReason(ServerResponse serverResponse)
        {
            return $"There was an unsuccesful status code returned: " +
                            $"{System.Environment.NewLine}Status Code: {(int)serverResponse.StatusCode} ({serverResponse.StatusCode}) " +
                            $"{System.Environment.NewLine}Reason Phrase: {serverResponse.ReasonPhrase}" +
                            $"{System.Environment.NewLine}BODY: {serverResponse.ResponseBody}" +
                            $"{System.Environment.NewLine}";
        }
    }
}