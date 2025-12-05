using TomadaStore.Utils.Factories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace TomadaStore.Utils.Factories
{
    internal class SQLDBConnectionImpl : IDBConnection
    {
        private readonly string _connectionString;
        private readonly IConfiguration configuration;
        public SQLDBConnectionImpl()
        {
            _connectionString = configuration.GetConnectionString("SqlServer");

        }

        public string ConnectionString()
        {
            return _connectionString;
        }
    }
}