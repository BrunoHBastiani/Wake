using System.Net;

namespace Wake.Products.Domain.Exceptions;
public sealed class HttpInternalServerErrorException(string message) : HttpException(HttpStatusCode.InternalServerError, message) { }
