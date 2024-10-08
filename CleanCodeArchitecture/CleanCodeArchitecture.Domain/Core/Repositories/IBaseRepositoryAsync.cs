using System.Linq.Expressions;
using CleanCodeArchitecture.Domain.Core.Entities;
using CleanCodeArchitecture.Domain.Core.Specifications;

namespace CleanCodeArchitecture.Domain.Core.Repositories;

public interface IBaseRepositoryAsync<T> : IDisposable, IAsyncDisposable where T : BaseEntity 
{
    Task<T?> GetByIdAsync(Guid id);
    IEnumerable<T> ListAllAsync();
    IEnumerable<T> ListAsync(Expression<Func<T, bool>> criteria);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria);
    Task<T> AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}