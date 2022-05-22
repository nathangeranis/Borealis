using Microsoft.Azure.Cosmos.Linq;
namespace Borealis.DataManagement
{
    public class CosmosRepository<T> where T : class
    {
        private static string DatabaseId;
        private static string ContainerId;
        private static ICosmosService CosmosService;
        public CosmosRepository(ICosmosService cosmosService)
        {
            CosmosService = cosmosService;
        }
        public void Initialize(string databaseId, string containerId)
        {
            DatabaseId = databaseId;
            ContainerId = containerId;
            CosmosService.Initialize(DatabaseId, ContainerId).Wait();
        }
        public async Task<T> GetSingleItemAsync(string id)
        {
            try
            {
                T item = await CosmosService.GetCosmosClient().GetContainer(DatabaseId, ContainerId).ReadItemAsync<T>(id, new PartitionKey(id));
                return (T)(dynamic)item;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                else
                {
                    throw;
                }
            }
        }
        public async Task<List<T>> GetItemsAsync()
        {
            try
            {
                var items = new List<T>();
                var query = CosmosService.GetCosmosClient().GetContainer(DatabaseId, ContainerId).GetItemLinqQueryable<T>().ToFeedIterator();
                while (query.HasMoreResults)
                {
                    var response = query.ReadNextAsync().Result;
                    items.AddRange(response.ToList());
                }
                return items;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
