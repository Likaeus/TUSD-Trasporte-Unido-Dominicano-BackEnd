using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;

namespace TUSDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaTransporteController : ControllerBase
    {

        private readonly ITarjetaTransporte _servicioTtransporte;

        public TarjetaTransporteController(ITarjetaTransporte servicioTransporte)
        {
            _servicioTtransporte = servicioTransporte;
        }
        // GET: api/<TarjetaTransporteController>
        [HttpGet("Given-User/{usuarioId}")]
        public async Task<IActionResult> GetTarjetas(int usuarioId)
        {
            try
            {
                var getTarjetas = await _servicioTtransporte.GetTarjetaTransporte(usuarioId);
                return Ok(getTarjetas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TarjetaTransporteController>/5
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetByCardNumber(int cardNumber)
        {
            try
            {
                return Ok(await _servicioTtransporte.FindByNumber(cardNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TarjetaTransporteController>
        [HttpPost("{usuarioId}/{cardNumber}")]
        public async Task<IActionResult> AddTtransporte(int usuarioId, int cardNumber)
        {
            try
            {
                var addCard = await _servicioTtransporte.AddCard(usuarioId, cardNumber);
                return Ok(addCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE api/<TarjetaTransporteController>/5
        [HttpDelete("{cardNumber}")]
        public async Task<IActionResult> DeleteCard(int cardNumber)
        {

            await _servicioTtransporte.DeleteCard(cardNumber);

            return Ok();
        }
    }
}
