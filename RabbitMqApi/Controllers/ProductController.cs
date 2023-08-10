using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMqApi.DTO;
using RabbitMqApi.RabbitMQ;
using RabbitMqApi.Services;

namespace RabbitMqApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public ProductController(IProductService productService, IRabitMQProducer rabitMQProducer)
        {
            _productService = productService;
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet("productlist")]
        public async Task <IEnumerable<Product>> ProductList()
        {
            var productList = _productService.GetProductListAsync();
            return await productList;
        }
        [HttpGet("getproductbyid")]
        public async Task<Product> GetProductById(int Id)
        {
            return await _productService.GetProductByIdAsync(Id);
        }
        [HttpPost("addproduct")]
        public async Task<Product> AddProduct(Product product)
        {
            var productData = _productService.AddProductAsync(product);
          
            _rabitMQProducer.SendProductMessage(productData);
            return await productData;
        }
        [HttpPut("updateproduct")]
        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productService.UpdateProductAsync(product);
        }
        [HttpDelete("deleteproduct")]
        public async Task<bool> DeleteProduct(int Id)
        {
            return await _productService.DeleteProductAsync(Id);
        }



    }
}
