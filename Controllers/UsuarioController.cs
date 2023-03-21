using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;
using TUSDWebApi.Servicios;

namespace TUSDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicioUsuario _servicioUsuario;

        public UsuarioController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _servicioUsuario.Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/<UsuarioController>
        [HttpGet("Given-UserName/{userName}")]
        public async Task<IActionResult> GetUserName(string userName)
        {
            try
            {
                return Ok(await _servicioUsuario.FindUser(userName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _servicioUsuario.BuscarPorID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            try
            {
                return Ok(await _servicioUsuario.BuscarPorUsername(username));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                await _servicioUsuario.Crear(usuario);
                //return CreatedAtRoute("GetEmpleado", new { id = emp.Id }, emp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            var updateUser =  await _servicioUsuario.Modificar(id, usuario);
            return Ok(updateUser);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicioUsuario.Eliminar(id);

            return Ok();

        }
    }
}
