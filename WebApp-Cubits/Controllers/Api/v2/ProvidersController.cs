using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Contract;
using WebApp_Cubits.Models.Dto;

namespace WebApp_Cubits.Controllers.Api.v2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderLogic _providerLogic;

        public ProvidersController(IProviderLogic providerLogic)
        {
            _providerLogic = providerLogic;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetList()
        {
            var res = _providerLogic.GetList();

            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _providerLogic.GetById(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProviderDto dto)
        {
            var providerId = _providerLogic.Add(dto);

            return CreatedAtAction(nameof(Get), new { id = providerId }, new { id = providerId });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProviderDto dto)
        {
            _providerLogic.Update(id, dto);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _providerLogic.Remove(id);

            return Ok();
        }
    }
}
