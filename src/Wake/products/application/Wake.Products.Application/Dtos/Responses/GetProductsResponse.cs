namespace Wake.Products.Application.Dtos.Responses;
public sealed record GetProductsResponse
{
    public IEnumerable<GetProductResponse>? Products { get; set; }
}
