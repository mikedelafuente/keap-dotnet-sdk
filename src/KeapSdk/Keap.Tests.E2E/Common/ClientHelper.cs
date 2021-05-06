using Keap.Sdk;
using Keap.Sdk.Domain;
using System;
using System.Text.Json;

namespace Keap.Tests.E2E.Common
{
    public static class ClientHelper
    {
        /// <summary>
        /// Attempts to get credentials from the secret file location.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Returns null if the secret file does not exist or has issues deserializing</returns>
        public static AccessTokenCredentials GetCredentialsFromSecretFile(PersonaType persona)
        {
            var fullPath = System.IO.Path.GetFullPath($"./token_{persona.ToString()}.secret");
            try
            {
                if (System.IO.File.Exists(fullPath))
                {
                    var json = System.IO.File.ReadAllText(fullPath);

                    JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var credentials = JsonSerializer.Deserialize<AccessTokenCredentials>(json, options);
                    return credentials;
                }
            }
            catch (Exception ex)
            {
                Sdk.Logging.LogEventManager.Error(ex);
            }

            return null;
        }

        public static IKeapClient GetSdkClient(PersonaType persona, IRestApiClient restApiClient = null)
        {
            var accessTokens = GetCredentialsFromSecretFile(persona);
            if (accessTokens == null)
            {
                // TODO: Setup running selenium from the shared test library
                throw new NotImplementedException("Need to setup running Selenium from the shared library");
            }

            return Authentication.GetClientUsingAccessToken(accessTokens, PersistCredentialsToSecretFile, restApiClient);
        }

        public static void PersistCredentialsToSecretFile(AccessTokenCredentials accessTokenCredentials)
        {
            var fullPath = System.IO.Path.GetFullPath($"./token_{accessTokenCredentials.IntegratorUniqueIdentifier}.secret");

            JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented = true };
            var json = JsonSerializer.Serialize(accessTokenCredentials, options);

            System.IO.File.WriteAllText(fullPath, json);
        }
    }
}