using Foundzy.Sample.Application.Events;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;
using Moq;

namespace Foundzy.Sample.UnitTests.Application.Events;

public class SkuAddedEventHandlerTests
{
    private readonly Mock<INotificationRepository> _repository;
    private readonly SkuAddedEventHandler _handler;

    public SkuAddedEventHandlerTests()
    {
        _repository = new Mock<INotificationRepository>();
        _handler = new(_repository.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddNotificationProperly()
    {
        // Arrange
        var @event = new SkuAddedEvent(new("Name"));

        // Act
        await _handler.Handle(@event);

        // Assert
        _repository.Verify(e => e.Add(It.IsAny<Notification>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
