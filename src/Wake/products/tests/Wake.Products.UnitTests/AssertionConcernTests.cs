using Wake.Products.Domain.Exceptions;
using Wake.Products.Domain.Validations;

namespace Wake.Products.UnitTests;
public class AssertionConcernTests
{
    [Fact]
    public void NotNull_ThrowsException_WhenObjectIsNull()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.NotNull(null, "Object is null"));
    }

    [Fact]
    public void NotNull_DoesNotThrowException_WhenObjectIsNotNull()
    {
        // Arrange & Act & Assert
        AssertionConcern.NotNull(new object(), "Object is null");
    }

    [Fact]
    public void Null_ThrowsException_WhenObjectIsNotNull()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.Null(new object(), "Object is not null"));
    }

    [Fact]
    public void Null_DoesNotThrowException_WhenObjectIsNull()
    {
        // Arrange & Act & Assert
        AssertionConcern.Null(null, "Object is not null");
    }

    [Fact]
    public void NotEmpty_ThrowsException_WhenStringIsEmpty()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.NotEmpty("", "String is empty"));
    }

    [Fact]
    public void NotEmpty_DoesNotThrowException_WhenStringIsNotEmpty()
    {
        // Arrange & Act & Assert
        AssertionConcern.NotEmpty("Not empty string", "String is empty");
    }

    [Fact]
    public void NotNullOrWhiteSpace_ThrowsException_WhenStringIsNullOrWhiteSpace()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.NotNullOrWhiteSpace(null, "String is null or whitespace"));
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.NotNullOrWhiteSpace("", "String is null or whitespace"));
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.NotNullOrWhiteSpace("   ", "String is null or whitespace"));
    }

    [Fact]
    public void NotNullOrWhiteSpace_DoesNotThrowException_WhenStringIsNotNullOrWhiteSpace()
    {
        // Arrange & Act & Assert
        AssertionConcern.NotNullOrWhiteSpace("Not null or whitespace", "String is null or whitespace");
    }

    [Fact]
    public void GreaterThan_ThrowsException_WhenValueIsNotGreaterThanLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.GreaterThan(5, 10, "Value is not greater than limit"));
    }

    [Fact]
    public void GreaterThan_DoesNotThrowException_WhenValueIsGreaterThanLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.GreaterThan(10, 5, "Value is not greater than limit");
    }

    [Fact]
    public void LessThan_ThrowsException_WhenValueIsNotLessThanLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.LessThan(10, 5, "Value is not less than limit"));
    }

    [Fact]
    public void LessThan_DoesNotThrowException_WhenValueIsLessThanLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.LessThan(5, 10, "Value is not less than limit");
    }

    [Fact]
    public void LessThan_ThrowsException_WhenDecimalValueIsNotLessThanLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.LessThan(10m, 5m, "Value is not less than limit"));
    }

    [Fact]
    public void LessThan_DoesNotThrowException_WhenDecimalValueIsLessThanLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.LessThan(5m, 10m, "Value is not less than limit");
    }

    [Fact]
    public void LessThanOrEqual_ThrowsException_WhenValueIsNotLessThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.LessThanOrEqual(10, 5, "Value is not less than or equal to limit"));
    }

    [Fact]
    public void LessThanOrEqual_DoesNotThrowException_WhenValueIsLessThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.LessThanOrEqual(5, 10, "Value is not less than or equal to limit");
        AssertionConcern.LessThanOrEqual(5, 5, "Value is not less than or equal to limit");
    }

    [Fact]
    public void GreaterThanOrEqual_ThrowsException_WhenValueIsNotGreaterThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.GreaterThanOrEqual(5, 10, "Value is not greater than or equal to limit"));
    }

    [Fact]
    public void GreaterThanOrEqual_DoesNotThrowException_WhenValueIsGreaterThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.GreaterThanOrEqual(10, 5, "Value is not greater than or equal to limit");
        AssertionConcern.GreaterThanOrEqual(10, 10, "Value is not greater than or equal to limit");
    }

    [Fact]
    public void GreaterThanOrEqual_ThrowsException_WhenDecimalValueIsNotGreaterThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.GreaterThanOrEqual(5m, 10m, "Value is not greater than or equal to limit"));
    }

    [Fact]
    public void GreaterThanOrEqual_DoesNotThrowException_WhenDecimalValueIsGreaterThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.GreaterThanOrEqual(10m, 5m, "Value is not greater than or equal to limit");
        AssertionConcern.GreaterThanOrEqual(10m, 10m, "Value is not greater than or equal to limit");
    }

    [Fact]
    public void Equal_ThrowsException_WhenValuesAreNotEqual()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.Equal(5, 10, "Values are not equal"));
    }

    [Fact]
    public void Equal_DoesNotThrowException_WhenValuesAreEqual()
    {
        // Arrange & Act & Assert
        AssertionConcern.Equal(5, 5, "Values are not equal");
    }

    [Fact]
    public void True_ThrowsException_WhenConditionIsFalse()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.True(false, "Condition is false"));
    }

    [Fact]
    public void True_DoesNotThrowException_WhenConditionIsTrue()
    {
        // Arrange & Act & Assert
        AssertionConcern.True(true, "Condition is false");
    }

    [Fact]
    public void False_ThrowsException_WhenConditionIsTrue()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.False(true, "Condition is true"));
    }

    [Fact]
    public void False_DoesNotThrowException_WhenConditionIsFalse()
    {
        // Arrange & Act & Assert
        AssertionConcern.False(false, "Condition is true");
    }

    [Fact]
    public void ContainsText_ThrowsException_WhenTextDoesNotContainSubtext()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.ContainsText("Some text", "Subtext", "Text does not contain subtext"));
    }

    [Fact]
    public void ContainsText_DoesNotThrowException_WhenTextContainsSubtext()
    {
        // Arrange & Act & Assert
        AssertionConcern.ContainsText("Some text", "Some", "Text does not contain subtext");
    }

    [Fact]
    public void NotContainsText_ThrowsException_WhenTextContainsSubtext()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.NotContainsText("Some text", "text", "Text contains subtext"));
    }

    [Fact]
    public void NotContainsText_DoesNotThrowException_WhenTextDoesNotContainSubtext()
    {
        // Arrange & Act & Assert
        AssertionConcern.NotContainsText("Some text", "Subtext", "Text contains subtext");
    }

    [Fact]
    public void EqualSize_ThrowsException_WhenTextSizeIsNotEqual()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.EqualSize("Text", 10, "Text size is not equal"));
    }

    [Fact]
    public void EqualSize_DoesNotThrowException_WhenTextSizeIsEqual()
    {
        // Arrange & Act & Assert
        AssertionConcern.EqualSize("Text", 4, "Text size is not equal");
    }

    [Fact]
    public void SizeGreaterThanOrEqual_ThrowsException_WhenTextSizeIsLessThanLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.SizeGreaterThanOrEqual("Text", 10, "Text size is less than limit"));
    }

    [Fact]
    public void SizeGreaterThanOrEqual_DoesNotThrowException_WhenTextSizeIsGreaterThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.SizeGreaterThanOrEqual("Text", 4, "Text size is less than limit");
    }

    [Fact]
    public void SizeLessThanOrEqual_ThrowsException_WhenTextSizeIsGreaterThanLimit()
    {
        // Arrange & Act & Assert
        Assert.Throws<HttpBadRequestException>(() => AssertionConcern.SizeLessThanOrEqual("Text", 2, "Text size is greater than limit"));
    }

    [Fact]
    public void SizeLessThanOrEqual_DoesNotThrowException_WhenTextSizeIsLessThanOrEqualLimit()
    {
        // Arrange & Act & Assert
        AssertionConcern.SizeLessThanOrEqual("Text", 4, "Text size is greater than limit");
        AssertionConcern.SizeLessThanOrEqual("Text", 5, "Text size is greater than limit");
    }
}
