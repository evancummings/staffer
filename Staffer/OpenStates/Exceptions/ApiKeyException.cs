using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffer.OpenStates.Exceptions
{
    public class MissingApiKeyException : Exception
    {
        public override string Message
        {
            get { return "No API was provided. Register for an API key at http://sunlightfoundation.com/api/"; }
        }
    }
}
