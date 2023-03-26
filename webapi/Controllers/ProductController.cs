using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase 
    {
        private static List<Product> products = new List<Product> {

            new Product { Id = 1, Name="Iphone", Price=900},
            new Product { Id = 2, Name = "AOC-monitor", Price = 500 }
        };

        [HttpGet]
        public async Task<ActionResult<Product>> GetAllProducts()
        {
            return Ok(products);
        }

        [HttpGet("id")] 
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var found = products.Find(x => x.Id == id);

            if (found == null)
                return NotFound("Product not found in db");

            return Ok(found);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            products.Add(product); 
            return Ok(products);
        }
    }
}
