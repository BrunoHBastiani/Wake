namespace Wake.Products.Application.Dtos.Requests;
public sealed record UpdateProductRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
