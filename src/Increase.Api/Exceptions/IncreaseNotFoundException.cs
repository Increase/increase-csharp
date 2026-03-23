using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseNotFoundException : Increase4xxException
{
    public IncreaseNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
