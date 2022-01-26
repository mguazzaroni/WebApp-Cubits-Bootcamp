using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Contract
{
    public interface IProductRepository
    {
        List<Product> GetList();
        Product GetById(Guid id);
        Guid Add(Product prod);
        void Update(Product prod);
        void Remove(Product prod);
    }
}
