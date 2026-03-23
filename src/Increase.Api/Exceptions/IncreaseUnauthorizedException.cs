using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseUnauthorizedException : Increase4xxException
{
    public IncreaseUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
