using Microsoft.Extensions.Configuration;
using System.IO;

namespace Keap.Tests.UnitTests.Common
{
    public static class ConfigurationHelper
    {
        private static IConfigurationRoot _configuration = null;
        private static object configLock = new object();

        public static IConfigurationRoot GetConfiguration()
        {
            if (_configuration == null)
            {
                lock (configLock)
                {
                    if (_configuration == null)
                    {
                        _configuration = BuildConfiguration();
                    }
                }
            }

            return _configuration;
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            builder.AddUserSecrets(System.Reflection.Assembly.GetAssembly(typeof(ConfigurationHelper)));

            var result = builder.Build();
            return result;
        }
    }
}