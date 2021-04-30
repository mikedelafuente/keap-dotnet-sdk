using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keap.Sdk.Common
{
    public class KeapException : Exception
    {
        public KeapException(string message) : base(message)
        {

        }
    }


}
