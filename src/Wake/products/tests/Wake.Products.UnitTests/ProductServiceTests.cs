using Moq;

using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Services;
using Wake.Products.Data.Filters;
using Wake.Products.Data.Interfaces;
using Wake.Products.Domain.Entities;
using Wake.Products.Domain.Enums;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;
using Wake.Products.UnitTests.Config;

namespace Wake.Products.UnitTests;
public class ProductServiceTests
{
    [Fact]
    public async Task GetAsync_ValidRequest_ReturnsValidResponse()
    {
        // Arrange
        var getProductRequest = new GetProductsRequest();
        var mockRepository = new Mock<IProductRepository>();

        var validProduct = new Product("Product Name", "Product Description", 10.7m);

        mockRepository.Setup(repo => repo.GetAsync(It.IsAny<GetProductsFilter>()))
            .ReturnsAsync([validProduct]);

        var service = new ProductService(mockRepository.Object);

        // Act
        var response = await service.GetAsync(getProductRequest);

        // Assert
        Assert.NotNull(response);
    }

    [Theory]
    [InlineData(null, null, null, 1.5, 1.3, -1.1, null, ExceptionMessages.ProductPriceIsNegative)]
    [InlineData(null, null, null, 1.5, -1.3, 1.1, null, ExceptionMessages.ProductPriceIsNegative)]
    [InlineData(null, null, null, -1.5, 1.3, 1.1, null, ExceptionMessages.ProductPriceIsNegative)]
    public async Task GetAsync_InvalidRequest_ThrowsException(
        string? name, string? fieldNameToOrder, string? order,
        decimal minValue, decimal maxValue, decimal exactValue,
        bool? isActive, string expectedErrorMessage)
    {
        // Arrange
        var getProductRequest = new GetProductsRequest
        {
            Name = name,
            MaxPrice = maxValue,
            MinPrice = minValue,
            ExactValue = exactValue,
            IsActive = isActive,

            FieldNameToOrder = fieldNameToOrder is not null ?
                (ProductFieldsEnum)Enum.Parse(typeof(ProductFieldsEnum), fieldNameToOrder) :
                null,

            Order = order is not null ?
                (OrderEnum)Enum.Parse(typeof(OrderEnum), order) :
                null,
        };

        var mockRepository = new Mock<IProductRepository>();

        var validProduct = new Product("Product Name", "Product Description", 10.7m);

        mockRepository.Setup(repo => repo.GetAsync(It.IsAny<GetProductsFilter>()))
            .ReturnsAsync([validProduct]);

        var service = new ProductService(mockRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAnyAsync<HttpBadRequestException>(async () => await service.GetAsync(getProductRequest));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public async Task GetByIdAsync_ValidProductId_ReturnsValidResponse()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var mockRepository = new Mock<IProductRepository>();

        var validProduct = new Product("Product Name", "Product Description", 10.7m);

        mockRepository.Setup(repo => repo.GetByIdAsync(productId))
            .ReturnsAsync(validProduct);

        var service = new ProductService(mockRepository.Object);

        // Act
        var response = await service.GetByIdAsync(productId);

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    public async Task CreateAsync_ValidRequest_ReturnsValidResponse()
    {
        // Arrange
        var createProductRequest = new CreateProductRequest
        {
            Name = "Product Name",
            Description = "Product Description",
            Price = 15.4m,
        };

        var mockRepository = new Mock<IProductRepository>();

        mockRepository.Setup(repo => repo.GetActiveByNameAndPriceAsync(It.IsAny<string>(), It.IsAny<decimal>()))
            .ReturnsAsync((Product?)null);

        var validProduct = new Product("Product Name", "Product Description", 10.7m);

        mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<Product>()))
            .ReturnsAsync(validProduct);

        var service = new ProductService(mockRepository.Object);

        // Act
        var response = await service.CreateAsync(createProductRequest);

        // Assert
        Assert.NotNull(response);
    }

