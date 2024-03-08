using Wake.Products.Data.Filters;
using Wake.Products.Data.Interfaces;
using Wake.Products.Domain.Entities;

namespace Wake.Products.Data.Repositories;
public sealed class ProductRepository : IProductRepository
{
    public Task<Product> CreateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> DeleteAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAsync(GetProductsFilter getProductsFilter)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
