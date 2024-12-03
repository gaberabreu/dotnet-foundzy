namespace Foundzy.Sample.Domain.Entities;

public class Notification(Guid id, DateTime createdOn, string source, string message)
{
    public Guid Id { get; set; } = id;
    public DateTime CreatedOn { get; set; } = createdOn;
    public string Source { get; set; } = source;
    public string Message { get; set; } = message;

    public Notification(string source, string message) 
        : this(Guid.NewGuid(), DateTime.UtcNow, source, message) { }
}
