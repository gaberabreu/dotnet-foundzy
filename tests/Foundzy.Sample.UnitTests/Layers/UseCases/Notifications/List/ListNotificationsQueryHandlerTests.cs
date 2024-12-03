using FluentAssertions;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate.Interfaces;
using Foundzy.Sample.Layers.UseCases.Notifications.List;
using Moq;

namespace Foundzy.Sample.UnitTests.Layers.UseCases.Notifications.List;

public class ListNotificationsQueryHandlerTests
{
    private readonly Mock<INotificationRepository> _repository;
    private readonly ListNotificationsQueryHandler _handler;

    public ListNotificationsQueryHandlerTests()
    {
        _repository = new Mock<INotificationRepository>();
        _handler = new(_repository.Object);
    }

    [Fact]
    public async Task Handle_ShouldListNotificationsProperly()
    {
        // Arrange
        var query = new ListNotificationsQuery();

        var notifications = new List<Notification>()
        {
            new("Source1", "Message1"),
            new("Source2", "Message2")
        };

        _repository.Setup(e => e.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(notifications);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(notifications);

        _repository.Verify(e => e.GetAll(It.IsAny<CancellationToken>()), Times.Once);
    }
}
