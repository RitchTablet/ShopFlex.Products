using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace ShopFlex.Products.Infrastructure.Data
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ShopFlexProductsConnection");
        }

        public IDbConnection CreateConnection()
        {
            
            return new SqlConnection(_connectionString);
        }
    }
}