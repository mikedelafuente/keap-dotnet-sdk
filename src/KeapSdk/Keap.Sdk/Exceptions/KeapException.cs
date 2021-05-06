using System;

namespace Keap.Sdk.Exceptions
{
    /// <summary>
    /// All exceptions thrown by the SDK will be of type Keap.Sdk.Exceptions.KeapException
    /// </summary>
    /// <seealso cref="System.Exception"/>
    public class KeapException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public KeapException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeapException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference ( <see
        /// langword="Nothing"/> in Visual Basic) if no inner exception is specified.
        /// </param>
        public KeapException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// This exception is returned when a over license limit is hit.
    /// </summary>
    public class KeapLicenseException : KeapException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public KeapLicenseException(string message) : base(message)
        {
        }
    }
}