using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CRUDEfAdo.Net.Data
{
    public class DbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            return new SqlConnection(connectionString);
        }
    }
}
