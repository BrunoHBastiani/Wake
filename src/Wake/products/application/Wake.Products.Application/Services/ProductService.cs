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
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductsResponse> GetAsync(GetProductsRequest getProductRequest)
    {
        try
        {
            getProductRequest.Validate();

            var foundProducts = await _productRepository.GetAsync(getProductRequest.FromDTOToFilter()) ??
                throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);

            var productsToReturn = GetProductsResponse.FromProductsToDTO(foundProducts);

            return productsToReturn;
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

    public async Task<GetProductByIdResponse> GetByIdAsync(Guid productId)
    {
        try
        {
            var foundProduct = await _productRepository.GetByIdAsync(productId) ??
                throw new HttpBadRequestException(ExceptionMessages.ProductDoesNotExist);

            var productToReturn = GetProductByIdResponse.FromProductToDTO(foundProduct);

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
                createProductRequest.Price,
                createProductRequest.Quantity);

            var foundProduct = await _productRepository.GetActiveByNameAsync(productToCreate.Name);
            if (foundProduct is not null)
            {
                throw new HttpBadRequestException(ExceptionMessages.ProductAlreadyExists);
            }

            var createdProduct = await _productRepository.CreateAsync(productToCreate) ??
                throw new HttpInternalServerErrorException(ExceptionMessages.ProductNotCreated);

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

    public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest, Guid productId)
    {
        try
        {
            if (updateProductRequest.Name is not null)
            {
                var existingProduct = await _productRepository
                    .GetActiveByNameAsync(updateProductRequest.Name);

                if (existingProduct is not null)
                {
                    throw new HttpBadRequestException(ExceptionMessages.ProductAlreadyExists);
                }
            }

            var foundProduct = await _productRepository.GetActiveByIdAsync(productId) ??
                throw new HttpNotFoundException(ExceptionMessages.ProductDoesNotExist);

            foundProduct.Update(
                updateProductRequest.Name,
                updateProductRequest.Description,
                updateProductRequest.Price,
                updateProductRequest.Quantity);

            var updatedProduct = await _productRepository.UpdateAsync(foundProduct) ??
                throw new HttpInternalServerErrorException(ExceptionMessages.ProductNotUpdated);

            var productToReturn = UpdateProductResponse.FromProductToDTO(updatedProduct);

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

    public async Task<DeleteProductResponse> DeleteAsync(Guid productId)
    {
        try
        {
            var foundProduct = await _productRepository.GetActiveByIdAsync(productId) ??
                throw new HttpNotFoundException(ExceptionMessages.ProductDoesNotExist);

            foundProduct.Deactivate();

            var deletedProduct = await _productRepository.UpdateAsync(foundProduct) ??
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
