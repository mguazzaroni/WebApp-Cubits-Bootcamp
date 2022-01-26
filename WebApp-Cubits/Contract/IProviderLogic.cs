using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Contract
{
    public interface IProviderLogic
    {
        List<ProviderDto> GetList();
        ProviderDto GetById(Guid id);
        Guid Add(ProviderDto provider);
        void Update(Guid id, ProviderDto provider);
        void Remove(Guid id);
    }
}
