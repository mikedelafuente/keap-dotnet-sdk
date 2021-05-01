using System;

namespace Keap.Tests.Common
{
    public class WhenAttribute : Attribute
    {
        public string Action { get; set; }

        public WhenAttribute(string action)
        {
            Action = action;
        }
    }
}