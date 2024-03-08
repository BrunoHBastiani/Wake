using System.Net;

namespace Wake.Products.Domain.Exceptions;
public sealed class HttpNotFoundException(string message) : HttpException(HttpStatusCode.NotFound, message) { }
