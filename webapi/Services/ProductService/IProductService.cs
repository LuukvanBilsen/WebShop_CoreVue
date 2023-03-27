using webapi.Models;

namespace webapi.Services.ProductService
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetSingleProduct(int id);
        List<Product> AddProduct(Product product);
        List<Product>? UpdateProduct(int id, Product request);
        List<Product>? DeleteProduct(int id);
    }
}
