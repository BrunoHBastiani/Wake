using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Dtos.Responses;
using Wake.Products.Application.Interfaces;
using Wake.Products.Data.Interfaces;
using Wake.Products.Domain.Entities;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;

namespace Wake.Products.Application.Services;
public sealed class ProductService : IProductService
{
    private readonly IProductRepository _ProductRepository;

    public ProductService(IProductRepository productRepository)
    {
        _ProductRepository = productRepository;
    }

    public Task<GetProductsResponse> GetAsync(GetProductsRequet getProductRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<GetProductByIdResponse> GetByIdAsync(Guid productId)
    {
        try
        {
            var productFound = await _ProductRepository.GetByIdAsync(productId) ??
                throw new HttpBadRequestException(ExceptionMessages.ProductDoesNotExist);

            var productToReturn = GetProductByIdResponse.FromProductToDTO(productFound);

            return productToReturn;
        }
        catch (HttpException)
        {
            throw;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }

    public async Task<CreateProductResponse> CreateAsync(CreateProductRequest createProductRequest)
    {
        try
        {
            var productToCreate = new Product(
                createProductRequest.Name,
                createProductRequest.Description,
                createProductRequest.Price);

            var foundProduct = await _ProductRepository.GetActiveByNameAndPriceAsync(productToCreate);
            if (foundProduct is not null)
            {
                throw new HttpBadRequestException(ExceptionMessages.ProductAlreadyExists);
            }

            var createdProduct = await _ProductRepository.CreateAsync(productToCreate) ??
                throw new HttpInternalServerErrorException("");

            var productToReturn = CreateProductResponse.FromProductToDTO(createdProduct);

            return productToReturn;
        }
        catch (HttpException)
        {
            throw;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }

    public Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<DeleteProductResponse> DeleteAsync(Guid productId)
    {
        try
        {
            var foundProduct = await _ProductRepository.GetActiveByIdAsync(productId);
            if (foundProduct is null)
            {
                throw new HttpBadRequestException(ExceptionMessages.ProductDoesNotExist);
            }

            var deletedProduct = await _ProductRepository.DeleteAsync(foundProduct) ??
                throw new HttpInternalServerErrorException("");

            var productToReturn = DeleteProductResponse.FromProductToDTO(deletedProduct);

            return productToReturn;
        }
        catch (HttpException)
        {
            throw;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }
}
