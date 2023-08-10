using RabbitMqApi.DTO;

namespace RabbitMqApi.Services
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<bool> DeleteProductAsync(int Id);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<Product> UpdateProductAsync(Product product);
    }
}