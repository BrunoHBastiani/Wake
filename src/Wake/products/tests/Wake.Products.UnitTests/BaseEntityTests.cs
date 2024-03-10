using Wake.Products.Domain.Entities;

namespace Wake.Products.UnitTests;
public class BaseEntityTests
{
    [Fact]
    public void BaseEntity_Constructor_SetsId()
    {
        // Arrange & Act
        var entity = new BaseEntity();

        // Assert
        Assert.NotEqual(Guid.Empty, entity.Id);
    }

    [Fact]
    public void RegisterCreation_SetsCreatedAt()
    {
        // Arrange
        var entity = new BaseEntity();

        // Act
        entity.RegisterCreation();

        // Assert
        Assert.NotEqual(default, entity.CreatedAt);
    }

    [Fact]
    public void RegisterUpdate_SetsUpdatedAt()
    {
        // Arrange
        var entity = new BaseEntity();

        // Act
        entity.RegisterUpdate();

        // Assert
        Assert.NotEqual(default, entity.UpdatedAt);
    }

    [Fact]
    public void RegisterCreation_SetsCreatedAtToCurrentTime()
    {
        // Arrange
        var entity = new BaseEntity();
        var expectedCreatedAt = DateTime.UtcNow;

        // Act
        entity.RegisterCreation();

        // Assert
        Assert.Equal(expectedCreatedAt.Date, entity.CreatedAt.Date);
        Assert.Equal(expectedCreatedAt.Hour, entity.CreatedAt.Hour);
        Assert.Equal(expectedCreatedAt.Minute, entity.CreatedAt.Minute);
        Assert.Equal(expectedCreatedAt.Second, entity.CreatedAt.Second);
    }

    [Fact]
    public void RegisterUpdate_SetsUpdatedAtToCurrentTime()
    {
        // Arrange
        var entity = new BaseEntity();
        var expectedUpdatedAt = DateTime.UtcNow;

        // Act
        entity.RegisterUpdate();

        // Assert
        Assert.Equal(expectedUpdatedAt.Date, entity.UpdatedAt.Date);
        Assert.Equal(expectedUpdatedAt.Hour, entity.UpdatedAt.Hour);
        Assert.Equal(expectedUpdatedAt.Minute, entity.UpdatedAt.Minute);
        Assert.Equal(expectedUpdatedAt.Second, entity.UpdatedAt.Second);
    }
}
