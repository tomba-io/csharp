using System;

namespace Tomba
{
    public class TombaException : Exception
    {
        public int? Code;
        public string Response = null;
        public TombaException(string message = null, int? code = null, string response = null)
        : base(message)
        {
            this.Code = code;
            this.Response = response;
        }
        public TombaException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}

