using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Repository
{
    public class DocdbRepository<T> : IDocDbRepository<T> where T : class
    {
        private static readonly string DatabaseId = "MasterDb";
        private static readonly string CollectionId = "Products";
        private static readonly string Endpoint = "https://localhost:8081";
        private static readonly string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private Container container = null;
        private CosmosClient client;

        public async Task CreateItemAsync(T item)
        {
            await CreateItems(item);
        }

        public Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            client = new CosmosClient(Endpoint, Key);
            CreateDatabaseIfNotExistsAsync().Wait();
        }

        public Task<T> UpdateItemAsync(string id, T item)
        {
            throw new NotImplementedException();
        }

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                Database cosmosDatabase = await client.CreateDatabaseIfNotExistsAsync(DatabaseId);
                container = await GetOrCreateContainerAsync(cosmosDatabase, CollectionId);
                //await CreateItems(container);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<Container> GetOrCreateContainerAsync(Database database, string containerId)
        {
            ContainerProperties containerProperties = new ContainerProperties(id: containerId, partitionKeyPath: "/products");
            return await database.CreateContainerIfNotExistsAsync(containerProperties: containerProperties, throughput: 400);
        }

        private async Task CreateItems(T item)
        {
            try
            {
                await container.UpsertItemAsync<T>(item);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
