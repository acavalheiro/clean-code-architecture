using System.Data;
using CleanCodeArchitecture.Domain.Core.Repositories;
using CleanCodeArchitecture.Infrastructure.Sql.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanCodeArchitecture.Infrastructure.Sql.Repositories.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _applicationContext;

    public UnitOfWork(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public IDbTransaction BeginTransaction()
    {
        return this._applicationContext.Database.BeginTransaction().GetDbTransaction();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await this._applicationContext.SaveChangesAsync();
    }

    public async Task RollBackChangesAsync()
    {
        await this._applicationContext.Database.RollbackTransactionAsync();
    }
}