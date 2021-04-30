using System;

namespace Keap.Sdk.Logging
{
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="logLevel">The severity of the message.</param>
        public LogEventArgs(string message, Exception ex, LogLevelType logLevel)
        {
            Exception = ex;
            Message = message;
            LogLevel = logLevel;
            DateTime = DateTimeOffset.UtcNow;
        }

        /// <summary>
        ///     The date time that the event fired
        /// </summary>
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     The exception that may have been raised
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        ///     The log level of the message
        /// </summary>
        public LogLevelType LogLevel { get; set; }

        /// <summary>
        ///     The message
        /// </summary>
        public string Message { get; set; }
    }
}
