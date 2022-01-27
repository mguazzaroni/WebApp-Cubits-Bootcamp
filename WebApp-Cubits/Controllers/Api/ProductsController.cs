using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data;
using WebApp_Cubits.Models;

namespace WebApp_Cubits.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string CacheKey = "ProductList";
        private readonly IMemoryCache _cache;

        public ProductsController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetList()
        {
            var productList = _cache.Get<List<ProductViewModel>>(CacheKey) ?? new List<ProductViewModel>();

            return Ok(productList);
        }


        // GET: api/<ProductsController>      
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var productList = _cache.Get<List<ProductViewModel>>(CacheKey) ?? new List<ProductViewModel>();

            var product = productList.Where(p => p.Id == id).FirstOrDefault();

            if (product == null) return NotFound();

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProductViewModel model)
        {
            var productList = _cache.Get<List<ProductViewModel>>(CacheKey) ?? new List<ProductViewModel>();

            model.Id = Guid.NewGuid();

            productList.Add(model);

            _cache.Set(CacheKey, productList);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, new { id = model.Id });
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductViewModel model)
        {
            var productList = _cache.Get<List<ProductViewModel>>(CacheKey) ?? new List<ProductViewModel>();
            var product = productList.Where(p => p.Id == id).FirstOrDefault();
            
            if (product == null) return NotFound();

            productList.Remove(product);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Stock = model.Stock;

            productList.Add(product);

            _cache.Set(CacheKey, productList);

            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var productList = _cache.Get<List<ProductViewModel>>(CacheKey) ?? new List<ProductViewModel>();
            var product = productList.Where(p => p.Id == id).FirstOrDefault();

            if (product == null) return NotFound();

            productList.Remove(product);

            _cache.Set(CacheKey, productList);

            return Ok();
        }
    }
}
