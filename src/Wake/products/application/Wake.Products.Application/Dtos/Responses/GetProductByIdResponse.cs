using Wake.Products.Domain.Entities;

namespace Wake.Products.Application.Dtos.Responses;
public sealed record GetProductByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static GetProductByIdResponse FromProductToDTO(Product product)
    {
        return new GetProductByIdResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            IsActive = product.IsActive,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
        };
    }
}
