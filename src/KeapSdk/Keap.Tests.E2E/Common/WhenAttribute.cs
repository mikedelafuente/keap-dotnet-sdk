using System;

namespace Keap.Tests.E2E.Common
{
    public class WhenAttribute : TestDescriptionAttribute
    {
        public WhenAttribute(string action) : base(action)
        {
        }

        public override string ToString()
        {
            return "WHEN " + Description;
        }
    }
}