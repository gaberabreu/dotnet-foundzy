using MediatR;

namespace Foundzy;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>;