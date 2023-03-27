using webapi.Models;

namespace webapi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product> {

            new Product { Id = 0, Name="Samsung Galaxy a33", Price=99900},
            new Product { Id = 1, Name="Iphone", Price=120000},
            new Product { Id = 2, Name = "AOC-monitor", Price = 500 }
        };

        public List<Product> AddProduct(Product product)
        {
            products.Add(product);
            return products;
        }

        public List<Product>? DeleteProduct(int id)
        {
            var found = products.Find(x => x.Id == id);

            if (found == null)
                return null;

            products.Remove(found);

            return products;
        }

        public List<Product> GetAllProducts()
        {
            return products.ToList();
        }

        public Product? GetSingleProduct(int id)
        {
            var found = products.Find(x => x.Id == id);

            if (found == null)
                return null;

            return found;
        }

        public List<Product>? UpdateProduct(int id, Product request)
        {
            var found = products.Find(x => x.Id == id);

            if (found == null)
                return null;

            found.Id = request.Id; // ToDo ?
            found.Name = request.Name;
            found.Price = request.Price;

            return products;
        }
    }
}
