using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data;
using WebApp_Cubits.Data.Models;
using WebApp_Cubits.Models;

namespace WebApp_Cubits.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProvidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult getList()
        {
            var providerList = _context
                .Set<Provider>()
                .ToList();

            return Ok(providerList);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var provider = _context
                .Set<Provider>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (provider == null)
                return NotFound();

            var response = new ProviderViewModel
            {
                Name = provider.Name,
                Description = provider.Description,
                Address = provider.Address
            };

            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] ProviderViewModel model)
        {
            var provider = new Provider
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Address = model.Address
            };

            _context.Add(provider);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = provider.Id }, new { id = provider.Id });
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(Guid id, [FromBody] ProviderViewModel model)
        {
            var provider = _context
                .Set<Provider>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (provider == null)
                return NotFound();

            provider.Name = model.Name;
            provider.Description = model.Description;
            provider.Address = model.Address;

            _context.Update(provider);
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var provider = _context
                .Set<Provider>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (provider == null) return NotFound();

            _context.Remove(provider);
            _context.SaveChanges();

            return Ok();
        }
    }
}
