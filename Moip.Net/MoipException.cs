using System;
using System.Net;

namespace Moip.Net
{
    public class MoipException : Exception
    {
        public readonly HttpStatusCode StatusCode;
        public readonly ResponseError ResponseError;

        public MoipException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public MoipException(ResponseError responseError, HttpStatusCode statusCode) : this(responseError.Message, statusCode)
        {
            ResponseError = responseError;
        }
    }
}
