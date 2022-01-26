using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Data.Models;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Logic
{
    public class ProviderLogic : IProviderLogic
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderLogic(IProviderRepository providerRepository)
        {
            providerRepository = _providerRepository;
        }
        public List<ProviderDto> GetList()
        {
            var providerList = _providerRepository.GetList();

            return providerList.Select(p => new ProviderDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Address = p.Address
            }).ToList();
        }
        public ProviderDto GetById(Guid id)
        {
            var provider = _providerRepository.GetById(id);

            return new ProviderDto
            {
                Name = provider.Name,
                Description = provider.Description
            };
        }
        public Guid Add(ProviderDto provider)
        {
            var prov = new Provider
            {
                Name = provider.Name,
                Description = provider.Description
            };

            var id = _providerRepository.Add(prov);

            return id;
        }
        public void Update(Guid id, ProviderDto provider)
        {
            var prov = _providerRepository.GetById(id);

            prov.Name = provider.Name;
            prov.Description = provider.Description;
            prov.Address = provider.Address;

            _providerRepository.Update(prov);
        }
        public void Remove(Guid id)
        {
            var provider = _providerRepository.GetById(id);

            _providerRepository.Remove(provider);
        }
    }
}
