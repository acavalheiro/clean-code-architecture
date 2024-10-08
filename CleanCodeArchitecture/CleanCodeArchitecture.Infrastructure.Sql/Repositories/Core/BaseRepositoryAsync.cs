using System.Linq.Expressions;
using CleanCodeArchitecture.Domain.Core.Entities;
using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanCodeArchitecture.Infrastructure.Sql.Repositories.Core;

public abstract class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity 
{
    public DbSet<T> DbSet { get; internal set; }

    private readonly ApplicationContext _dbContext;

    private readonly ILogger<BaseRepositoryAsync<T>> _logger;
    
    protected BaseRepositoryAsync(ApplicationContext dbContext, ILogger<BaseRepositoryAsync<T>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        this.DbSet = _dbContext.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await this.DbSet.FindAsync(id);
    }

    public IEnumerable<T> ListAllAsync()
    {
        return  this.DbSet.AsEnumerable();
    }

    public IEnumerable<T> ListAsync(Expression<Func<T, bool>> criteria)
    {
        IQueryable<T> query = this.DbSet.AsQueryable();

        query = query.Where(criteria);

        return query.AsEnumerable();
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria)
    {
        IQueryable<T> query = this.DbSet.AsQueryable();

        query = query.Where(criteria);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await this.DbSet.AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        this.DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        this.DbSet.Remove(entity);
    }
    
    #region "Dispose"
    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
            _dbContext?.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~BaseRepositoryAsync()
    {
        Dispose(false);
    }


    private async ValueTask DisposeAsyncCore()
    {
        ReleaseUnmanagedResources();

        if (_dbContext != null) await _dbContext.DisposeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    #endregion



}