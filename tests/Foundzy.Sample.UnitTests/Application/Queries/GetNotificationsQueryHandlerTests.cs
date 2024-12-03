using FluentAssertions;
using Foundzy.Sample.Application.Queries;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;
using Moq;

namespace Foundzy.Sample.UnitTests.Application.Queries;

public class GetNotificationsQueryHandlerTests
{
    private readonly Mock<INotificationRepository> _repository;
    private readonly GetNotificationsQueryHandler _handler;

    public GetNotificationsQueryHandlerTests()
    {
        _repository = new Mock<INotificationRepository>();
        _handler = new(_repository.Object);
    }

    [Fact]
    public async Task Handle_ShouldGetSkusProperly()
    {
        // Arrange
        var query = new GetNotificationsQuery();

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
