using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Interfaces
{
    public interface ITransaccion
    {
        Task<List<Transaccion>> GetAllTransacciones(int usuarioId);
        Task<Transaccion> GetTransaccionById(int transaccionId);
        Task<Transaccion> CreateTransaccion(int usuarioId, Transaccion transaccion);
        Task DeleteTransaccion(int transaccionId);
    }
}
