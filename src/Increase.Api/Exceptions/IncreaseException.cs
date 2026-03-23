using System;
using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseException : Exception
{
    public IncreaseException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected IncreaseException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
