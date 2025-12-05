using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TomadaStore.Models.Models;

namespace TomadaStore.ProductAPI.Data
{
    public class ConnectionDB
    {
        private readonly IMongoCollection<Product> mongoCollection;
        public ConnectionDB(IOptions<MongoDBSettings> mongoDBsettings)
        {
            MongoClient mongoClient = new MongoClient(
                mongoDBsettings.Value.ConnectionURI
               );

            IMongoDatabase databe = mongoClient.GetDatabase(
                mongoDBsettings.Value.DatabaseName
                );
            mongoCollection = databe.GetCollection<Product>(mongoDBsettings.Value.CollectionName);
        }
        public IMongoCollection<Product> GetMongoCollection()
        {
            return mongoCollection;
        }
    }
}
