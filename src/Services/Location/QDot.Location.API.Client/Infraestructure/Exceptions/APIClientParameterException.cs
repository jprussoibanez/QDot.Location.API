using System;

namespace QDot.Location.API.Client.Infraestructure.Exceptions
{
    [Serializable]
    public class APIClientParameterException : QDotAPIClientException
    {
        public APIClientParameterException()
        {
        }

        public APIClientParameterException(string msg)
            : base(msg)
        {
        }

        public APIClientParameterException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
