using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace Foundzy.UnitTests;

public class LoggingBehaviorTests
{
    private readonly Mock<ILogger<Mediator>> _loggerMock;
    private readonly Mock<RequestHandlerDelegate<int>> _nextMock;
    private readonly LoggingBehavior<SampleCommand, int> _behavior;

    public LoggingBehaviorTests()
    {
        _loggerMock = new Mock<ILogger<Mediator>>();
        _nextMock = new Mock<RequestHandlerDelegate<int>>();
        _behavior = new LoggingBehavior<SampleCommand, int>(_loggerMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldHandleRequestProperly()
    {
        // Arrange
        var request = new SampleCommand(Guid.NewGuid());
        var response = 1;

        _nextMock.Setup(handler => handler()).ReturnsAsync(response);

        // Act
        var result = await _behavior.Handle(request, _nextMock.Object, CancellationToken.None);

        // Assert
        result.Should().Be(response);
        _nextMock.Verify(handler => handler(), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldHandleRequestProperlyWhenThrowsException()
    {
        // Arrange
        var request = new SampleCommand(Guid.NewGuid());

        _nextMock.Setup(handler => handler()).ThrowsAsync(new ValidationException(string.Empty));

        // Act
        await _behavior.Invoking(y => y.Handle(request, _nextMock.Object, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>();

        // Assert
        _nextMock.Verify(handler => handler(), Times.Once);
    }

    public record SampleCommand(Guid Id) : IRequest<int>;
}
