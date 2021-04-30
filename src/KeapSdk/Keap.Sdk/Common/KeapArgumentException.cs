namespace Keap.Sdk.Common
{
    /// <summary>
    /// This exception is thrown when bad input is received
    /// </summary>
    public class KeapArgumentException : KeapException
    {

        /// <summary>
        /// Creates a new instance with a message
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapArgumentException(string paramName) : base($"Invalid parameter value: {paramName}")
        {
            
        }

        /// <summary>
        /// Creates a new instance with a message and the expected parameter
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapArgumentException(string message, string paramName) : base($"Invalid parameter value: {paramName}. Message: {message}")
        {

        }
    }


}
