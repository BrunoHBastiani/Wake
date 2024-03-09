using Microsoft.EntityFrameworkCore;

using Wake.Products.Data;
using Wake.Products.Data.Interfaces;
using Wake.Products.Data.Repositories;
using Wake.Products.Domain.Entities;
using Wake.Products.Domain.Exceptions;

namespace Wake.Products.IntegrationTests;
public class ProductRepositoryTests
{
    private readonly DbContextOptions<WakeProductsContext> _options;

    public ProductRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<WakeProductsContext>()
            .UseInMemoryDatabase(databaseName: "test_wakedb")
            .Options;

        using var context = new WakeProductsContext(_options);

        context.Products.AddRange(
            new Product("Product 1", "Description 1", 100),
            new Product("Product 2", "Description 2", 200),
            new Product("Product 3", "Description 3", 300)
        );

        context.SaveChanges();
    }

    [Fact]
    public async Task GetByIdAsync_ExistingId_ReturnsProduct()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var productId = context.Products.First().Id;

        // Act
        var product = await repository.GetByIdAsync(productId);

        // Assert
        Assert.NotNull(product);
        Assert.Equal(productId, product.Id);
    }

    [Fact]
    public async Task GetByIdAsync_NonExistingId_ReturnsNull()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var nonExistingId = Guid.NewGuid();

        // Act
        var product = await repository.GetByIdAsync(nonExistingId);

        // Assert
        Assert.Null(product);
    }

    [Fact]
    public async Task GetActiveByIdAsync_ExistingId_ReturnsActiveProduct()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var productId = context.Products.First().Id;

        // Act
        var product = await repository.GetActiveByIdAsync(productId);

        // Assert
        Assert.NotNull(product);
        Assert.Equal(productId, product.Id);
        Assert.True(product.IsActive);
    }

    [Fact]
    public async Task GetActiveByIdAsync_NonExistingId_ReturnsNull()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var nonExistingId = Guid.NewGuid();

        // Act
        var product = await repository.GetActiveByIdAsync(nonExistingId);

        // Assert
        Assert.Null(product);
    }

    [Fact]
    public async Task GetActiveByNameAndPriceAsync_ExistingNameAndPrice_ReturnsActiveProduct()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var existingProduct = context.Products.First();

        // Act
        var product = await repository.GetActiveByNameAndPriceAsync(existingProduct.Name, existingProduct.Price);

        // Assert
        Assert.NotNull(product);
        Assert.Equal(existingProduct.Id, product.Id);
        Assert.True(product.IsActive);
    }

    [Fact]
    public async Task GetActiveByNameAndPriceAsync_NonExistingNameAndPrice_ReturnsNull()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);

        // Act
        var product = await repository.GetActiveByNameAndPriceAsync("NonExistingProduct", 999);

        // Assert
        Assert.Null(product);
    }

    [Fact]
    public async Task CreateAsync_ValidProduct_CreatesProduct()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var newProduct = new Product("New Product", "New Description", 500);

        // Act
        var createdProduct = await repository.CreateAsync(newProduct);

        // Assert
        Assert.NotNull(createdProduct);
        Assert.NotEqual(Guid.Empty, createdProduct.Id);
    }

    [Fact]
    public async Task CreateAsync_NullProduct_ThrowsException()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);

        // Act & Assert
        await Assert.ThrowsAsync<HttpInternalServerErrorException>(async () => await repository.CreateAsync(null));
    }

    [Fact]
    public async Task UpdateAsync_ExistingProduct_UpdatesProduct()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);
        var existingProduct = context.Products.First();
        existingProduct.Update("Updated Product", null, null);

        // Act
        var updatedProduct = await repository.UpdateAsync(existingProduct);

        // Assert
        Assert.NotNull(updatedProduct);
        Assert.Equal(existingProduct.Id, updatedProduct.Id);
        Assert.Equal("Updated Product", updatedProduct.Name);
    }

    [Fact]
    public async Task UpdateAsync_NullProduct_ThrowsException()
    {
        // Arrange
        using var context = new WakeProductsContext(_options);
        ProductRepository repository = new(context);

        // Act & Assert
        await Assert.ThrowsAsync<HttpInternalServerErrorException>(async () => await repository.UpdateAsync(null));
    }
}