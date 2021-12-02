using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Cubits.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly string CacheKey = "Category";

        public CategoriesController(IMemoryCache cache)
        {
            _cache = cache;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult GetList()
        {
            var categoryList = _cache.Get<List<Category>>(CacheKey) ?? new List<Category>();

            return Ok(categoryList);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var categoryList = _cache.Get<List<Category>>(CacheKey) ?? new List<Category>();
            var category = categoryList.Where(c => c.Id == id);

            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] Category model)
        {
            model.Id = Guid.NewGuid();

            var categoryList = _cache.Get<List<Category>>(CacheKey) ?? new List<Category>();

            categoryList.Add(model);

            _cache.Set(CacheKey, categoryList);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, new { id = model.Id });
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Category model)
        {
            var categoryList = _cache.Get<List<Category>>(CacheKey) ?? new List<Category>();

            var category = categoryList
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();
            //Remuevo
            categoryList.Remove(category);
            //Edito
            category.Name = model.Name;
            //Agrego
            categoryList.Add(category);
            //Guardo
            _cache.Set(CacheKey, categoryList);

            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            var categoryList = _cache.Get<List<Category>>(CacheKey);

            var category = categoryList
                .Where(x => x.Id == id)
                .FirstOrDefault();
            //Remuevo
            categoryList.Remove(category);

            _cache.Set(CacheKey, categoryList);

            return Ok(category);
        }
    }
}
