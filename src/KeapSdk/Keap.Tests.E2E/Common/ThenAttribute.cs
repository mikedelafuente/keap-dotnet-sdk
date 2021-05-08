using System;

namespace Keap.Tests.E2E.Common
{
    public class ThenAttribute : TestDescriptionAttribute
    {
        public ThenAttribute(string outcome) : base(outcome)
        {
        }

        public override string ToString()
        {
            return "THEN " + Description;
        }
    }
}