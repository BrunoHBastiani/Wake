using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Dtos.Responses;

namespace Wake.Products.Application.Interfaces;
public interface IProductService
{
    Task<GetProductsResponse> GetAsync(GetProductsRequest getProductRequest);
    Task<GetProductByIdResponse> GetByIdAsync(Guid productId);
    Task<CreateProductResponse> CreateAsync(CreateProductRequest createProductRequest);
    Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest, Guid productId);
    Task<DeleteProductResponse> DeleteAsync(Guid productId);
}
