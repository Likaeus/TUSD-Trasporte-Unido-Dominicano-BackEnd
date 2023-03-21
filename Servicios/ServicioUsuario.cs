using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly tusddatabaseContext _context;

        public ServicioUsuario(tusddatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> Buscar() => await _context.Usuarios.ToListAsync();

        public async Task<Usuario> BuscarPorID(int id) => await _context.Usuarios.FindAsync(id);
        public async Task<Usuario> FindUser(string userName)=>await _context.Usuarios.FirstOrDefaultAsync(x =>x.Username==userName);

        public async Task Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var findUser =  _context.Usuarios.FirstOrDefault(x=>x.UserId==id);
            if(findUser is not null)
            {
                _context.Usuarios.Remove(findUser);
                _context.SaveChanges();
            }
           
           
        }
        public  async Task<Usuario> Modificar(int id, Usuario usuario)
        {
            var findUser =  _context.Usuarios.FirstOrDefault(x => x.UserId == id);
            if(findUser !=null)
            {
               
                findUser.Username = usuario.Username;
                findUser.Contrasena = usuario.Contrasena;
                findUser.Correo = usuario.Correo;
                findUser.TarjetaBancaria = usuario.TarjetaBancaria;
                findUser.TarjetaTransportes = usuario.TarjetaTransportes;
                findUser.TransaccionUsers = usuario.TransaccionUsers;
                findUser.TransaccionTerceroNavigations = usuario.TransaccionTerceroNavigations;
                findUser.FavoritoFavoritoNavigations = usuario.FavoritoFavoritoNavigations;
                findUser.FavoritoUsers = usuario.FavoritoUsers;
                findUser.Viajes = usuario.Viajes;

                await _context.SaveChangesAsync();
            }
            return findUser;
        }

    }
}
