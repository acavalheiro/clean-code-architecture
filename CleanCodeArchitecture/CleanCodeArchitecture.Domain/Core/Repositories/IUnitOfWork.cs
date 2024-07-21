using System.Data;

namespace CleanCodeArchitecture.Domain.Core.Repositories;

public interface IUnitOfWork
{
    IDbTransaction BeginTransaction();
    Task<int> SaveChangesAsync();
    Task RollBackChangesAsync();
   
}