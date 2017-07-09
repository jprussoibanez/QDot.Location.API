using System;

namespace QDot.Location.API.Client.Infraestructure.Exceptions
{
    [Serializable]
    public class QDotAPIClientException : Exception
    {
        public QDotAPIClientException()
        {
        }

        public QDotAPIClientException(string msg)
            : base(msg)
        {
        }

        public QDotAPIClientException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
