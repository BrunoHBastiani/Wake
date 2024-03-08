using System.Net;

namespace Wake.Products.Domain.Exceptions;
public class HttpException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}
