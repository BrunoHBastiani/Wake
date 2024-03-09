using Microsoft.AspNetCore.Mvc;

using Moq;

using System.Net;

using Wake.Products.API.Controllers;
using Wake.Products.Application.Dtos.Requests;
using Wake.Products.Application.Dtos.Responses;
using Wake.Products.Application.Interfaces;
using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Resources;

namespace Wake.Products.IntegrationTests;
public class ProductsControllerTests
{
    [Fact]
    public async Task Get_Returns_OK()
    {
        // Arrange
        var productServiceMock = new Mock<IProductService>();

        var validProductResponse = new GetProductResponse
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Name = "Test",
            Description = "Test",
            IsActive = true,
            Price = 0m,
        };

        productServiceMock.Setup(repo => repo.GetAsync(It.IsAny<GetProductsRequest>()))
            .ReturnsAsync(new GetProductsResponse { Products = new List<GetProductResponse> { validProductResponse } });

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Get(new GetProductsRequest());

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task Get_Returns_NoContent()
    {
        // Arrange
        var productServiceMock = new Mock<IProductService>();

        productServiceMock.Setup(repo => repo.GetAsync(It.IsAny<GetProductsRequest>()))
            .ReturnsAsync(new GetProductsResponse { Products = new List<GetProductResponse>() });

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Get(new GetProductsRequest());

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.NoContent, result.StatusCode);
    }

    [Fact]
    public async Task Get_Throws_HttpException()
    {
        // Arrange
        var productServiceMock = new Mock<IProductService>();

        productServiceMock.Setup(repo => repo.GetAsync(It.IsAny<GetProductsRequest>()))
            .ThrowsAsync(new HttpException(HttpStatusCode.BadRequest, "Invalid request"));

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Get(new GetProductsRequest());

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public async Task GetById_Returns_Ok()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var productServiceMock = new Mock<IProductService>();

        productServiceMock.Setup(repo => repo.GetByIdAsync(productId))
            .ReturnsAsync(new GetProductByIdResponse());

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.GetById(productId);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task GetById_Throws_HttpException()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(repo => repo.GetByIdAsync(productId))
            .ThrowsAsync(new HttpException(HttpStatusCode.NotFound, ExceptionMessages.ProductDoesNotExist));

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.GetById(productId);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task Create_Returns_Created()
    {
        // Arrange
        var createProductRequest = new CreateProductRequest();
        var productServiceMock = new Mock<IProductService>();

        productServiceMock.Setup(repo => repo.CreateAsync(It.IsAny<CreateProductRequest>()))
            .ReturnsAsync(new CreateProductResponse());

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Create(createProductRequest);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
    }

    [Fact]
    public async Task Create_Throws_HttpException()
    {
        // Arrange
        var createProductRequest = new CreateProductRequest();
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(repo => repo.CreateAsync(It.IsAny<CreateProductRequest>()))
            .ThrowsAsync(new HttpException(HttpStatusCode.BadRequest, "Invalid request"));

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Create(createProductRequest);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
    }

    [Fact]
    public async Task Update_Returns_Ok()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var updateProductRequest = new UpdateProductRequest();
        var productServiceMock = new Mock<IProductService>();

        productServiceMock.Setup(repo => repo.UpdateAsync(It.IsAny<UpdateProductRequest>(), productId))
            .ReturnsAsync(new UpdateProductResponse());

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Update(productId, updateProductRequest);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task Update_Throws_HttpException()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var updateProductRequest = new UpdateProductRequest();
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(repo => repo.UpdateAsync(It.IsAny<UpdateProductRequest>(), productId))
            .ThrowsAsync(new HttpException(HttpStatusCode.NotFound, "Product not found"));

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Update(productId, updateProductRequest);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }

    [Fact]
    public async Task Delete_Returns_Ok()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var productServiceMock = new Mock<IProductService>();

        productServiceMock.Setup(repo => repo.DeleteAsync(productId))
            .ReturnsAsync(new DeleteProductResponse());

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Delete(productId);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task Delete_Throws_HttpException()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(repo => repo.DeleteAsync(productId))
            .ThrowsAsync(new HttpException(HttpStatusCode.NotFound, "Product not found"));

        var controller = new ProductsController(productServiceMock.Object);

        // Act
        var response = await controller.Delete(productId);

        // Assert
        var result = Assert.IsType<ObjectResult>(response);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
    }
}
