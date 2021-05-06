namespace Keap.Sdk.Exceptions
{
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