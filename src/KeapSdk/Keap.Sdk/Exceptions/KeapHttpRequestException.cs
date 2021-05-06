using System.Net;
using System.Net.Http;

namespace Keap.Sdk.Exceptions
{
    /// <summary>
    /// An exception that will contain an inner exception of type <see cref="System.Net.Http.HttpRequestException"/>
    /// </summary>
    /// <seealso cref="Keap.Sdk.Exceptions.KeapException"/>
    public class KeapHttpRequestException : KeapException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeapHttpRequestException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public KeapHttpRequestException(string message, HttpStatusCode statusCode, HttpRequestException innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}