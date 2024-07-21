using Microsoft.Azure.Cosmos;

namespace CleanCodeArchitecture.Infrastructure.Cosmos.Data;

public class CosmosDatabaseClient
{
    private readonly CosmosClient _cosmosClient;

    public CosmosDatabaseClient(CosmosClient cosmosClient)
    {
        _cosmosClient = cosmosClient;
    }

    public Database GetDatabase()
    {
        return this._cosmosClient.GetDatabase("Sample");
    }
}