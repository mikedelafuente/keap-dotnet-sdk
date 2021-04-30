using Keap.Sdk;
using Keap.Tests.UnitTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Keap.Tests.UnitTests
{
    [TestClass()]
    public static class AssemblySetupTeardown
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Console.WriteLine("CredentialFixture ctor: This should only be run once");
            EventHub.OnDebugMessage += LogHelper.HandleLogMessage;
            EventHub.OnErrorMessage += LogHelper.HandleLogMessage;
            EventHub.OnFatalMessage += LogHelper.HandleLogMessage;
            EventHub.OnInfoMessage += LogHelper.HandleLogMessage;
            EventHub.OnVerboseMessage += LogHelper.HandleLogMessage;
            EventHub.OnWarnMessage += LogHelper.HandleLogMessage;

        }


        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Executes once after the test run. (Optional)
            Console.WriteLine("CredentialFixture: Disposing CredentialFixture");
            EventHub.ClearListeners();
        }
    }
}
