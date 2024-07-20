using ShopFlex.Products.Domain.Entities;

namespace ShopFlex.Products.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        IEnumerable<dynamic> GetEntitiesTest();
    }
}