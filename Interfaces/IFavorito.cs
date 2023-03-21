using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Interfaces
{
    public interface IFavorito
    {
        Task<List<Favorito>> Buscar(int usuarioId);
        Task<Favorito> BuscarPorID(int usuarioId, int favoritoId);
        Task <Favorito>Crear(int usuarioId, int favoritoId);
        Task Eliminar(int favoritoId);
      
    }
}
