using Wake.Products.Domain.Enums;

namespace Wake.Products.Data.Filters;
public sealed record GetProductsFilter
{
    public string? Name { get; set; }
    public ProductFieldsEnum? FieldNameToOrder { get; set; }
    public OrderEnum? Order { get; set; }

    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? ExactValue { get; set; }
    public bool? IsActive { get; set; }
}
