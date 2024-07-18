using ShopFlex.Products.Application.Dtos;
using ShopFlex.Products.Domain.Entities;
using ShopFlex.Products.Domain.Interfaces.Services;

namespace ShopFlex.Products.Application.Services
{
    public class ProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                return MapToDto(products);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los productos", ex);
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return MapToDto(product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el producto con ID {id}", ex);
            }
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            try
            {
                var product = MapToEntity(productDto);
                var createdProduct = await _productService.CreateProductAsync(product);
                return MapToDto(createdProduct);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al crear el producto", ex);
            }
        }

        public async Task<bool> UpdateProductAsync(int id, ProductDto productDto)
        {
            try
            {
                var product = MapToEntity(productDto);
                return await _productService.UpdateProductAsync(id, product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el producto con ID {id}", ex);
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                return await _productService.DeleteProductAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al eliminar el producto con ID {id}", ex);
            }
        }

        
        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        private List<ProductDto> MapToDto(List<Product> products)
        {
            var productDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }

            return productDtos;
        }

        private Product MapToEntity(ProductDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price
            };
        }
    }
}