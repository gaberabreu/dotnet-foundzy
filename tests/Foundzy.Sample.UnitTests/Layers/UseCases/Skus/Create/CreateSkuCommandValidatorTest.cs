using FluentAssertions;
using FluentValidation.TestHelper;
using Foundzy.Sample.Layers.UseCases.Skus.Create;

namespace Foundzy.Sample.UnitTests.Layers.UseCases.Skus.Create;

public class CreateSkuCommandValidatorTest
{
    private readonly CreateSkuCommandValidator _validator = new();

    [Fact]
    public void Validate_ShouldBeValidWhenHasNoErrors()
    {
        // Arrange
        var command = new CreateSkuCommand("Name");

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_ShouldBeInvalidWhenEmptyName()
    {
        // Arrange
        var command = new CreateSkuCommand(string.Empty);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(p => p.Name)
            .WithErrorCode("NotEmptyValidator");
    }
}
