using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Keap.Tests.E2E.Common
{
    public static class ConfigurationHelper
    {
        private static object _configLock = new object();
        private static ConcurrentDictionary<string, IConfigurationRoot> _configurationDictionary = new ConcurrentDictionary<string, IConfigurationRoot>();

        public static void ClearCachedConfiguration(Assembly callingAssembly)
        {
            Debug.WriteLine("Clearing cached configuration");

            string key = GetKeyName(callingAssembly);

            if (_configurationDictionary.ContainsKey(key))
            {
                lock (_configLock)
                {
                    if (_configurationDictionary.ContainsKey(key))
                    {
                        _configurationDictionary.TryRemove(key, out _);
                    }
                }
            }
        }

        public static IConfigurationRoot GetConfiguration(Assembly callingAssembly)
        {
            Debug.WriteLine("Getting cached configuration");
            string key = GetKeyName(callingAssembly);

            if (_configurationDictionary.ContainsKey(key) == false)
            {
                lock (_configLock)
                {
                    if (_configurationDictionary.ContainsKey(key) == false)
                    {
                        var config = BuildConfiguration(callingAssembly);
                        _configurationDictionary.TryAdd(key, config);
                    }
                }
            }

            return _configurationDictionary[key];
        }

        private static IConfigurationRoot BuildConfiguration(Assembly callingAssembly)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            builder.AddUserSecrets(callingAssembly);

            var result = builder.Build();
            return result;
        }

        private static string GetKeyName(Assembly callingAssembly)
        {
            string key = "Unknown";

            var userSecretAttribute = callingAssembly.GetCustomAttribute<Microsoft.Extensions.Configuration.UserSecrets.UserSecretsIdAttribute>();
            if (userSecretAttribute != null)
            {
                key = userSecretAttribute.UserSecretsId;
            }
            else
            {
                key = callingAssembly.ManifestModule.Name;
            }

            return key;
        }
    }
}