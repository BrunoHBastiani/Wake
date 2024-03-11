using Wake.Products.Domain.Enums;

namespace Wake.Products.Data.Filters;
public sealed record GetProductsFilter
{
    public string? Name { get; set; }
    public ProductFieldsEnum? FieldNameToOrder { get; set; }
    public OrderEnum? Order { get; set; }
    public int? MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public int? ExactQuantity { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? ExactPrice { get; set; }
    public bool? IsActive { get; set; }
}
