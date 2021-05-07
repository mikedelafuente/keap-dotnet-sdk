using System;

namespace Keap.Tests.E2E.Common
{
    public class WhenAttribute : Attribute
    {
        public WhenAttribute(string action)
        {
            Action = action;
        }

        public string Action { get; set; }
    }
}