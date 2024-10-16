using System;
using System.Threading.Tasks;

namespace POC.Data.NoSql
{
    public interface INoSqlDbContext : IDisposable
    {
        Task<T> CreateItemAsync<T>(T item) where T : class;
        Task<T> CreateItemAsync<T>(T item, string partitionKey) where T : class;

        Task<T> ReadItemAsync<T>(string id, string partitionKKey) where T : class;
        
    }
}