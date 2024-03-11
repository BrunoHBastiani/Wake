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
    private readonly WakeProductsContext _context;

    public ProductRepository(WakeProductsContext context)
    {
        _context = context;
    }

    public async Task<List<Product>?> GetAsync(GetProductsFilter getProductsFilter)
    {
        try
        {
            IQueryable<Product> productsQuery = _context.Products;

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
                productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(getProductsFilter.Name.ToLower()));
            }

            if (getProductsFilter.MinQuantity is not null)
            {
                productsQuery = productsQuery.Where(p => p.Quantity >= getProductsFilter.MinQuantity);
            }

            if (getProductsFilter.MaxQuantity is not null)
            {
                productsQuery = productsQuery.Where(p => p.Quantity <= getProductsFilter.MaxQuantity);
            }

            if (getProductsFilter.ExactQuantity is not null)
            {
                productsQuery = productsQuery.Where(p => p.Quantity ==  getProductsFilter.ExactQuantity);
            }

            if (getProductsFilter.MinPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price >= getProductsFilter.MinPrice);
            }

            if (getProductsFilter.MaxPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price <= getProductsFilter.MaxPrice);
            }

            if (getProductsFilter.ExactPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price ==  getProductsFilter.ExactPrice);
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
            var foundProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

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
            var foundProduct = await _context.Products
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

    public async Task<Product?> GetActiveByNameAsync(string name)
    {
        try
        {
            var foundProduct = await _context.Products
                .FirstOrDefaultAsync(p =>
                    p.Name == name &&
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
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

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
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
        catch
        {
            throw new HttpInternalServerErrorException(ExceptionMessages.HttpInternalServerError);
        }
    }
}
