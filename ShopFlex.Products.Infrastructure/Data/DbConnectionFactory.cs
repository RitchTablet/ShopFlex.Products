using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace ShopFlex.Products.Infrastructure.Data
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

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