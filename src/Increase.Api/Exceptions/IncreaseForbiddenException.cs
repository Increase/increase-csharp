using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseForbiddenException : Increase4xxException
{
    public IncreaseForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
