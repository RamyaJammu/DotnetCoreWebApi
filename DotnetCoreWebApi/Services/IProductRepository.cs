using DotnetCoreWebApi.Models;

namespace DotnetCoreWebApi.SErvices
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        List<Product> GetProductByCategory(string category);
        bool AddProduct(Product Product);
        bool UpdateProduct(Product Product);
        bool DeleteProduct(int id);

    }
}
