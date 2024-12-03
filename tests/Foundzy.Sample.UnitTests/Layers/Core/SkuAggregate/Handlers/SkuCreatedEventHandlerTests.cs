using Foundzy.Sample.Layers.Core.NotificationsAggregate;
using Foundzy.Sample.Layers.Core.SkuAggregate.Handlers;
using Foundzy.Sample.Layers.Core.SkuAggregate.Events;
using Moq;

namespace Foundzy.Sample.UnitTests.Layers.Core.SkuAggregate.Handlers;

public class SkuCreatedEventHandlerTests
{
    private readonly Mock<IRepository<Notification>> _repository;
    private readonly SkuCreatedEventHandler _handler;

    public SkuCreatedEventHandlerTests()
    {
        _repository = new Mock<IRepository<Notification>>();
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
        _repository.Verify(e => e.AddAsync(It.IsAny<Notification>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
