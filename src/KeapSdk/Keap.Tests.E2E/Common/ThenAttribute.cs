using System;

namespace Keap.Tests.E2E.Common
{
    public class ThenAttribute : Attribute
    {
        public ThenAttribute(string outcome)
        {
            Outcome = outcome;
        }

        public string Outcome { get; set; }
    }
}