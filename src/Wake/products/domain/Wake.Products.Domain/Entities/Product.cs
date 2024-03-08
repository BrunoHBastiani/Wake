using Wake.Products.Domain.Resources;
using Wake.Products.Domain.Validations;

namespace Wake.Products.Domain.Entities;
public sealed class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public bool IsActive { get; private set; }

    private Product() { }

    public Product(string name, string description, decimal price) : base()
    {
        ValidateCreation(name, description, price);

        Name = name;
        Description = description;
        Price = price;
        IsActive = true;
    }

    public void Update(string? name, string? description, decimal? price)
    {
        ValidateUpdate(name, description, price);

        if (name is not null) Name = name;
        if (description is not null) Description = description;
        if (price is not null) Price = price.Value;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public static void ValidateCreation(string name, string description, decimal price)
    {
        AssertionConcern.NotNullOrWhiteSpace(name, ExceptionMessages.ProductNameIsNullorEmpty);
        AssertionConcern.SizeGreaterThanOrEqual(name, 2, ExceptionMessages.ProductNameBelowMinimumCharacterLimit);
        AssertionConcern.SizeLessThanOrEqual(name, 100, ExceptionMessages.ProductNameExceedsMaximumCharacterLimit);
        AssertionConcern.SizeLessThanOrEqual(description, 200, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit);
        AssertionConcern.GreaterThanOrEqual(price, 0, ExceptionMessages.ProductPriceIsNegative);
    }

    public static void ValidateUpdate(string? name, string? description, decimal? price)
    {
        if (name is not null)
        {
            AssertionConcern.NotNullOrWhiteSpace(name, ExceptionMessages.ProductNameIsNullorEmpty);
            AssertionConcern.SizeGreaterThanOrEqual(name, 2, ExceptionMessages.ProductNameBelowMinimumCharacterLimit);
            AssertionConcern.SizeLessThanOrEqual(name, 100, ExceptionMessages.ProductNameExceedsMaximumCharacterLimit);
        }

        if (description is not null)
        {
            AssertionConcern.SizeLessThanOrEqual(description, 200, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit);
        }

        if (price is not null)
        {
            AssertionConcern.GreaterThanOrEqual(price.Value, 0, ExceptionMessages.ProductPriceIsNegative);
        }
    }
}
