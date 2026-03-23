using System;

namespace Increase.Api.Exceptions;

public class IncreaseInvalidDataException : IncreaseException
{
    public IncreaseInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
