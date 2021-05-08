using System;

namespace Keap.Tests.E2E.Common
{
    public class TestDescriptionAttribute : Attribute
    {
        public TestDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}