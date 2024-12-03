namespace Foundzy.Sample.Layers.Core.NotificationsAggregate;

public class Notification(Guid id, DateTime dateOccurred, string source, string message) : IAggregateRoot
{
    public Guid Id { get; set; } = id;
    public DateTime DateOccurred { get; set; } = dateOccurred;
    public string Source { get; set; } = source;
    public string Message { get; set; } = message;

    public Notification(DateTime dateOccurred, string source, string message)
        : this(Guid.NewGuid(), dateOccurred, source, message) { }
}
