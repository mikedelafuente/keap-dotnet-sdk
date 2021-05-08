using System;

namespace Keap.Tests.E2E.Common
{
    public class ScenarioAttribute : TestDescriptionAttribute
    {
        public ScenarioAttribute(string description) : base(description)
        {
        }

        public override string ToString()
        {
            return "SCENARIO: " + Description;
        }
    }
}