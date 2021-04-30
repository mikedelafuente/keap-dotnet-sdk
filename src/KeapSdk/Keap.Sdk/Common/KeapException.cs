using System;

namespace Keap.Sdk.Common
{
    public class KeapException : Exception
    {
        public KeapException(string message) : base(message)
        {
        }
    }
}