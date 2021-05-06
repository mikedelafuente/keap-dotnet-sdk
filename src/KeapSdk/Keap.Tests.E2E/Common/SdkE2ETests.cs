using Microsoft.Extensions.Configuration;

namespace Keap.Tests.E2E.Common
{
    public class SdkE2ETests
    {
        public IConfigurationRoot _config;

        public SdkE2ETests()
        {
            _config = ConfigurationHelper.GetConfiguration(System.Reflection.Assembly.GetAssembly(typeof(SdkE2ETests)));
        }
    }
}