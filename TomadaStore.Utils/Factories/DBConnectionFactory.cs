using TomadaStore.Utils.Factories.Interfaces;

namespace TomadaStore.Utils.Factories
{
    public abstract class DBConnectionFactory
    {
        public abstract IDBConnection CreateConnection();

        public string GetConnectionString()
        { 
            var dbConnection = CreateConnection();
            return dbConnection.ConnectionString();
        }
    }
}
