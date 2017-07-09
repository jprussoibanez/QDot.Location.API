using System;
using System.Collections.Generic;
using System.Text;

namespace QDot.Location.Core.Infraestructure.Exceptions
{
    public class LocationNotFoundException : Exception
    {
        public LocationNotFoundException()
        {
        }

        public LocationNotFoundException(string msg)
            : base(msg)
        {
        }

        public LocationNotFoundException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
