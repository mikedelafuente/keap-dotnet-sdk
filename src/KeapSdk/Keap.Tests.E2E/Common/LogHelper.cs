using Keap.Sdk.Logging;
using System;
using System.Diagnostics;

namespace Keap.Tests.E2E.Common
{
    public static class LogHelper
    {
        public static void HandleLogMessage(LogEventArgs args)
        {
            Debug.WriteLine($"{args.LogLevel}: {args.DateTime:O} : {args.Message}");

            if (args.Exception != null)
            {
                Debug.WriteLine("------------ EXCEPTION ------------");
                Debug.WriteLine(args.Exception.ToString());
                Debug.WriteLine("------------ END EXCEPTION ------------");
                Debug.WriteLine("");
            }
        }

        internal static void WriteSectionDividerToConsole(string description)
        {
            Debug.WriteLine($"{Environment.NewLine}--------------------");
            Debug.WriteLine(description);
            Debug.WriteLine($"--------------------{Environment.NewLine}");
        }
    }
}