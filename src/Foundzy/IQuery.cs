using MediatR;

namespace Foundzy;

public interface IQuery<out TResponse> : IRequest<TResponse>;
