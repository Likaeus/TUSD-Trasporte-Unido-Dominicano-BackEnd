using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Interfaces
{
    public interface IViajes
    {
        Task<List<Viaje>> GetAllViajes(int usuarioId);
        Task<Viaje> GetViajeById(int viajeId);
        Task<Viaje> CreateViaje(int usuarioId, Viaje viaje);
        Task DeleteViaje(int viajeId);

    }
}
