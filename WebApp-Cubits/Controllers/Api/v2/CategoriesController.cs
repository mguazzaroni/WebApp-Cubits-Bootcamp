using Microsoft.AspNetCore.Mvc;
using System;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Controllers.Api.v2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategoriesController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetList()
        {
            var response = _categoryLogic.GetList();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var response = _categoryLogic.GetById(id);

            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] CategoryDto dto)
        {
            var categoryId = _categoryLogic.Add(dto);

            return CreatedAtAction(nameof(Get), new { id = categoryId }, new { id = categoryId });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] CategoryDto dto)
        {
            _categoryLogic.Update(id, dto);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryLogic.Remove(id);

            return Ok();
        }
    }
}
