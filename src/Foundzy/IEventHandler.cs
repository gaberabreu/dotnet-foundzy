using MediatR;

namespace Foundzy;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent;
