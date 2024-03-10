using Wake.Products.Domain.Entities;

namespace Wake.Products.Application.Dtos.Responses;
public sealed record GetProductsResponse
{
    public IEnumerable<GetProductResponse>? Products { get; set; }

    public static GetProductsResponse FromProductsToDTO(IEnumerable<Product> products)
    {
        return new GetProductsResponse
        {
            Products = products.Select(product => new GetProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                IsActive = product.IsActive,
            }),
        };
    }
}