    [Theory]
    [InlineData(null, "Description", 10.1, ExceptionMessages.ProductNameIsNullOrEmpty)]
    [InlineData("", "Description", 9.24, ExceptionMessages.ProductNameIsNullOrEmpty)]
    [InlineData("P", "Description", 8.10, ExceptionMessages.ProductNameBelowMinimumCharacterLimit)]
    [InlineData("Product Name", TestConfig.DescriptionWithMoreThan200characters, 1.3, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit)]
    [InlineData("Product Name", "Description", -10.5, ExceptionMessages.ProductPriceIsNegative)]
    public async Task CreateAsync_InvalidRequest_ThrowsException(string name, string description, decimal price, string expectedErrorMessage)
    {
        // Arrange
        var createProductRequest = new CreateProductRequest
        {
            Name = name,
            Description = description,
            Price = price,
        };

        var mockRepository = new Mock<IProductRepository>();

        mockRepository.Setup(repo => repo.GetActiveByNameAndPriceAsync(It.IsAny<string>(), It.IsAny<decimal>()))
            .ReturnsAsync((Product?)null);

        var validProduct = new Product("Product Name", "Product Description", 10.7m);

        mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<Product>()))
            .ReturnsAsync(validProduct);

        var service = new ProductService(mockRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAnyAsync<HttpBadRequestException>(async () => await service.CreateAsync(createProductRequest));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public async Task UpdateAsync_ValidRequest_ReturnsValidResponse()
    {
        // Arrange
        var updateProductRequest = new UpdateProductRequest();
        var productId = Guid.NewGuid();
        var mockRepository = new Mock<IProductRepository>();

        mockRepository.Setup(repo => repo.GetActiveByNameAndPriceAsync(It.IsAny<string>(), It.IsAny<decimal>()))
            .ReturnsAsync((Product?)null);

        mockRepository.Setup(repo => repo.GetActiveByIdAsync(productId))
            .ReturnsAsync(new Product("Product Name", "Product Description", 10.7m));

        mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
            .ReturnsAsync(new Product("Product Name", "Product Description", 10.7m));

        var service = new ProductService(mockRepository.Object);

        // Act
        var response = await service.UpdateAsync(updateProductRequest, productId);

        // Assert
        Assert.NotNull(response);
    }

    [Theory]
    [InlineData("", "Description", 7.7, ExceptionMessages.ProductNameIsNullOrEmpty)]
    [InlineData("P", "Description", 2.3, ExceptionMessages.ProductNameBelowMinimumCharacterLimit)]
    [InlineData("Updated Name", TestConfig.DescriptionWithMoreThan200characters, 1.3, ExceptionMessages.ProductDescriptionExceedsMaximumCharacterLimit)]
    [InlineData("Updated Name", "Updated Description", -20.1, ExceptionMessages.ProductPriceIsNegative)]
    public async Task UpdateAsync_InvalidRequest_ThrowsException(string newName, string newDescription, decimal newPrice, string expectedErrorMessage)
    {
        // Arrange
        var updateProductRequest = new UpdateProductRequest
        {
            Name = newName,
            Description = newDescription,
            Price = newPrice,
        };

        var productId = Guid.NewGuid();
        var mockRepository = new Mock<IProductRepository>();

        mockRepository.Setup(repo => repo.GetActiveByNameAndPriceAsync(It.IsAny<string>(), It.IsAny<decimal>()))
            .ReturnsAsync((Product?)null);

        mockRepository.Setup(repo => repo.GetActiveByIdAsync(productId))
            .ReturnsAsync(new Product("Product Name", "Product Description", 10.7m));

        mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
            .ReturnsAsync(new Product("Product Name", "Product Description", 10.7m));

        var service = new ProductService(mockRepository.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAnyAsync<HttpBadRequestException>(async () => await service.UpdateAsync(updateProductRequest, productId));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public async Task DeleteAsync_ValidProductId_ReturnsValidResponse()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var mockRepository = new Mock<IProductRepository>();

        mockRepository.Setup(repo => repo.GetActiveByIdAsync(productId))
            .ReturnsAsync(new Product("Product Name", "Product Description", 10.7m));

        mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
            .ReturnsAsync(new Product("Product Name", "Product Description", 10.7m));

        var service = new ProductService(mockRepository.Object);

        // Act
        var response = await service.DeleteAsync(productId);

        // Assert
        Assert.NotNull(response);
    }
}
