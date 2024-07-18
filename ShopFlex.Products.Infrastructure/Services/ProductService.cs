using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopFlex.Products.Domain.Entities;
using ShopFlex.Products.Domain.Interfaces.Repositories;
using ShopFlex.Products.Domain.Interfaces.Services;

namespace ShopFlex.Products.Infrastructure.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateAsync(product);
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
                return false;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            return await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
                return false;

            return await _productRepository.DeleteAsync(id);
        }
    }
}