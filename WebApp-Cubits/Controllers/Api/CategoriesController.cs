using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Data;
using WebApp_Cubits.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Cubits.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult GetList()
        {
            var categoryList = _dbContext
                .Set<Category>()
                .ToList();

            return Ok(categoryList);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var category = _dbContext
                .Set<Category>()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (category == null)
                return NotFound();

            var response = new Category
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Category model)
        {
            var category = new Category
            {
                Name = model.Name
            };

            _dbContext.Add(category);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = category.Id }, new { id = category.Id });
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category model)
        {
            var category = _dbContext
                .Set<Category>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (category == null)
                return NotFound();

            category.Name = model.Name;

            _dbContext.Update(category);
            _dbContext.SaveChanges();

            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? id)
        {
            var category = _dbContext
                .Set<Category>()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (category == null)
                return NotFound();

            _dbContext.Remove(category);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
