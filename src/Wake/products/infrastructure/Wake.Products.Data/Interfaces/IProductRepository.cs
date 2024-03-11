using Wake.Products.Data.Filters;
using Wake.Products.Domain.Entities;

namespace Wake.Products.Data.Interfaces;
public interface IProductRepository
{
    Task<List<Product>?> GetAsync(GetProductsFilter getProductsFilter);
    Task<Product?> GetByIdAsync(Guid productId);
    Task<Product?> GetActiveByIdAsync(Guid productId);
    Task<Product?> GetActiveByNameAsync(string name);
    Task<Product?> CreateAsync(Product product);
    Task<Product?> UpdateAsync(Product product);
}
