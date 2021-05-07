using System;

namespace Keap.Sdk.Logging
{
    internal static class LogEventManager
    {
        #region Methods

        /// <summary>
        /// Publish a debug message to the EventHub. Used for debugging purposes. If you want to
        /// print out a bunch of messages so you can log the exact flow of your program, use this.
        /// If you want to keep a log of variable values, use this.
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        public static void Debug(string message)
        {
            Publish(message, LogLevelType.Debug);
        }

        /// <summary>
        /// Publish a error message to the EventHub. This is for when bad stuff happens. Use this
        /// tag in places like inside a catch statement. You know that an error has occurred and
        /// therefore you're logging an error.
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        public static void Error(string message)
        {
            Publish(message, LogLevelType.Error);
        }

        /// <summary>
        /// Publish a error message to the EventHub. This is for when bad stuff happens. Use this
        /// tag in places like inside a catch statement. You know that an error has occurred and
        /// therefore you're logging an error.
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        public static void Error(string message, Exception ex)
        {
            Publish(message, ex, LogLevelType.Error);
        }

        /// <summary>
        /// Publish a error message to the EventHub. This is for when bad stuff happens. Use this
        /// tag in places like inside a catch statement. You know that an error has occurred and
        /// therefore you're logging an error.
        /// </summary>
        public static void Error(Exception ex)
        {
            Publish(ex.Message, ex, LogLevelType.Error);
        }

        /// <summary>
        /// Publish a error message to the EventHub and then throws the passed in exception (you
        /// stack trace will be inacurate). This is for when bad stuff happens. Use this tag in
        /// places like inside a catch statement. You know that an error has occurred and therefore
        /// you're logging an error.
        /// </summary>
        public static void ErrorAndThrow(Exception ex)
        {
            Publish(ex.Message, ex, LogLevelType.Error);
            throw ex;
        }

        /// <summary>
        ///     Publish a error message to the EventHub and then throws the passed in exception (you stack trace will be inacurate).
        ///     This is for when bad stuff happens.
        ///     Use this tag in places like inside a catch statement.
        ///     You know that an error has occurred and therefore you're logging an error.
        /// </summary>
        ///<param name="message">Message to be communicated to the integrator</param>
        public static void ErrorAndThrow(string message, Exception ex)
        {
            Publish(message, ex, LogLevelType.Error);
            throw ex;
        }

        /// <summary>
        ///     Publish a error message to the EventHub and then throws the passed in exception (you stack trace will be inacurate).
        ///     This is for when bad stuff happens.
        ///     Use this tag in places like inside a catch statement.
        ///     You know that an error has occurred and therefore you're logging an error.
        /// </summary>
        ///<param name="message">Message to be communicated to the integrator</param>
        public static void ErrorAndThrow(string message)
        {
            Publish(message, LogLevelType.Error);
            throw new Exceptions.KeapException(message);
        }

        /// <summary>
        ///     Publish a fatal message.
        ///     What a Terrible Failure: Report a condition that should never happen.
        ///     The error will always be logged at level Fatal/Failure with the call stack.
        ///     Depending on system configuration, a report may be sent to the SDK developer and/or the process may be terminated immediately with an error dialog.
        /// </summary>
        ///<param name="message">Message to be communicated to the integrator</param>
        public static void Fatal(string message)
        {
            Publish(message, LogLevelType.Fatal);
        }

        /// <summary>
        ///     Publish a fatal message.
        ///     What a Terrible Failure: Report a condition that should never happen.
        ///     The error will always be logged at level Fatal/Failure with the call stack.
        ///     Depending on system configuration, a report may be sent to the SDK developer and/or the process may be terminated immediately with an error dialog.
        /// </summary>
        ///<param name="message">Message to be communicated to the integrator</param>
        public static void Fatal(string message, Exception ex)
        {
            Publish(message, ex, LogLevelType.Fatal);
        }

        /// <summary>
        /// Publish a fatal message. What a Terrible Failure: Report a condition that should never
        /// happen. The error will always be logged at level Fatal/Failure with the call stack.
        /// Depending on system configuration, a report may be sent to the SDK developer and/or the
        /// process may be terminated immediately with an error dialog.
        /// </summary>
        public static void Fatal(Exception ex)
        {
            Publish(ex.Message, ex, LogLevelType.Fatal);
        }

        /// <summary>
        /// Publish a info message to the EventHub. Use this to post useful information to the log.
        /// Basically use it to report successes. For example, when you have successfully connected
        /// to a server.
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        public static void Info(string message)
        {
            Publish(message, LogLevelType.Info);
        }

        /// <summary>
        /// Returns true if an event is wired up the specified log level
        /// </summary>
        /// <param name="logLevel">
        /// Typically used to route to specific events in the EventHub, such as OnError, OnFatal, etc.
        /// </param>
        /// <returns></returns>
        public static bool IsListening(LogLevelType logLevel)
        {
            return EventHub.IsListening(logLevel);
        }

        /// <summary>
        /// Publish a verbose message which is used when you want to go absolutely nuts with your
        /// logging. If for some reason you've decided to log every little thing in a particular
        /// part of your app, use the Verbose tag.
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        public static void Verbose(string message)
        {
            Publish(message, LogLevelType.Verbose);
        }

        /// <summary>
        /// Publish a warn message to the EventHub. Use this when you suspect something shady is
        /// going on. You may not be completely in full on error mode, but maybe you recovered from
        /// some unexpected behavior. Basically, use this to log stuff you didn't expect to happen
        /// but isn't necessarily an error. Kind of like a "hey, this happened, and it's weird, we
        /// should look into it."
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        public static void Warn(string message)
        {
            Publish(message, LogLevelType.Warn);
        }

        /// <summary>
        /// Publishes a message with a given log level to the EventHub
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        /// <param name="logLevel">
        /// The log level which determines the event that is fired of (OnDebug, OnWarn, etc.)
        /// </param>
        private static void Publish(string message, LogLevelType logLevel)
        {
            Publish(message, null, logLevel);
        }

        /// <summary>
        /// Publishes a message and exception with a given log level to the EventHub
        /// </summary>
        /// <param name="message">Message to be communicated to the integrator</param>
        /// <param name="logLevel">
        /// The log level which determines the event that is fired of (OnDebug, OnWarn, etc.)
        /// </param>
        /// <param name="ex">The exception to be published</param>
        private static void Publish(string message, Exception ex, LogLevelType logLevel)
        {
            if (EventHub.IsListening(logLevel))
            {
                EventHub.RaiseException(new LogEventArgs(message, ex, logLevel));
            }
        }

        #endregion Methods
    }
}