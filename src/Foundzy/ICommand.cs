using MediatR;

namespace Foundzy;

public interface ICommand<out TResponse> : IRequest<TResponse>;
