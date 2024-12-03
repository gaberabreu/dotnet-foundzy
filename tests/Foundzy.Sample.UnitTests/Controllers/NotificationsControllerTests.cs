using FluentAssertions;
using Foundzy.Sample.Application.Queries;
using Foundzy.Sample.Controllers;
using Foundzy.Sample.Domain.Entities;
using MediatR;
using Moq;

namespace Foundzy.Sample.UnitTests.Controllers;

public class NotificationsControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly NotificationsController _controller;

    public NotificationsControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _controller = new(_mediator.Object);
    }

    [Fact]
    public async Task Add_ShouldDispatchQueryProperly()
    {
        // Arrange
        var notifications = new List<Notification>()
        {
            new("Source1", "Message1"),
            new("Source2", "Message2")
        };

        _mediator.Setup(e => e.Send(It.IsAny<GetNotificationsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(notifications);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Value.Should().HaveCount(2);
        result.Value.Should().Contain(notifications);

        _mediator.Verify(e => e.Send(It.IsAny<GetNotificationsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
