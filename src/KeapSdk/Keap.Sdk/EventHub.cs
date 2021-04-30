using Keap.Sdk.Logging;
using System;
using System.Diagnostics;

namespace Keap.Sdk
{
    /// <summary>
    /// The EventHub allows you to attach to events firing from different parts of the SDK. This includes from the Utilities.LogsEventManager
    /// </summary>
    public static class EventHub
    {
        /// <summary>
        /// Use this for debugging purposes.
        /// If you want to print out a bunch of messages so you can log the exact flow of your program, use this.
        /// If you want to keep a log of variable values, use this.
        /// </summary>
        public static event LogEventHandler OnDebugMessage;

        /// <summary>
        /// This is for when bad stuff happens.
        /// Use this tag in places like inside a catch statement.
        /// You know that an error has occurred and therefore you're logging an error.
        /// </summary>
        public static event LogEventHandler OnErrorMessage;

        /// <summary>
        /// What a Terrible Failure: Report a condition that should never happen.
        /// The error will always be logged at level Fatal/Failure with the call stack.
        /// Depending on system configuration, a report may be sent to the SDK developer and/or the process may be terminated immediately with an error dialog.
        /// </summary>
        public static event LogEventHandler OnFatalMessage;

        /// <summary>
        /// Use this to post useful information to the log.
        /// For example: that you have successfully connected to a server.
        /// Basically use it to report successes.
        /// </summary>
        public static event LogEventHandler OnInfoMessage;

        /// <summary>
        /// Use this when you want to go absolutely nuts with your logging.
        /// If for some reason you've decided to log every little thing in a particular part of your app, use the Verbose tag.
        /// </summary>
        public static event LogEventHandler OnVerboseMessage;

        /// <summary>
        /// Use this when you suspect something shady is going on.
        /// You may not be completely in full on error mode, but maybe you recovered from some unexpected behavior.
        /// Basically, use this to log stuff you didn't expect to happen but isn't necessarily an error.
        /// Kind of like a "hey, this happened, and it's weird, we should look into it."
        /// </summary>
        public static event LogEventHandler OnWarnMessage;

        /// <summary>
        ///     If set to true, wired message events ignored when raised. All other events will still raise.
        /// </summary>
        public static bool MuteMessages { get; set; }

        /// <summary>
        /// Clears the listeners that may be attached to the events. Typically used for testing.
        /// </summary>
        public static void ClearListeners()
        {

            try
            {
                if (OnDebugMessage != null)
                {
                    foreach (Delegate invoker in OnDebugMessage.GetInvocationList())
                    {
                        OnDebugMessage -= (LogEventHandler)invoker;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                if (OnErrorMessage != null)
                {
                    foreach (Delegate invoker in OnErrorMessage.GetInvocationList())
                    {
                        OnErrorMessage -= (LogEventHandler)invoker;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                if (OnFatalMessage != null)
                {
                    foreach (Delegate invoker in OnFatalMessage.GetInvocationList())
                    {
                        OnFatalMessage -= (LogEventHandler)invoker;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                if (OnInfoMessage != null)
                {
                    foreach (Delegate invoker in OnInfoMessage.GetInvocationList())
                    {
                        OnInfoMessage -= (LogEventHandler)invoker;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                if (OnVerboseMessage != null)
                {
                    foreach (Delegate invoker in OnVerboseMessage.GetInvocationList())
                    {
                        OnVerboseMessage -= (LogEventHandler)invoker;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                if (OnWarnMessage != null)
                {
                    foreach (Delegate invoker in OnWarnMessage.GetInvocationList())
                    {
                        OnWarnMessage -= (LogEventHandler)invoker;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// Determines whether the specified log level has a listener.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns>
        ///   <c>true</c> if the specified log level is listening; otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsListening(LogLevelType logLevel)
        {
            if (MuteMessages)
            {
                return false;
            }

            bool listening = false;

            switch (logLevel)
            {
                case LogLevelType.Verbose:
                    if (OnVerboseMessage != null)
                    {
                        listening = true;
                    }

                    break;

                case LogLevelType.Debug:
                    if (OnDebugMessage != null)
                    {
                        listening = true;
                    }

                    break;

                case LogLevelType.Info:
                    if (OnInfoMessage != null)
                    {
                        listening = true;
                    }

                    break;

                case LogLevelType.Warn:
                    if (OnWarnMessage != null)
                    {
                        listening = true;
                    }

                    break;

                case LogLevelType.Error:
                    if (OnErrorMessage != null)
                    {
                        listening = true;
                    }

                    break;

                case LogLevelType.Fatal:
                    if (OnFatalMessage != null)
                    {
                        listening = true;
                    }

                    break;
            }

            return listening;
        }


        /// <summary>
        /// Inspects the log level of the event data and triggers the corresponding event if there is a listener.
        /// </summary>
        /// <param name="e">The <see cref="LogEventArgs"/> instance containing the event data.</param>
        internal static void RaiseException(LogEventArgs e)
        {
            if (MuteMessages)
            {
                return;
            }

            if (e != null)
            {
                switch (e.LogLevel)
                {
                    case LogLevelType.Verbose:
                        OnVerboseMessage?.Invoke(e);

                        break;

                    case LogLevelType.Debug:
                        OnDebugMessage?.Invoke(e);

                        break;

                    case LogLevelType.Info:
                        OnInfoMessage?.Invoke(e);

                        break;

                    case LogLevelType.Warn:
                        OnWarnMessage?.Invoke(e);

                        break;

                    case LogLevelType.Error:
                        OnErrorMessage?.Invoke(e);

                        break;

                    case LogLevelType.Fatal:
                        OnFatalMessage?.Invoke(e);

                        break;
                }
            }
        }


    }
}
