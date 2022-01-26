using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data.Models;

namespace WebApp_Cubits.Contract
{
    public interface IProviderRepository
    {
        List<Provider> GetList();
        Provider GetById(Guid id);
        Guid Add(Provider provider);
        void Update(Provider provider);
        void Remove(Provider provider);
    }
}
