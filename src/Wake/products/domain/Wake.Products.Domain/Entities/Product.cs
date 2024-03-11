using Wake.Products.Domain.Resources;
using Wake.Products.Domain.Validations;

namespace Wake.Products.Domain.Entities;
public sealed class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public bool IsActive { get; private set; }

    private Product() { }

    public Product(string name, string description, decimal price, int quantity) : base()
    {
        ValidateCreation(name, description, price, quantity);

        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        IsActive = true;
    }

    public void Update(string? name, string? description, decimal? price, int? quantity)
    {
        ValidateUpdate(name, description, price, quantity);

        if (name is not null) Name = name;
        if (description is not null) Description = description;
        if (price is not null) Price = price.Value;
        if (quantity is not null) Quantity = quantity.Value;
    }

    public void Deactivate()
    {
        AssertionConcern.True(IsActive, ExceptionMessages.ProductIsAlreadyDeactivated);

        IsActive = false;
    }

    public void ValidateCreation(string name, string description, decimal price, int quantity)
    {
        ValidateName(name);
        ValidateDescription(description);
        ValidatePrice(price);
        ValidateQuantity(quantity);
    }

    public void ValidateUpdate(string? name, string? description, decimal? price, int? quantity)
    {
        if (name is not null) ValidateName(name);
        if (description is not null) ValidateDescription(description);
        if (price is not null) ValidatePrice(price.Value);
        if (quantity is not null) ValidateQuantity(quantity.Value);
    }

    private void ValidateName(string name)
    {
        AssertionConcern.NotNullOrWhiteSpace(name, ExceptionMessages.ProductNameIsNullOrEmpty);
        AssertionConcern.SizeGreaterThanOrEqual(name, 2, ExceptionMessages.ProductNameBelowMinimumCharacterLimit);
        AssertionConcern.SizeLessThanOrEqual(name, 100, ExceptionMessages.ProductNameExceedsMaximumCharacterLimit);
    }

    private void ValidateDescription(string description)
    {
        AssertionConcern.SizeLessThanOrEqual(description, 200, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit);
    }

    private void ValidatePrice(decimal price)
    {
        AssertionConcern.GreaterThanOrEqual(price, 0, ExceptionMessages.ProductPriceIsNegative);
    }

    private void ValidateQuantity(int quantity)
    {
        AssertionConcern.GreaterThanOrEqual(quantity, 0, ExceptionMessages.ProductQuantityIsNegative);
    }
}
