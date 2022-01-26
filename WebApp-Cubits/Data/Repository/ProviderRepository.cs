using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Data.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProviderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Provider> GetList()
        {
            return _dbContext.Set<Provider>().ToList();
        }
        
        public Provider GetById(Guid id)
        {
            return _dbContext.Set<Provider>()
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public Guid Add(Provider prov)
        {
            _dbContext.Add(prov);
            _dbContext.SaveChanges();

            return prov.Id;
        }

        public void Update(Provider prov)
        {
            _dbContext.Update(prov);
            _dbContext.SaveChanges();
        }

        public void Remove(Provider prov)
        {
            _dbContext.Remove(prov);
            _dbContext.SaveChanges();
        }
    }
}
