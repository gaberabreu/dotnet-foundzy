using Ardalis.Specification;

namespace Foundzy;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot;
