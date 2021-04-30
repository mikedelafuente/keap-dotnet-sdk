namespace Keap.Sdk.Logging
{
    /// <summary>
    /// The Log level. Used to route to specific events in the EventHub
    /// </summary>
    /// <seealso cref="https://stackoverflow.com/questions/16003568/why-logcat-does-not-print-the-message-when-startcommand-is-called-by-the-andro"/>
    public enum LogLevelType
    {
        /// <summary>
        /// Use this when you want to go absolutely nuts with your logging.
        /// If for some reason you've decided to log every little thing in a particular part of your app, use the Verbose tag.
        /// </summary>
        Verbose,

        /// <summary>
        /// Use this for debugging purposes.
        /// If you want to print out a bunch of messages so you can log the exact flow of your program, use this.
        /// If you want to keep a log of variable values, use this.
        /// </summary>
        Debug,

        /// <summary>
        /// Use this to post useful information to the log.
        /// For example: that you have successfully connected to a server.
        /// Basically use it to report successes.
        /// </summary>
        Info,

        /// <summary>
        /// Use this when you suspect something shady is going on.
        /// You may not be completely in full on error mode, but maybe you recovered from some unexpected behavior.
        /// Basically, use this to log stuff you didn't expect to happen but isn't necessarily an error.
        /// Kind of like a "hey, this happened, and it's weird, we should look into it."
        /// </summary>
        Warn,

        /// <summary>
        /// This is for when bad stuff happens.
        /// Use this tag in places like inside a catch statement.
        /// You know that an error has occurred and therefore you're logging an error.
        /// </summary>
        Error,

        /// <summary>
        /// What a Terrible Failure: Report a condition that should never happen.
        /// The error will always be logged at level Fatal/Failure with the call stack.
        /// Depending on system configuration, a report may be sent to the SDK developer and/or the process may be terminated immediately with an error dialog.
        /// </summary>
        Fatal
    }
}
