using Microsoft.AspNetCore.Mvc;

using System.Net;

using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Interfaces;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;

namespace Wake.Products.API.Controllers;
[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetById([FromRoute] Guid productId)
    {
        try
        {
            var foundProduct = await _productService.GetByIdAsync(productId);

            return StatusCode((int)HttpStatusCode.OK, foundProduct);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ExceptionMessages.HttpInternalServerError);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest createProductRequest)
    {
        try
        {
            var createdProduct = await _productService.CreateAsync(createProductRequest);

            return StatusCode((int)HttpStatusCode.OK, createdProduct);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ExceptionMessages.HttpInternalServerError);
        }
    }
}
