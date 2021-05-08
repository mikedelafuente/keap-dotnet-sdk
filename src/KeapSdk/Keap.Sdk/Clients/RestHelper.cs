using Keap.Sdk.Clients.Common;
using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using System.Collections.Generic;
using Keap.Sdk.Logging;

namespace Keap.Sdk.Domain.Clients
{
    internal static class RestHelper
    {
        private static JsonSerializerSettings serializerOptions = new JsonSerializerSettings() { Formatting = Formatting.Indented };

        public static string AttemptToGetErrorMessage(ServerResponse serverResponse)
        {
            string message = string.Empty;
            if (serverResponse.ResponseBody.Contains("{") && serverResponse.ResponseBody.Contains("\"message\""))
            {
                var messageDto = JsonConvert.DeserializeObject<ServerErrorMessageDto>(serverResponse.ResponseBody, serializerOptions);
                if (messageDto != null)
                {
                    message = messageDto.Message;
                }
            }

            return message;
        }

        /// <summary>
        /// Removes any leading question mark or trailing ampersand
        /// </summary>
        /// <param name="value">Value to cleanup</param>
        /// <returns></returns>
        public static string CleanupQueryString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (value.StartsWith("?"))
            {
                if (value.Length > 1)
                {
                    // Changes '?param1=val1&param2=val2&' to 'param1=val1&param2=val2&'
                    value = value.Substring(1);
                }
                else
                {
                    // Changes '?' to ''
                    value = string.Empty;
                }
            }

            if (value.EndsWith("&"))
            {
                // Changes 'param1=val1&param2=val2&' to 'param1=val1&param2=val2&'
                if (value.Length > 1)
                {
                    value = value.Substring(0, value.Length - 1);
                }
                else
                {
                    // Changes '&' to ''
                    value = string.Empty;
                }
            }

            return value;
        }

        /// <summary>
        /// Cleans up the path by removing any unused/empty query string parts
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static string CleanupPathAndQueryString(string path)
        {
            LogEventManager.Info($"Cleaning up URL and query string for: {path}");
            var workingPath = path;
            if (!workingPath.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                workingPath = "http://localhost/" + workingPath;
            }
            else
            {
                // Do not cleanup anything that has a host on it
                return path;
            }

            var uri = new Uri(workingPath);
            var absolutePath = uri.AbsolutePath;
            if (absolutePath.StartsWith("/"))
            {
                absolutePath = absolutePath.Substring(1);
            }

            string queryString = string.Empty;
            if (!string.IsNullOrWhiteSpace(uri.Query))
            {
                queryString = RemoveEmptyQueryStringParameters(uri.Query);
            }

            if (!string.IsNullOrWhiteSpace(queryString))
            {
                path = absolutePath + "?" + queryString;
            }
            else
            {
                path = absolutePath;
            }

            return path;
        }

        internal static System.Collections.Specialized.NameValueCollection ConvertPageTokenToNameValueCollection(string nextPageToken)
        {
            var queryString = ExtractQueryStringFromPageToken(nextPageToken);
            var nvp = System.Web.HttpUtility.ParseQueryString(queryString);
            return nvp;
        }

        internal static string ExtractQueryStringFromPageToken(string nextPageToken)
        {
            if (string.IsNullOrWhiteSpace(nextPageToken))
            {
                return string.Empty;
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(nextPageToken));
        }

        internal static T ProcessResults<T>(ServerResponse serverResponse)
        {
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(serverResponse.ResponseBody, serializerOptions);
                return result;
            }

            ProcessResultsForErrors(serverResponse);

            return default(T);
        }

        internal static void ProcessResultsForErrors(ServerResponse serverResponse)
        {
            if (serverResponse.IsSuccessStatusCode)
            {
                return;
            }

            int statusCode = (int)serverResponse.StatusCode;
            var errorMessage = AttemptToGetErrorMessage(serverResponse);
            if (!String.IsNullOrWhiteSpace(errorMessage))
            {
                var ex = new Exceptions.KeapHttpRequestException(errorMessage, serverResponse.StatusCode, new HttpRequestException(GenerateHttpExceptionReason(serverResponse), null, serverResponse.StatusCode));
                if (statusCode < 200 || (statusCode >= 300 && statusCode < 400) || statusCode >= 500)
                {
                    LogEventManager.Error(ex);
                }
                else
                {
                    LogEventManager.Info(GenerateHttpExceptionReason(serverResponse));
                }
            }

            // only throw if the status code is not in a 2xx or 4xx code
            if (statusCode < 200 || (statusCode >= 300 && statusCode < 400) || statusCode >= 500)
            {
                throw new Exceptions.KeapException(GenerateHttpExceptionReason(serverResponse),
               new HttpRequestException(serverResponse.ReasonPhrase, null, serverResponse.StatusCode));
            }
        }

        /// <summary>
        /// Removes any empty key/value pairs from the query string
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        internal static string RemoveEmptyQueryStringParameters(string queryString)
        {
            string result = CleanupQueryString(queryString);

            if (!string.IsNullOrWhiteSpace(queryString))
            {
                var originalNvc = HttpUtility.ParseQueryString(queryString);
                var keysToRemove = new List<string>();
                foreach (var key in originalNvc.Keys)
                {
                    var name = (string)key;
                    var value = originalNvc[name];
                    if (value != null)
                    {
                        var stringValue = (string)value;
                        if (string.IsNullOrWhiteSpace(stringValue))
                        {
                            keysToRemove.Add(name);
                        }
                    }
                    else
                    {
                        keysToRemove.Add(name);
                    }
                }

                foreach (var name in keysToRemove)
                {
                    originalNvc.Remove(name);
                }

                result = originalNvc.ToString();
            }

            return result;
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