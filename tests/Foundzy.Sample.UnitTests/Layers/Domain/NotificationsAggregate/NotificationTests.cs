using FluentAssertions;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate;

namespace Foundzy.Sample.UnitTests.Layers.Domain.NotificationsAggregate;

public class NotificationTests
{
    [Fact]
    public void Ctor1_ShouldInstantiateProperly()
    {
        // Arrange
        var source = "Source";
        var message = "Message";

        // Act
        var notification = new Notification(source, message);

        // Assert
        notification.Id.Should().NotBeEmpty();
        notification.CreatedOn.Should().NotBe(DateTime.MinValue);
        notification.Source.Should().Be(source);
        notification.Message.Should().Be(message);
    }

    [Fact]
    public void Ctor2_ShouldInstantiateProperly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var createdOn = DateTime.UtcNow;
        var source = "Source";
        var message = "Message";

        // Act
        var notification = new Notification(id, createdOn, source, message);

        // Assert
        notification.Id.Should().Be(id);
        notification.CreatedOn.Should().Be(createdOn);
        notification.Source.Should().Be(source);
        notification.Message.Should().Be(message);
    }
}
