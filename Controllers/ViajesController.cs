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
    public class ViajesController : ControllerBase
    {
        private readonly IViajes _servicioViajes;

        public ViajesController(IViajes servicioViajes)
        {
            _servicioViajes = servicioViajes;
        }
        // GET: api/<ViajesController>
        [HttpGet("Given-User/{usuarioId}")]
        public async Task<IActionResult> GetAllVIajes(int usuarioId)
        {
            try
            {
                var getViajes = await _servicioViajes.GetAllViajes(usuarioId);
                return Ok(getViajes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ViajesController>/5
        [HttpGet("{viajeId}")]
        public async Task<IActionResult> GetTransaccionById(int viajeId)
        {
            try
            {
                return Ok(await _servicioViajes.GetViajeById(viajeId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ViajesController>
        [HttpPost("{usuarioId}")]
        public async Task<IActionResult> Post(int usuarioId, [FromBody] Viaje viaje)
        {
            try
            {
                var createTransaccion = await _servicioViajes.CreateViaje(usuarioId, viaje);
                return Ok(createTransaccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         // DELETE api/<ViajesController>/5
        [HttpDelete("{viajeId}")]
        public async Task<IActionResult> DeleteViaje(int viajeId)
        {

            await _servicioViajes.DeleteViaje(viajeId);

            return Ok();
        }
    }
}
