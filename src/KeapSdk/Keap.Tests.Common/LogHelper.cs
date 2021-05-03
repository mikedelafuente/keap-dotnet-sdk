using Keap.Sdk.Logging;
using System.Diagnostics;

namespace Keap.Tests.Common
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
    }
}