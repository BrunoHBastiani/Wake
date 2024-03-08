using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Dtos.Responses;
using Wake.Products.Application.Interfaces;

namespace Wake.Products.Application.Services;
public sealed class ProductService : IProductService
{
    public Task<GetProductsResponse> GetAsync(GetProductsRequet getProductRequest)
    {
        throw new NotImplementedException();
    }

    public Task<GetProductByIdResponse> GetByIdAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<CreateProductResponse> CreateAsync(CreateProductRequest createProductRequest)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteProductResponse> DeleteAsync(Guid productId)
    {
        throw new NotImplementedException();
    }
}
