using System.Net.Http;

namespace Increase.Api.Exceptions;

public class Increase5xxException : IncreaseApiException
{
    public Increase5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
