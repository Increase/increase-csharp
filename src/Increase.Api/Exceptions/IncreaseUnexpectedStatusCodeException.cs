using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseUnexpectedStatusCodeException : IncreaseApiException
{
    public IncreaseUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
