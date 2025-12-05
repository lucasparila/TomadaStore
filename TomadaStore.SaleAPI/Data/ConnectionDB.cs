using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TomadaStore.Models.Models;
namespace TomadaStore.SaleAPI.Data
{
    public class ConnectionDB
    {
        private readonly IMongoCollection<Sale> mongoCollection;
        public ConnectionDB(IOptions<MongoDBSettings> mongoDBsettings)
        {
            IMongoClient mongoClient = new MongoClient(
                mongoDBsettings.Value.ConnectionURI
               );

            IMongoDatabase databe = mongoClient.GetDatabase(
                mongoDBsettings.Value.DatabaseName
                );
            mongoCollection = databe.GetCollection<Sale>(mongoDBsettings.Value.CollectionName);
        }
        public IMongoCollection<Sale> GetMongoCollection()
        {
            return mongoCollection;
        }
    }
}
