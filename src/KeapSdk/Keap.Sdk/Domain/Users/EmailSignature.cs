using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Domain.Users
{
    /// <summary>
    /// The HTML email signature for a user
    /// </summary>
    public class EmailSignature
    {
        /// <summary>
        /// The HTML snippet that contains the user's email signature
        /// </summary>
        public string HtmlSignature { get; set; }
    }
}