using System.Collections.Generic;
using System.Linq;
using CoreWEBAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWEBAPI.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ProductModel GetProduct(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _dbContext.Products.AsEnumerable();
        }

        public void AddProduct(ProductModel product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void AddProducts(ICollection<ProductModel> products)
        {
            foreach (var product in products)
            {
                _dbContext.Products.Add(product);
            }
            _dbContext.SaveChanges();
        }
    }
}