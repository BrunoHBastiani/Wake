namespace Wake.Products.Data.Filters;
public sealed record GetProductsFilter
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? ExactValue { get; set; }
    public bool? IsActive { get; set; }
}
