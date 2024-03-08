using Microsoft.EntityFrameworkCore;

using Wake.Products.Data.Filters;
using Wake.Products.Data.Interfaces;
using Wake.Products.Domain.Entities;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;

namespace Wake.Products.Data.Repositories;
public sealed class ProductRepository : IProductRepository
{
    public async Task<IEnumerable<Product>?> GetAsync(GetProductsFilter getProductsFilter)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetByIdAsync(Guid productId)
    {
        try
        {
            await using var context = new WakeProductsContext();

            var foundProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            return foundProduct;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }

    public async Task<Product?> GetActiveByNameAndPriceAsync(Product product)
    {
        try
        {
            await using var context = new WakeProductsContext();

            var foundProduct = await context.Products
                .FirstOrDefaultAsync(p => 
                    p.Name == product.Name &&
                    p.Price == product.Price &&
                    p.IsActive == true);

            return foundProduct;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }

    public async Task<Product?> CreateAsync(Product product)
    {
        try
        {
            await using var context = new WakeProductsContext();

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }

    public Task<Product> UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> DeleteAsync(Guid productId)
    {
        throw new NotImplementedException();
    }
}
