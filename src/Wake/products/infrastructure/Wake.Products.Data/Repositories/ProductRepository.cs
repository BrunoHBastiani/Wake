using Microsoft.EntityFrameworkCore;

using Wake.Products.Data.Filters;
using Wake.Products.Data.Interfaces;
using Wake.Products.Domain.Entities;
using Wake.Products.Domain.Enums;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;

namespace Wake.Products.Data.Repositories;
public sealed class ProductRepository : IProductRepository
{
    public async Task<List<Product>?> GetAsync(GetProductsFilter getProductsFilter)
    {
        try
        {
            await using var context = new WakeProductsContext();

            IQueryable<Product> productsQuery = context.Products;

            if (getProductsFilter.FieldNameToOrder.HasValue)
            {
                switch (getProductsFilter.Order)
                {
                    case null:
                    case OrderEnum.Asc:
                        productsQuery = productsQuery.OrderBy(p => EF.Property<object>(p, getProductsFilter.FieldNameToOrder.Value.ToString()));
                        break;

                    case OrderEnum.Desc:
                        productsQuery = productsQuery.OrderByDescending(p => EF.Property<object>(p, getProductsFilter.FieldNameToOrder.Value.ToString()));
                        break;
                }
            }

            if (getProductsFilter.Name is not null)
            {
                productsQuery = productsQuery.Where(p => p.Name == getProductsFilter.Name);
            }

            if (getProductsFilter.MinPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price >= getProductsFilter.MinPrice);
            }

            if (getProductsFilter.MaxPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price <= getProductsFilter.MaxPrice);
            }

            if (getProductsFilter.ExactValue is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price ==  getProductsFilter.ExactValue);
            }

            if (getProductsFilter.IsActive is not null)
            {
                productsQuery = productsQuery.Where(p => p.IsActive ==  getProductsFilter.IsActive);
            }

            var foundProducts = await productsQuery.ToListAsync();

            return foundProducts;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
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

    public async Task<Product?> GetActiveByIdAsync(Guid productId)
    {
        try
        {
            await using var context = new WakeProductsContext();

            var foundProduct = await context.Products
                .FirstOrDefaultAsync(p =>
                    p.Id == productId &&
                    p.IsActive == true);

            return foundProduct;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }

    public async Task<Product?> GetActiveByNameAndPriceAsync(string name, decimal price)
    {
        try
        {
            await using var context = new WakeProductsContext();

            var foundProduct = await context.Products
                .FirstOrDefaultAsync(p =>
                    p.Name == name &&
                    p.Price == price &&
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

    public async Task<Product?> UpdateAsync(Product product)
    {
        try
        {
            await using var context = new WakeProductsContext();

            context.Products.Update(product);
            await context.SaveChangesAsync();

            return product;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }
}
