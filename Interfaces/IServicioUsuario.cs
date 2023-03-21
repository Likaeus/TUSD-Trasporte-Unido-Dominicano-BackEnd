using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public interface IServicioUsuario
    {
        Task<List<Usuario>> Buscar();
        Task<Usuario> BuscarPorID(int id);
        Task<Usuario> FindUser(string userName);
        Task Crear(Usuario usuario);
        Task Eliminar(int id);
        Task<Usuario> Modificar(int id, Usuario usuario);
    }
}
