using Wake.Products.Data.Filters;

namespace Wake.Products.Application.Dtos.Requests;
public sealed record GetProductsRequet
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? ExactValue { get; set; }
    public bool? IsActive { get; set; }

    public GetProductsFilter FromDTOToFilter()
    {
        return new GetProductsFilter
        {
            Description = Description,
            ExactValue = ExactValue,
            IsActive = IsActive,
            MaxPrice = MaxPrice,
            MinPrice = MinPrice,
            Name = Name
        };
    }
}
