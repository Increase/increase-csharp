using System;
using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseIOException : IncreaseException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public IncreaseIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
