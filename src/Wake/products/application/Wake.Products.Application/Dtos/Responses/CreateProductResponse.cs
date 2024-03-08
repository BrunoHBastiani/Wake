using Wake.Products.Domain.Entities;

namespace Wake.Products.Application.Dtos.Responses;
public sealed record CreateProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    public static CreateProductResponse FromProductToDTO(Product product)
    {
        return new CreateProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
        };
    }
}
