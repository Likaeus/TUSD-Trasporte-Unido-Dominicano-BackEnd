using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TUSDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaBancariaController : ControllerBase
    {
        private readonly ITarjetaBancaria _servicioTBancaria;

        public TarjetaBancariaController(ITarjetaBancaria servicioTBancaria)
        {
            _servicioTBancaria = servicioTBancaria;
        }
        // GET: api/<TarjetaBancariaController>
        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Get(int usuarioId)
        {
            try
            {
                var getTarjetas = await _servicioTBancaria.GetTarjetaBancaria(usuarioId);
                return Ok(getTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TarjetaBancariaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TarjetaBancariaController>
        [HttpPost("{usuarioId}")]
        public async Task<IActionResult> Post(int usuarioId, TarjetaBancarium tb)
        {
            try
            {
                var addCard = await _servicioTBancaria.LinkTarjeta(usuarioId,tb); 
                return Ok(addCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaBancariaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TarjetaBancariaController>/5
        [HttpDelete("{transaccionId}")]
        public async Task<IActionResult> DeleteCard(int transaccionId)
        {

            await _servicioTBancaria.DeleteCard(transaccionId);

            return Ok();
        }
    }
}
