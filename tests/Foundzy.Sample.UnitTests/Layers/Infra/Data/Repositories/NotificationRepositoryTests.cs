﻿using FluentAssertions;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate;
using Foundzy.Sample.Layers.Infra.Data.Repositories;

namespace Foundzy.Sample.UnitTests.Layers.Infra.Data.Repositories;

public class NotificationRepositoryTests
{
    private readonly NotificationRepository _repository = new();

    [Fact]
    public async Task GetAll_ShouldReturnEntitiesProperly()
    {
        // Arrange
        var notification1 = new Notification(DateTime.UtcNow, "Source1", "Message1");
        var notification2 = new Notification(DateTime.UtcNow, "Source2", "Message2");

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
        var notification = new Notification(DateTime.UtcNow, "Source", "Message");

        // Act
        await _repository.Add(notification);

        // Assert
        _repository.Notifications.Should().HaveCount(1);
        _repository.Notifications.Should().Contain(notification);
    }
}