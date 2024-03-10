using Wake.Products.Application.Dtos.Responses;
using Wake.Products.Domain.Entities;

namespace Wake.Products.UnitTests;
public class ProductDTOTests
{
    [Fact]
    public void CreateProductResponse_FromProductToDTO_ReturnsCorrectResponse()
    {
        // Arrange
        var product = new Product("Test Product", "Test Description", 4m, 3);

        // Act
        var response = CreateProductResponse.FromProductToDTO(product);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(product.Name, response.Name);
        Assert.Equal(product.Description, response.Description);
        Assert.Equal(product.Price, response.Price);
        Assert.Equal(product.Quantity, response.Quantity);
    }

    [Fact]
    public void DeleteProductResponse_FromProductToDTO_ReturnsCorrectResponse()
    {
        // Arrange
        var product = new Product("Test Product", "Test Description", 4m, 3);

        // Act
        var response = DeleteProductResponse.FromProductToDTO(product);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(product.Name, response.Name);
        Assert.Equal(product.Description, response.Description);
        Assert.Equal(product.Price, response.Price);
        Assert.Equal(product.Quantity, response.Quantity);
    }

    [Fact]
    public void GetProductByIdResponse_FromProductToDTO_ReturnsCorrectResponse()
    {
        // Arrange
        var product = new Product("Test Product", "Test Description", 4m, 2);

        // Act
        var response = GetProductByIdResponse.FromProductToDTO(product);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(product.Name, response.Name);
        Assert.Equal(product.Description, response.Description);
        Assert.Equal(product.Price, response.Price);
        Assert.Equal(product.Quantity, response.Quantity);
    }

    [Fact]
    public void GetProductsResponse_FromProductToDTO_ReturnsCorrectResponse()
    {
        // Arrange
        var product = new Product("Test Product", "Test Description", 4m, 1);
        var products = new List<Product> { product };

        // Act
        var response = GetProductsResponse.FromProductsToDTO(products);

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void UpdateProductResponse_FromProductToDTO_ReturnsCorrectResponse()
    {
        // Arrange
        var product = new Product("Test Product", "Test Description", 4m, 5);

        // Act
        var response = UpdateProductResponse.FromProductToDTO(product);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(product.Name, response.Name);
        Assert.Equal(product.Description, response.Description);
        Assert.Equal(product.Price, response.Price);
        Assert.Equal(product.Quantity, response.Quantity);
    }
}
