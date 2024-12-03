using Ardalis.Specification.EntityFrameworkCore;

namespace Foundzy.Sample.Layers.Infrastructure.Data;

public class EfRepository<T>(FoundzyContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot;
