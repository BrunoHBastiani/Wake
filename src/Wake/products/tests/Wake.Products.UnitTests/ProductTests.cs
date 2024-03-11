using Wake.Products.Domain.Entities;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;
using Wake.Products.UnitTests.Config;

namespace Wake.Products.UnitTests;

public sealed class ProductTests
{
    [Fact]
    public void CreateProduct_ValidArguments_Success()
    {
        // Arrange
        string name = "Product Name";
        string description = "Product Description";
        decimal price = 5.25m;
        int quantity = 3;

        // Act
        var product = new Product(name, description, price, quantity);

        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(price, product.Price);
        Assert.True(product.IsActive);
    }

    [Theory]
    [InlineData(null, "Description", 10.1, 3, ExceptionMessages.ProductNameIsNullOrEmpty)]
    [InlineData("", "Description", 7.7, 3, ExceptionMessages.ProductNameIsNullOrEmpty)]
    [InlineData("P", "Description", 2.3, 3, ExceptionMessages.ProductNameBelowMinimumCharacterLimit)]
    [InlineData("Updated Name", TestConfig.DescriptionWithMoreThan200characters, 1.3, 3, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit)]
    [InlineData("Updated Name", "Updated Description", -20.1, 3, ExceptionMessages.ProductPriceIsNegative)]
    [InlineData("Updated Name", "Updated Description", 20.1, -3, ExceptionMessages.ProductQuantityIsNegative)]
    public void CreateProduct_InvalidArguments_ThrowsException(string name, string description, decimal price, int quantity, string expectedErrorMessage)
    {
        // Act & Assert
        var exception = Assert.ThrowsAny<HttpBadRequestException>(() => new Product(name, description, price, quantity));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void UpdateProduct_ValidArguments_Success()
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 1.5m, 6);
        string newName = "Updated Name";
        string newDescription = "Updated Description";
        decimal newPrice = 2.5m;
        int newQuantity = 4;

        // Act
        product.Update(newName, newDescription, newPrice, newQuantity);

        // Assert
        Assert.Equal(newName, product.Name);
        Assert.Equal(newDescription, product.Description);
        Assert.Equal(newPrice, product.Price);
        Assert.Equal(newQuantity, product.Quantity);
    }

    [Theory]
    [InlineData("", "Description", 7.7, 3, ExceptionMessages.ProductNameIsNullOrEmpty)]
    [InlineData("P", "Description", 2.3, 3, ExceptionMessages.ProductNameBelowMinimumCharacterLimit)]
    [InlineData("Updated Name", TestConfig.DescriptionWithMoreThan200characters, 1.3, 3, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit)]
    [InlineData("Updated Name", "Updated Description", -20.1, 3, ExceptionMessages.ProductPriceIsNegative)]
    [InlineData("Updated Name", "Updated Description", 20.1, -3, ExceptionMessages.ProductQuantityIsNegative)]
    public void UpdateProduct_InvalidArguments_ThrowsException(string newName, string newDescription, decimal newPrice, int newQuantity, string expectedErrorMessage)
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 4.5m, 2);

        // Act & Assert
        var exception = Assert.Throws<HttpBadRequestException>(() => product.Update(newName, newDescription, newPrice, newQuantity));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void DeactivateProduct_Success()
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 8.4m, 5);

        // Act
        product.Deactivate();

        // Assert
        Assert.False(product.IsActive);
    }

    [Fact]
    public void DeactivateProduct_ThatIsAlreadyDeactivated_ThrowsException()
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 8.1m, 9);

        // Act & Assert
        product.Deactivate();

        //Tenta realizar uma segunda tentativa para testar o ato de desativar um produto que já está desativado
        var exception = Assert.Throws<HttpBadRequestException>(product.Deactivate);
        Assert.Equal(ExceptionMessages.ProductIsAlreadyDeactivated, exception.Message);
    }
}
