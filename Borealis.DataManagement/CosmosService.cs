using Microsoft.Extensions.Configuration;

using System.Configuration;

namespace Borealis.DataManagement
{
    public interface ICosmosService
    {
        abstract CosmosClient GetCosmosClient();
        abstract Task Initialize(string databaseId, string collectionId);
    }
    public class CosmosService : ICosmosService
    {
        private readonly IConfiguration _config;
        internal static CosmosClient Client;
        public CosmosService(IConfiguration config)
        {
            _config = config;
        }
        public async Task Initialize(string DatabaseId, string ContainerId)
        {
#if DEBUG
            string endPointUri = _config.GetSection("DevEndPointUri").Exists() ? _config.GetSection("DevEndPointUri").Value : "";
            string primaryKey = _config.GetSection("DevPrimaryKey").Exists() ? _config.GetSection("DevPrimaryKey").Value : "";
#else
            string endPointUri = _config.GetSection("EndPointUri").Exists() ? _config.GetSection("EndPointUri").Value : "";
            string primaryKey = _config.GetSection("PrimaryKey").Exists() ? _config.GetSection("PrimaryKey").Value : "";
#endif
            Client = new CosmosClient(endPointUri, primaryKey);
            CreateDatabaseIfNotExistsAsync(DatabaseId).Wait();
            CreateContainerIfNotExistsAsync(DatabaseId, ContainerId).Wait();
        }
        private static async Task CreateDatabaseIfNotExistsAsync(string DatabaseId)
        {
            try
            {
                Client.CreateDatabaseIfNotExistsAsync(DatabaseId).Wait();
            }
            catch (CosmosException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static async Task CreateContainerIfNotExistsAsync(string DatabaseId, string ContainerId)
        {
            try
            {
                Database d = Client.GetDatabase(DatabaseId);
                d.CreateContainerIfNotExistsAsync(new ContainerProperties(ContainerId, "/id")).Wait();
            }
            catch (CosmosException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public CosmosClient GetCosmosClient()
        {
            return Client;
        }
    }
}
