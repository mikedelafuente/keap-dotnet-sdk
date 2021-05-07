using System;

namespace Keap.Tests.E2E.Common
{
    public class ScenarioAttribute : Attribute
    {
        public ScenarioAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}