using DTI_Test.Domain.Models;
using DTI_Test.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DTI_Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                if (result.Count > 0)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
                var result = await _service.GetById(id);
                if (result != null)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] Product product)
        {
            try
            {
                // Pensando se retorno algo
                var result = await _service.Insert(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<ProductControlle
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] Product product)
        {
            try
            {
                var result = await _service.Update(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
