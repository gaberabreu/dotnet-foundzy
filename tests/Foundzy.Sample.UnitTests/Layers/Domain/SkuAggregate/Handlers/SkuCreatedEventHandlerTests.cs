using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate.Interfaces;
using Foundzy.Sample.Layers.Domain.SkuAggregate.Events;
using Foundzy.Sample.Layers.Domain.SkuAggregate.Handlers;
using Moq;

namespace Foundzy.Sample.UnitTests.Layers.Domain.SkuAggregate.Handlers;

public class SkuCreatedEventHandlerTests
{
    private readonly Mock<INotificationRepository> _repository;
    private readonly SkuCreatedEventHandler _handler;

    public SkuCreatedEventHandlerTests()
    {
        _repository = new Mock<INotificationRepository>();
        _handler = new(_repository.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddNotificationProperly()
    {
        // Arrange
        var @event = new SkuCreatedEvent(new("Name"));

        // Act
        await _handler.Handle(@event, CancellationToken.None);

        // Assert
        _repository.Verify(e => e.Add(It.IsAny<Notification>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
