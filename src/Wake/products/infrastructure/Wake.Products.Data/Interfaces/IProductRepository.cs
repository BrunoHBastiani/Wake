using Wake.Products.Data.Filters;
using Wake.Products.Domain.Entities;

namespace Wake.Products.Data.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAsync(GetProductsFilter getProductsFilter);
    Task<Product> GetByIdAsync(Guid productId);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> DeleteAsync(Guid productId);
}
