using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseBadRequestException : Increase4xxException
{
    public IncreaseBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
