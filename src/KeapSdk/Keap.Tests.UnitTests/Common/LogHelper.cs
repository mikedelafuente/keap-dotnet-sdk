using Keap.Sdk.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Tests.UnitTests.Common
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
