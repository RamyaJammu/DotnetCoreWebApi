using DotnetCoreWebApi.Data;
using DotnetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreWebApi.SErvices
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _dbcontext;
        public ProductRepository(MyDBContext myDBContext)
        {
            _dbcontext= myDBContext;

        }
        public bool AddProduct(Product product)
        {
            try
            {
                _dbcontext.Products.Add(product);
                _dbcontext.SaveChanges();
                return true;
            }
            catch(Exception )
            {
                return false;
            }
            
        }

        public bool DeleteProduct(int id)
        {
            bool result = false;
            try
            {
                var product = _dbcontext.Products.Where(x => x.Id == id).FirstOrDefault();
                if(product!=null)
                {
                    _dbcontext.Products.Remove(product);
                    _dbcontext.SaveChanges();
                    result= true;
                }
            }
            catch(Exception)
            {
                result =false;
            }
            return result;

        }

        public List<Product> GetProductByCategory(string category)
        {
            var result = _dbcontext.Products.Where(x =>x.Category==category).ToList();
            return result;
        }

        public Product GetProductById(int id)
        {
            var product = _dbcontext.Products.Where(x => x.Id == id).FirstOrDefault();
            
            return product;

        }
            

        public List<Product> GetProducts()
        {
            var product = _dbcontext.Products.ToList();
            return product;
        }

        

        public bool UpdateProduct(Product Product)
        {
            var product = _dbcontext.Products.Where(x => x.Id == Product.Id).FirstOrDefault();
            if (product != null)
            {
                product.Name = Product.Name;
                product.Description = Product.Description;
                product.Category = Product.Category;
                product.Price = Product.Price;
                product.Rating = Product.Rating;
                product.ImageURL = Product.ImageURL;
                _dbcontext.Products.Update(product);
                _dbcontext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
