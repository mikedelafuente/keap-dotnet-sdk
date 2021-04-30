using Keap.Sdk;

namespace Keap.Tests.UnitTests.Common
{
    internal static class ClientHelper
    {
        internal static string GetServerAddress()
        {
            var serverAddress = ConfigurationHelper.GetConfiguration()["ServerAddress"];
            return serverAddress;
        }

        internal static string GetTestApplicationName()
        {
            var appName = ConfigurationHelper.GetConfiguration()["TestApplicationName"];
            return appName;
        }

        internal static KeapClient GetSdkClient()
        {
            return Authentication.GetClientUsingOAuth2("validClientId", "validClientSecret", GetTestApplicationName(), GetServerAddress());
        }
    }
}