using System;
using System.Linq;

namespace Keap.Sdk.Clients
{
    internal static class Enum<T> where T : struct, IConvertible
    {
        public static string GetValuesAsCSV()
        {
            var values = Enum.GetNames(typeof(T)).ToList();
            if (values.Exists(s => s == "None"))
            {
                values.Remove("None");
            }

            return string.Join(",", values);
        }
    }
}