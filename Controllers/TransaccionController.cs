using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

namespace TUSDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccion _servicioTransaccion;

        public TransaccionController(ITransaccion servicioTransaccion)
        {
            _servicioTransaccion = servicioTransaccion;
        }

        // GET: api/<TransaccionController>
        [HttpGet("Given-User/{usuarioId}")]
        public async Task<IActionResult> GetAllTransactions(int usuarioId)
        {
            try
            {
                var getTransacciones = await _servicioTransaccion.GetAllTransacciones(usuarioId);
                return Ok(getTransacciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TransaccionController>/5
        [HttpGet("{transaccionId}")]
        public async Task<IActionResult> GetTransaccionById(int transaccionId)   
        {
            try
            {
                return Ok(await _servicioTransaccion.GetTransaccionById(transaccionId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TransaccionController>
        [HttpPost("{usuarioId}")]
        public async Task<IActionResult> Post(int usuarioId,[FromBody] Transaccion transaccion)
        {
            try
            {
                var createTransaccion = await _servicioTransaccion.CreateTransaccion(usuarioId, transaccion);
                return Ok(createTransaccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TransaccionController>/5
        [HttpDelete("{transaccionId}")]
        public async Task<IActionResult> DeleteTransaccion(int transaccionId)
        {

            await _servicioTransaccion.DeleteTransaccion(transaccionId);

            return Ok();
        }
    }
}
