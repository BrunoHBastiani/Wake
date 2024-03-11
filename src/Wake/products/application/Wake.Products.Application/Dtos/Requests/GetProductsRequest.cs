using Wake.Products.Data.Filters;
using Wake.Products.Domain.Enums;
using Wake.Products.Domain.Resources;
using Wake.Products.Domain.Validations;

namespace Wake.Products.Application.Dtos.Requests;
public sealed class GetProductsRequest
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

    public void Validate()
    {
        if (MinPrice is not null) AssertionConcern.GreaterThanOrEqual(MinPrice.Value, 0, ExceptionMessages.ProductPriceIsNegative);
        if (MaxPrice is not null) AssertionConcern.GreaterThanOrEqual(MaxPrice.Value, 0, ExceptionMessages.ProductPriceIsNegative);
        if (ExactPrice is not null) AssertionConcern.GreaterThanOrEqual(ExactPrice.Value, 0, ExceptionMessages.ProductPriceIsNegative);
        if (MinQuantity is not null) AssertionConcern.GreaterThanOrEqual(MinQuantity.Value, 0, ExceptionMessages.ProductQuantityIsNegative);
        if (MaxQuantity is not null) AssertionConcern.GreaterThanOrEqual(MaxQuantity.Value, 0, ExceptionMessages.ProductQuantityIsNegative);
        if (ExactQuantity is not null) AssertionConcern.GreaterThanOrEqual(ExactQuantity.Value, 0, ExceptionMessages.ProductQuantityIsNegative);
    }

    public GetProductsFilter FromDTOToFilter()
    {
        return new GetProductsFilter
        {
            Name = Name,
            FieldNameToOrder = FieldNameToOrder,
            Order = Order,
            MinQuantity = MinQuantity,
            MaxQuantity = MaxQuantity,
            ExactQuantity = ExactQuantity,
            ExactPrice = ExactPrice,
            IsActive = IsActive,
            MaxPrice = MaxPrice,
            MinPrice = MinPrice,
        };
    }
}
