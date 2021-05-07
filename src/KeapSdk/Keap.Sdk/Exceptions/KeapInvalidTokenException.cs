namespace Keap.Sdk.Exceptions
{
    /// <summary>
    /// This exception is thrown when an expired refresh token is detected.
    /// </summary>
    /// <seealso cref="Keap.Sdk.Exceptions.KeapException"/>
    public class KeapExpiredRefreshTokenException : KeapException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapExpiredRefreshTokenException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public KeapExpiredRefreshTokenException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// This exception is thrown when an invalid token is detected. Typically, this occurrs when not
    /// all required properties are populated.
    /// </summary>
    /// <seealso cref="Keap.Sdk.Exceptions.KeapException"/>
    public class KeapInvalidTokenException : KeapException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapInvalidTokenException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public KeapInvalidTokenException(string message) : base(message)
        {
        }
    }
}