using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace Keap.Tests.E2E.Common
{
    [TestClass]
    public class SdkE2ETests
    {
        public IConfigurationRoot _config;

        public SdkE2ETests()
        {
            _config = ConfigurationHelper.GetConfiguration(System.Reflection.Assembly.GetAssembly(typeof(SdkE2ETests)));
        }

        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void TestInit()
        {
            string theClassName = TestContext.FullyQualifiedTestClassName;
            string testName = TestContext.TestName;

            // NOTE: You might have to use AppDomain.CurrentDomain.GetAssemblies() and then call
            // GetTypes on each assembly if this code resides in a baseclass in another assembly.
            var currentlyRunningClassType = this.GetType().Assembly.GetTypes().FirstOrDefault(f => f.FullName == theClassName);
            var currentlyRunningMethod = currentlyRunningClassType.GetMethod(testName);
            // Replace WorkItemAttribute with whatever your attribute is called...
            Debug.WriteLine($"{Environment.NewLine}--------------------");
            Debug.WriteLine(GetAttributeValue(currentlyRunningMethod, typeof(ScenarioAttribute)));
            Debug.WriteLine(GetAttributeValue(currentlyRunningMethod, typeof(GivenAttribute)));
            Debug.WriteLine(GetAttributeValue(currentlyRunningMethod, typeof(WhenAttribute)));
            Debug.WriteLine(GetAttributeValue(currentlyRunningMethod, typeof(ThenAttribute)));
            Debug.WriteLine($"--------------------{Environment.NewLine}");
        }

        private static string GetAttributeValue(System.Reflection.MethodInfo currentlyRunningMethod, System.Type attributeType)
        {
            string result = string.Empty;
            var scenarioAttribute = currentlyRunningMethod.GetCustomAttributes(attributeType, true) as System.Collections.Generic.IEnumerable<TestDescriptionAttribute>;
            var firstOne = scenarioAttribute.FirstOrDefault();
            if (firstOne != null)
            {
                result = firstOne.ToString();
            }

            return result;
        }
    }
}