using Microsoft.Extensions.Configuration;
using System;
using System.Web;

namespace Keap.Tests.E2E.Common
{
    public class E2ETests
    {
        public IConfigurationRoot _config;

        public E2ETests()
        {
            _config = ConfigurationHelper.GetConfiguration();
        }

        protected static string GetQueryStringValue(string url, string name)
        {
            var uri = new Uri(url);
            var parts = HttpUtility.ParseQueryString(uri.Query);
            return parts[name];
        }
    }
}