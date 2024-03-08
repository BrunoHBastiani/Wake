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

            return StatusCode((int)HttpStatusCode.Created, createdProduct);
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

    [HttpPut("{productId}")]
    public async Task<IActionResult> Update([FromRoute] Guid productId, [FromBody] UpdateProductRequest updateProductRequest)
    {
        try
        {
            var updatedProduct = await _productService.UpdateAsync(updateProductRequest, productId);

            return StatusCode((int)HttpStatusCode.OK, updatedProduct);
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

    [HttpDelete("{productId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid productId)
    {
        try
        {
            var deletedProduct = await _productService.DeleteAsync(productId);

            return StatusCode((int)HttpStatusCode.OK, deletedProduct);
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
