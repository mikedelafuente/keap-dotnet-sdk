using System;

namespace Keap.Tests.E2E.Common
{
    public class GivenAttribute : Attribute
    {
        public GivenAttribute(string condition)
        {
            Condition = condition;
        }

        public string Condition { get; set; }
    }
}