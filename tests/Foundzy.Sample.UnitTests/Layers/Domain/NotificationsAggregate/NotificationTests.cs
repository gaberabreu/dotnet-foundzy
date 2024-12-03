using FluentAssertions;
using Foundzy.Sample.Layers.Domain.NotificationsAggregate;

namespace Foundzy.Sample.UnitTests.Layers.Domain.NotificationsAggregate;

public class NotificationTests
{
    [Fact]
    public void Ctor1_ShouldInstantiateProperly()
    {
        // Arrange
        var dateOcurred = DateTime.UtcNow;
        var source = "Source";
        var message = "Message";

        // Act
        var notification = new Notification(dateOcurred, source, message);

        // Assert
        notification.Id.Should().NotBeEmpty();
        notification.DateOccurred.Should().Be(dateOcurred);
        notification.Source.Should().Be(source);
        notification.Message.Should().Be(message);
    }

    [Fact]
    public void Ctor2_ShouldInstantiateProperly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dateOcurred = DateTime.UtcNow;
        var source = "Source";
        var message = "Message";

        // Act
        var notification = new Notification(id, dateOcurred, source, message);

        // Assert
        notification.Id.Should().Be(id);
        notification.DateOccurred.Should().Be(dateOcurred);
        notification.Source.Should().Be(source);
        notification.Message.Should().Be(message);
    }
}
