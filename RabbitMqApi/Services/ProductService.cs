using Microsoft.EntityFrameworkCore;
using RabbitMqApi.DB;
using RabbitMqApi.DTO;

namespace RabbitMqApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ConnectMssql _connectMssql;

        public ProductService(ConnectMssql connectMssql)
        {
            _connectMssql = connectMssql;
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await _connectMssql.Products.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _connectMssql.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            var result = await _connectMssql.Products.AddAsync(product);
            _connectMssql.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Product> UpdateProductAsync(Product product)
        {
            var result = _connectMssql.Products.Update(product);
            _connectMssql.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<bool> DeleteProductAsync(int Id)
        {
            var filteredData = await _connectMssql.Products.Where(x => x.ProductId == Id).FirstOrDefaultAsync();
            var result = _connectMssql.Remove(filteredData);
            _connectMssql.SaveChangesAsync();
            return result != null ? true : false;
        }
    }
}
