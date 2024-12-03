using Ardalis.Specification;

namespace Foundzy;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot;
