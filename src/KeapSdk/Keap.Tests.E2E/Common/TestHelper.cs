using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Keap.Tests.E2E.Common
{
    public static class TestHelper
    {
        public static T Clone<T>(this T source) where T : class
        {
            var serialized = JsonSerializer.Serialize(source);
            return JsonSerializer.Deserialize<T>(serialized);
        }

        public static double GetRandomDouble(int min, int max)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            return rnd.Next(min, max) + rnd.NextDouble();
        }

        public static DateTime GetRandomPastDate(int minInPast, int maxInPast)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            return DateTime.UtcNow.AddDays(rnd.Next(minInPast, maxInPast) * -1);
        }

        public static long ToUnixTimeSeconds(this DateTime dateTime)
        {
            return (long)dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }
    }
}