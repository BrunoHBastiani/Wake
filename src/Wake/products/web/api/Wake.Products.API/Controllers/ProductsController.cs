using Microsoft.AspNetCore.Mvc;

using System.Net;

using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Dtos.Responses;
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

    /// <summary>
    /// Retorna uma lista de produtos de acordo com os critérios especificados.
    /// </summary>
    /// <param name="getProductsRequest">Filtros de consulta para produtos.</param>
    /// <response code="200">Retorna uma lista de produtos.</response>
    /// <response code="204">Retorna uma resposta vazia quando nenhum produto é encontrado.</response>
    /// <response code="400">Se a solicitação não for válida.</response>
    /// <response code="500">Se ocorrer um erro interno no servidor.</response>
    [HttpGet()]
    [ProducesResponseType(typeof(GetProductsResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get([FromQuery] GetProductsRequest getProductsRequet)
    {
        try
        {
            var foundProducts = await _productService.GetAsync(getProductsRequet);

            if (foundProducts.Products is not null && !foundProducts.Products.Any())
                return StatusCode((int)HttpStatusCode.NoContent, foundProducts);

            return StatusCode((int)HttpStatusCode.OK, foundProducts);
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

    /// <summary>
    /// Retorna um produto com o ID especificado.
    /// </summary>
    /// <param name="productId">ID do produto a ser retornado.</param>
    /// <response code="200">Retorna o produto solicitado.</response>
    /// <response code="400">Se a solicitação não for válida.</response>
    /// <response code="404">Se o produto não for encontrado.</response>
    /// <response code="500">Se ocorrer um erro interno no servidor.</response>
    [HttpGet("{productId}")]
    [ProducesResponseType(typeof(GetProductByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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

    /// <summary>
    /// Cria um novo produto com base nos dados fornecidos.
    /// </summary>
    /// <param name="createProductRequest">Dados do produto a serem criados.</param>
    /// <response code="201">Retorna o produto recém-criado.</response>
    /// <response code="400">Se a solicitação não for válida.</response>
    /// <response code="500">Se ocorrer um erro interno no servidor.</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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

    /// <summary>
    /// Atualiza um produto existente com base nos dados fornecidos.
    /// </summary>
    /// <param name="productId">ID do produto a ser atualizado.</param>
    /// <param name="updateProductRequest">Dados do produto a serem atualizados.</param>
    /// <response code="200">Retorna o produto atualizado.</response>
    /// <response code="400">Se a solicitação não for válida.</response>
    /// <response code="404">Se o produto não for encontrado.</response>
    /// <response code="500">Se ocorrer um erro interno no servidor.</response>
    [HttpPut("{productId}")]
    [ProducesResponseType(typeof(UpdateProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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

    /// <summary>
    /// Exclui um produto com o ID especificado.
    /// </summary>
    /// <param name="productId">ID do produto a ser excluído.</param>
    /// <response code="200">Retorna o produto excluído.</response>
    /// <response code="400">Se a solicitação não for válida.</response>
    /// <response code="404">Se o produto não for encontrado.</response>
    /// <response code="500">Se ocorrer um erro interno no servidor.</response>
    [HttpDelete("{productId}")]
    [ProducesResponseType(typeof(DeleteProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
