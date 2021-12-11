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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetList()
        {
            var productList = _context
                .Set<Product>()
                .ToList();

            return Ok(productList);
        }


        // GET: api/<ProductsController>      
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = _context
                .Set<Product>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            var response = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            return Ok(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock
            };

            _context.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = model.Id }, new { id = model.Id });
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductViewModel model)
        {
            var product = _context
                 .Set<Product>()
                 .Where(p => p.Id == id)
                 .FirstOrDefault();

            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Stock = model.Stock;

            _context.Add(product);
            _context.SaveChanges();
                
            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = _context
                 .Set<Product>()
                 .Where(p => p.Id == id)
                 .FirstOrDefault();

            if (product == null)
                return NotFound();

            _context.Remove(product);
            _context.SaveChanges();


            return Ok();
        }
    }
}
