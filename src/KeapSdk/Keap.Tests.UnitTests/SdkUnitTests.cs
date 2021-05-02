using Keap.Tests.Common;
using Microsoft.Extensions.Configuration;

namespace Keap.Tests.UnitTests
{
    public class SdkUnitTests
    {
        public IConfigurationRoot _config;

        public SdkUnitTests()
        {
            _config = ConfigurationHelper.GetConfiguration(System.Reflection.Assembly.GetAssembly(typeof(SdkUnitTests)));
        }
    }
}