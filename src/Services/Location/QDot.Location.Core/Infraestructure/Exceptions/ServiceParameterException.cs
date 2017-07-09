using System;

namespace QDot.Location.Core.Infraestructure.Exceptions
{
    public class ServiceParameterException : Exception
    {
        public ServiceParameterException()
        {
        }

        public ServiceParameterException(string msg)
            : base(msg)
        {
        }

        public ServiceParameterException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
