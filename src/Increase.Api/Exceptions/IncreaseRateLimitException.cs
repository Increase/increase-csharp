using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseRateLimitException : Increase4xxException
{
    public IncreaseRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
