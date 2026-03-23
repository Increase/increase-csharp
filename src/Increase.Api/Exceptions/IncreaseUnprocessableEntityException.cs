using System.Net.Http;

namespace Increase.Api.Exceptions;

public class IncreaseUnprocessableEntityException : Increase4xxException
{
    public IncreaseUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
