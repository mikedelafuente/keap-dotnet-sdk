using System;

namespace Keap.Tests.Common
{
    public class ThenAttribute : Attribute
    {
        public string Outcome { get; set; }

        public ThenAttribute(string outcome)
        {
            Outcome = outcome;
        }
    }
}