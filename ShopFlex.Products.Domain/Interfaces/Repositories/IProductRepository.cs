using ShopFlex.Products.Domain.Entities;

namespace ShopFlex.Products.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);

        IEnumerable<dynamic> GetEntitiesTest();
    }
}