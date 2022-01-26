using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetList()
        {
            return _dbContext.Set<Category>().ToList();
        }

        public Category GetById(Guid id)
        {
            return _dbContext.Set<Category>()
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public Guid Add(Category cat)
        {
            _dbContext.Add(cat);
            _dbContext.SaveChanges();

            return cat.Id;
        }

        public void Update(Category cat)
        {
            _dbContext.Update(cat);
            _dbContext.SaveChanges();
        }

        public void Remove(Category cat)
        {
            _dbContext.Remove(cat);
            _dbContext.SaveChanges();
        }
    }
}
