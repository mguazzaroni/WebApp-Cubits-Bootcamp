using Microsoft.AspNetCore.Mvc;
using System;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Controllers.Api.v2
{
    [ApiController]
    [Route("api/v2/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductsController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetList()
        {
            var response = _productLogic.GetList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var response = _productLogic.GetById(id);

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProductDto dto)
        {
            var productId = _productLogic.Add(dto);

            return CreatedAtAction(nameof(Get), new { id = productId }, new { id = productId });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductDto dto)
        {
            _productLogic.Update(id, dto);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productLogic.Remove(id);

            return Ok();
        }
    }
}
