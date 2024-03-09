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

        // Act
        var product = new Product(name, description, price);

        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(price, product.Price);
        Assert.True(product.IsActive);
    }

    [Theory]
    [InlineData(null, "Description", 10.1, ExceptionMessages.ProductNameIsNullorEmpty)]
    [InlineData("", "Description", 9.24, ExceptionMessages.ProductNameIsNullorEmpty)]
    [InlineData("P", "Description", 8.10, ExceptionMessages.ProductNameBelowMinimumCharacterLimit)]
    [InlineData("Product Name", TestConfig.DescriptionWithMoreThan200characters, 1.0, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit)]
    [InlineData("Product Name", "Description", -10.5, ExceptionMessages.ProductPriceIsNegative)]
    public void CreateProduct_InvalidArguments_ThrowsException(string name, string description, decimal price, string expectedErrorMessage)
    {
        // Act & Assert
        var exception = Assert.ThrowsAny<HttpBadRequestException>(() => new Product(name, description, price));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void UpdateProduct_ValidArguments_Success()
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 1.5m);
        string newName = "Updated Name";
        string newDescription = "Updated Description";
        decimal newPrice = 2.5m;

        // Act
        product.Update(newName, newDescription, newPrice);

        // Assert
        Assert.Equal(newName, product.Name);
        Assert.Equal(newDescription, product.Description);
        Assert.Equal(newPrice, product.Price);
    }

    [Theory]
    [InlineData("", "Description", 7.7, ExceptionMessages.ProductNameIsNullorEmpty)]
    [InlineData("P", "Description", 2.3, ExceptionMessages.ProductNameBelowMinimumCharacterLimit)]
    [InlineData("Updated Name", TestConfig.DescriptionWithMoreThan200characters, 1.3, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit)]
    [InlineData("Updated Name", "Updated Description", -20.1, ExceptionMessages.ProductPriceIsNegative)]
    public void UpdateProduct_InvalidArguments_ThrowsException(string newName, string newDescription, decimal newPrice, string expectedErrorMessage)
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 4.5m);

        // Act & Assert
        var exception = Assert.Throws<HttpBadRequestException>(() => product.Update(newName, newDescription, newPrice));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void DeactivateProduct_Success()
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 8.4m);

        // Act
        product.Deactivate();

        // Assert
        Assert.False(product.IsActive);
    }

    [Fact]
    public void DeactivateProductThatIsAlreadyDeactivated_ThrowsException()
    {
        // Arrange
        var product = new Product("Initial Name", "Initial Description", 8.1m);

        // Act & Assert
        product.Deactivate();

        //Tenta realizar uma segunda tentativa para testar o ato de desativar um produto que já está desativado
        var exception = Assert.Throws<HttpBadRequestException>(product.Deactivate);
        Assert.Equal(ExceptionMessages.ProductIsAlreadyDeactivated, exception.Message);
    }

    [Theory]
    [InlineData(null, "Description", 10)]
    [InlineData("", "Description", 10)]
    [InlineData("N", "Description", 10)]
    [InlineData(TestConfig.NameWithMoreThan100characters, "Description", 10)]
    [InlineData("Name", TestConfig.DescriptionWithMoreThan200characters, 10)]
    [InlineData("Name", "Description", -10)]
    public void ValidateCreation_ThrowsException_ForInvalidInput(string name, string description, decimal price)
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => Product.ValidateCreation(name, description, price));
    }

    [Fact]
    public void ValidateCreation_DoesNotThrowException_ForValidInput()
    {
        // Arrange & Act & Assert
        Product.ValidateCreation("Valid Name", "Valid Description", 10);
    }

    [Theory]
    [InlineData("", "Description", 10)]
    [InlineData("N", "Description", 10)]
    [InlineData(TestConfig.NameWithMoreThan100characters, "Description", 10)]
    [InlineData("Name", TestConfig.DescriptionWithMoreThan200characters, 10)]
    [InlineData("Name", "Description", -10)]
    public void ValidateUpdate_ThrowsException_ForInvalidInput(string name, string description, decimal price)
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => Product.ValidateUpdate(name, description, price));
    }

    [Fact]
    public void ValidateUpdate_DoesNotThrowException_ForValidInput()
    {
        // Arrange & Act & Assert
        Product.ValidateUpdate("Valid Name", "Valid Description", 10);
    }
}
