using FluentAssertions;
using Foundzy.Sample.Controllers;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.UseCases.Notifications.List;
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
    public async Task List_ShouldDispatchQueryProperly()
    {
        // Arrange
        var notifications = new List<Notification>()
        {
            new(DateTime.UtcNow, "Source1", "Message1"),
            new(DateTime.UtcNow, "Source2", "Message2")
        };

        _mediator.Setup(e => e.Send(It.IsAny<ListNotificationsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(notifications);

        // Act
        var result = await _controller.List();

        // Assert
        result.Value.Should().HaveCount(2);
        result.Value.Should().Contain(notifications);

        _mediator.Verify(e => e.Send(It.IsAny<ListNotificationsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
