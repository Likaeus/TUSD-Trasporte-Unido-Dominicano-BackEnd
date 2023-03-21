using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public class ServicioFavorito : IFavorito
    {
        private readonly tusddatabaseContext _context;

        public ServicioFavorito(tusddatabaseContext context)
        {
            _context = context;
        }

        public Task<List<Favorito>> Buscar(int usuarioId)
        {
            return _context.Favoritos.Where(x => x.UserId == usuarioId).ToListAsync();
           
        }

        public Task<Favorito> BuscarPorID(int usuarioId ,int favoritoId)
        {
            var getUser = _context.Favoritos.FirstOrDefault(x => x.UserId == usuarioId);

            return _context.Favoritos.Where(x => x.FavoritoId == favoritoId).FirstOrDefaultAsync();

        }

        public async Task<Favorito> Crear(int usuarioId, int favoritoId)
        {
            Favorito favorito= new Favorito();
            favorito.UserId = usuarioId;
            favorito.FavoritoId = favoritoId;
             await _context.Favoritos.AddAsync(favorito);
             await _context.SaveChangesAsync();
            return favorito;  
                
        }

        public async Task Eliminar(int favoritoId)
        {
            var findFavorito = _context.Favoritos.FirstOrDefault(x => x.FavoritoId == favoritoId);
            if (findFavorito is not null)
            {
                 _context.Favoritos.Remove(findFavorito);
                await _context.SaveChangesAsync();
            }
        }

    }
}
