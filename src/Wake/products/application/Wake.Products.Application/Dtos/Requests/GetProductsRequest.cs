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

    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? ExactValue { get; set; }
    public bool? IsActive { get; set; }

    public void Validate()
    {
        if (MinPrice is not null) AssertionConcern.GreaterThanOrEqual(MinPrice.Value, 0, ExceptionMessages.ProductPriceIsNegative);
        if (MaxPrice is not null) AssertionConcern.GreaterThanOrEqual(MaxPrice.Value, 0, ExceptionMessages.ProductPriceIsNegative);
        if (ExactValue is not null) AssertionConcern.GreaterThanOrEqual(ExactValue.Value, 0, ExceptionMessages.ProductPriceIsNegative);
    }

    public GetProductsFilter FromDTOToFilter()
    {
        return new GetProductsFilter
        {
            Name = Name,
            FieldNameToOrder = FieldNameToOrder,
            Order = Order,
            ExactValue = ExactValue,
            IsActive = IsActive,
            MaxPrice = MaxPrice,
            MinPrice = MinPrice,
        };
    }
}
