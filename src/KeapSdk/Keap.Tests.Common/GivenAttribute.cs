using System;

namespace Keap.Tests.Common
{
    public class GivenAttribute : Attribute
    {
        public string Condition { get; set; }

        public GivenAttribute(string condition)
        {
            Condition = condition;
        }
    }
}