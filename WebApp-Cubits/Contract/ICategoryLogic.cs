using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Contract
{
    public interface ICategoryLogic
    {
        List<CategoryDto> GetList();

        CategoryDto GetById(Guid id);

        Guid Add(CategoryDto category);

        void Update(Guid id, CategoryDto category);
        
        void Remove(Guid id);
    }
}
