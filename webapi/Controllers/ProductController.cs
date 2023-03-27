using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services.ProductService;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;          
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            var result = await _productService.GetSingleProduct(id);

            if (result == null)
                return NotFound("Product not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var results = await _productService.AddProduct(product);

            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> updateProduct(int id, Product request)
        {
            var results = await _productService.UpdateProduct(id, request);

            if (results == null)
                return NotFound("Product not found");

            return Ok(results);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteSingleProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result == null)
                return NotFound("product not found");

            return Ok(result);
        }
    }
}
