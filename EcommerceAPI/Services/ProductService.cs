using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        // Aplicação do Dependency Injection (DIP)
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Implementação dos métodos do serviço
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}