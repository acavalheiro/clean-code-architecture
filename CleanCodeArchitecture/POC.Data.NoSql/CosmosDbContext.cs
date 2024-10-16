using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace POC.Data.NoSql
{
    public class CosmosDbContext : INoSqlDbContext
    {
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _container;

        public CosmosDbContext(string connectionString, string databaseName, string containerName)
        {


            this._client = new CosmosClient(connectionString);

            this._database = this._client.GetDatabase(databaseName);

            this._container = this._database.GetContainer(containerName);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<T> CreateItemAsync<T>(T item) where T : class
        {
            try
            {
                ItemResponse<T> result =  await this._container.CreateItemAsync(item);

                return result.Resource;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> CreateItemAsync<T>(T item, string partitionKey) where T : class
        {
            try
            {
                ItemResponse<T> result =  await this._container.CreateItemAsync(item, partitionKey: new PartitionKey(partitionKey));

                return result.Resource;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> ReadItemAsync<T>(string id, string partitionKKey) where T : class
        {
            try
            {
                ItemResponse<T> result =
                    await this._container.ReadItemAsync<T>(id, partitionKey: new PartitionKey(partitionKKey));

                return result.Resource;
            }
            catch (CosmosException ex)
                when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}