﻿using System.Net.Http;
using System.Text.Json;

namespace Keap.Sdk.Domain.Clients
{
    internal static class RestHelper
    {
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
            throw new Exceptions.KeapException("There was an unsuccesful status code returned.", new HttpRequestException(serverResponse.ReasonPhrase, null, serverResponse.StatusCode));
        }
    }
}