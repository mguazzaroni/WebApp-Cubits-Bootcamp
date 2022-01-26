using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Contract
{
    public interface ICategoryRepository
    {
        List<Category> GetList();
        Category GetById(Guid id);
        Guid Add(Category category);
        void Update(Category category);
        void Remove(Category category);
    }
}
