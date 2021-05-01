using System;

namespace Keap.Tests.Common
{
    public class ScenarioAttribute : Attribute
    {
        public string Description { get; set; }

        public ScenarioAttribute(string description)
        {
            Description = description;
        }
    }
}