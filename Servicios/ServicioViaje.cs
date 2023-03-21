using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public class ServicioViaje : IViajes
    {
        private readonly tusddatabaseContext _context;

        public ServicioViaje(tusddatabaseContext context)
        {
            _context = context;

        }
        public async Task<Viaje> CreateViaje(int usuarioId, Viaje viaje)
        {
            Viaje nuevoViaje = new Viaje();
            nuevoViaje.ViajeId = viaje.ViajeId;
            nuevoViaje.UserId = usuarioId;
            nuevoViaje.FechaViaje = viaje.FechaViaje;
            nuevoViaje.Partida = viaje.Partida;
            nuevoViaje.Destino = viaje.Destino;
            nuevoViaje.Descripcion = viaje.Descripcion;

            await _context.Viajes.AddAsync(nuevoViaje);
            await _context.SaveChangesAsync();
            return nuevoViaje;
        }


        public async Task<List<Viaje>> GetAllViajes(int usuarioId)
        {
            return _context.Viajes.Where(x => x.UserId == usuarioId).ToList();
        }

        public async Task<Viaje> GetViajeById(int viajeId) => await _context.Viajes.FindAsync(viajeId);
        public async  Task DeleteViaje(int viajeId)
        {
            var findTransac = await _context.Viajes.FindAsync(viajeId);
            _context.Remove(findTransac);
            await _context.SaveChangesAsync();
        }
    }
}
