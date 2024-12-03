using FluentAssertions;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Infra.Data.Repositories;

namespace Foundzy.Sample.UnitTests.Infra.Data.Repositories;

public class NotificationRepositoryTests
{
    private readonly NotificationRepository _repository = new();

    [Fact]
    public async Task GetAll_ShouldReturnEntitiesProperly()
    {
        // Arrange
        var notification1 = new Notification("Source1", "Message1");
        var notification2 = new Notification("Source2", "Message2");

        await _repository.Add(notification1);
        await _repository.Add(notification2);

        // Act
        var notifications = await _repository.GetAll();

        // Assert
        notifications.Should().HaveCount(2);
        notifications.Should().Contain(notification1);
        notifications.Should().Contain(notification2);
    }

    [Fact]
    public async Task Add_ShouldAddProperly()
    {
        // Arrange
        var notification = new Notification("Source", "Message");

        // Act
        await _repository.Add(notification);

        // Assert
        _repository.Notifications.Should().HaveCount(1);
        _repository.Notifications.Should().Contain(notification);
    }
}