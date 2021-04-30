using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Common
{
    public class KeapException : Exception
    {
        
    }

    /// <summary>
    /// This exception is thrown when bad input is received
    /// </summary>
    public class KeapArgumentException : KeapException
    {

        /// <summary>
        /// Creates a new instance with a message
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapArgumentException(string paramName)
        {
            
        }

        /// <summary>
        /// Creates a new instance with a message and the expected parameter
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public KeapArgumentException(string message, string paramName)
        {
            
        }
    }
 

}
