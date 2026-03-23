using System.Net.Http;

namespace Increase.Api.Exceptions;

public class Increase4xxException : IncreaseApiException
{
    public Increase4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
