using FluentAssertions;

namespace Foundzy.UnitTests;

public class DomainEventBaseTest
{
    [Fact]
    public void Ctor_ShouldInstantiateProperly()
    {
        // Act
        var @event = new SampleEvent();

        // Assert
        @event.DateOccurred.Should().NotBe(DateTime.MinValue);
    }

    public class SampleEvent : DomainEventBase;
}
