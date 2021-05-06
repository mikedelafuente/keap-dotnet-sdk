namespace Keap.Sdk.Exceptions
{
    /// <summary>
    /// This exception is thrown when bad input is received.
    /// </summary>
    /// <seealso cref="Keap.Sdk.Exceptions.KeapException"/>
    public class KeapArgumentException : KeapException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapArgumentException"/> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapArgumentException(string paramName) : base($"Invalid parameter value: {paramName}")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeapArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapArgumentException(string paramName, string message) : base($"Invalid parameter value: {paramName}. Message: {message}")
        {
        }
    }

    /// <summary>
    /// This exception is thrown when bad input is received.
    /// </summary>
    /// <seealso cref="Keap.Sdk.Exceptions.KeapException"/>
    public class KeapNullOrWhitespaceArgumentException : KeapException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapArgumentException"/> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapNullOrWhitespaceArgumentException(string paramName) : base($"Null or whitespace/empty parameter value: {paramName}.")
        {
        }
    }
}