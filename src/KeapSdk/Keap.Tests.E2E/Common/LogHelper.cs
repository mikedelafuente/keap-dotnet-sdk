using Keap.Sdk.Logging;
using System.Diagnostics;

namespace Keap.Tests.E2E.Common
{
    public static class LogHelper
    {
        internal static void HandleLogMessage(LogEventArgs args)
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
    }
}