using System.Data;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;

namespace CompleteDeveloperNetwork_System.Infrastructure
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
