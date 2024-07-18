using Dapper;
using ShopFlex.Products.Domain.Entities;
using ShopFlex.Products.Domain.Interfaces.Repositories;
using System.Data;

namespace ShopFlex.Products.Infrastructure.Data
{
    public class ProductRepository: IProductRepository
    {

        private readonly IDbConnection _dbConnection;

        public ProductRepository(DbConnectionFactory connectionFactory)
        {
            _dbConnection = connectionFactory.CreateConnection();
        }

        public async Task<List<Product>> GetAllAsync()
        {
                _dbConnection.Open();
                var result = _dbConnection.ExecuteScalar<int>("SELECT 1");
            // using (IDbConnection dbConnection = _dbConnection)
            // {
            //     dbConnection.Open();
            //     var result = dbConnection.ExecuteScalar<int>("SELECT 1");
            // }

            string sql = "SELECT Id, Name, Price FROM Products";
            var data = await _dbConnection.QueryAsync<Product>(sql);
            return (data).AsList();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            string sql = "SELECT Id, Name, Price FROM Products WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<Product> CreateAsync(Product product)
        {
            string sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT SCOPE_IDENTITY()";
            var productId = await _dbConnection.ExecuteScalarAsync<int>(sql, product);
            product.Id = productId;
            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            string sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            var rowsAffected = await _dbConnection.ExecuteAsync(sql, product);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string sql = "DELETE FROM Products WHERE Id = @Id";
            var rowsAffected = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }
    }
}