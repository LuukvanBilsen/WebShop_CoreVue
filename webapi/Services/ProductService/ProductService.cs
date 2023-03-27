using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly DatabaseContext _dbContext;

        public ProductService(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public async Task<List<Product>> AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var found = await _dbContext.Products.FindAsync(id);

            if (found == null)
                return null;

            _dbContext.Products.Remove(found);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync();

            return products;
        }

        public async Task<Product?> GetSingleProduct(int id)
        {
            var found = await _dbContext.Products.FindAsync(id);

            if (found == null)
                return null;

            return found;
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {
            var found = await _dbContext.Products.FindAsync(id);

            if (found == null)
                return null;

            found.Name = request.Name;
            found.Price = request.Price;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Products.ToListAsync();
        }
    }
}
