using Keap.Sdk;
using Keap.Tests.E2E.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Keap.Tests.E2E
{
    [TestClass()]
    public static class AssemblySetupTeardown
    {
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            LogHelper.WriteSectionDividerToConsole("ASSEMBLY CLEANUP");

            // Executes once after the test run. (Optional)
            Console.WriteLine("Clearing EventHub listeners");
            EventHub.ClearAllListeners();

            LogHelper.WriteSectionDividerToConsole("END ASSEMBLY CLEANUP");
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            LogHelper.WriteSectionDividerToConsole("ASSEMBLY INITIALIZE");

            Console.WriteLine("Setting up EventHub listeners");
            EventHub.OnDebugMessage += LogHelper.HandleLogMessage;
            EventHub.OnErrorMessage += LogHelper.HandleLogMessage;
            EventHub.OnFatalMessage += LogHelper.HandleLogMessage;
            EventHub.OnInfoMessage += LogHelper.HandleLogMessage;
            EventHub.OnVerboseMessage += LogHelper.HandleLogMessage;
            EventHub.OnWarnMessage += LogHelper.HandleLogMessage;

            DeleteAllContacts();

            LogHelper.WriteSectionDividerToConsole("END ASSEMBLY INITIALIZE");
        }

        private static void DeleteAllContacts()
        {
            var client = ClientHelper.GetSdkClient(PersonaType.Admin);

            var contacts = client.Contacts.GetContacts();
            while (!string.IsNullOrWhiteSpace(contacts.NextPageToken))
            {
                foreach (var contact in contacts.Items)
                {
                    client.Contacts.DeleteContact(contact.Id);
                }

                contacts = client.Contacts.GetContacts(contacts.NextPageToken);
            }
        }
    }
}