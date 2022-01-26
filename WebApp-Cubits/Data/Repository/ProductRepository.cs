using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbConetxt;

        public ProductRepository(ApplicationDbContext dbConetxt)
        {
            _dbConetxt = dbConetxt;
        }

        public List<Product> GetList()
        {
            return _dbConetxt.Set<Product>().ToList();
        }
        public Product GetById(Guid id)
        {
            return _dbConetxt.Set<Product>()
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }
        public Guid Add(Product prod)
        {
            _dbConetxt.Add(prod);
            _dbConetxt.SaveChanges();

            return prod.Id;
        }

        public void Update(Product prod)
        {
            _dbConetxt.Update(prod);
            _dbConetxt.SaveChanges();
        }
        public void Remove(Product prod)
        {
            _dbConetxt.Remove(prod);
            _dbConetxt.SaveChanges();
        }
    }
}
