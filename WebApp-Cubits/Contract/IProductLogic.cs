using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Contract
{
    public interface IProductLogic
    {
        List<ProductDto> GetList();
        ProductDto GetById(Guid id);
        Guid Add(ProductDto prod);
        void Update(Guid id, ProductDto prod);
        void Remove(Guid id);
    }
}
