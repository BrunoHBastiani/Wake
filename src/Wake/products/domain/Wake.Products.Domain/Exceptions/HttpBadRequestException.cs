using System.Net;

namespace Wake.Products.Domain.Exceptions;
public sealed class HttpBadRequestException(string message) : HttpException(HttpStatusCode.BadRequest, message) { }
