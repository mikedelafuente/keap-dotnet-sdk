using System;

namespace Keap.Sdk.Exceptions
{
    [Serializable]
    internal class KeapInvalidOAuth2CodeException : KeapException
    {
        public KeapInvalidOAuth2CodeException(string message) : base(message)
        {
        }

        public KeapInvalidOAuth2CodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}