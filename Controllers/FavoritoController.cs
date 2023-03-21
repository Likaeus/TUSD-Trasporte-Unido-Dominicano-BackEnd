using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Servicios;


namespace TUSDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     
    public class FavoritoController : ControllerBase
    {
        private readonly IFavorito _servicioFavorito;

        public FavoritoController(IFavorito servicioFavorito)
        {
            _servicioFavorito = servicioFavorito;
        }

        // GET: api/<FavoritoController>
        [HttpGet("Given-User/{usuarioId}")]
        public async Task <IActionResult> GetAllFavoritos(int usuarioId)
        {
            try
            {
                var getFavoritos = await _servicioFavorito.Buscar(usuarioId);
                return Ok(getFavoritos);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

        // GET api/<FavoritoController>/5
        [HttpGet("{favoritoId}")]
        public async Task<IActionResult> Get(int usuarioId,int favoritoId)
        {
            try
            {
                var getFavoritoById = await _servicioFavorito.BuscarPorID(usuarioId,favoritoId);
                return Ok(getFavoritoById);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<FavoritoController>
        [HttpPost("{usuarioId}/{favoritoId}")]
        public async Task<IActionResult> AddFavorito(int usuarioId, int favoritoId)
        {
            try
            {
                var createFavorito =  await _servicioFavorito.Crear(usuarioId, favoritoId);
                return Ok(createFavorito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
        // DELETE api/<FavoritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
