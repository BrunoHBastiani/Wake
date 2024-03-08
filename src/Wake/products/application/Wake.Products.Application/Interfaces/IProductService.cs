using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Dtos.Responses;

namespace Wake.Products.Application.Interfaces;
public interface IProductService
{
    Task<GetProductsResponse> GetAsync(GetProductsRequet getProductRequest);
    Task<GetProductByIdResponse> GetByIdAsync(Guid productId);
    Task<CreateProductResponse> CreateAsync(CreateProductRequest createProductRequest);
    Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest);
    Task<DeleteProductResponse> DeleteAsync(Guid productId);
}
