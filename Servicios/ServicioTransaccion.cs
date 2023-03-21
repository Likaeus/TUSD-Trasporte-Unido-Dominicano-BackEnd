using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public class ServicioTransaccion : ITransaccion
    {
        private readonly tusddatabaseContext _context;

        public ServicioTransaccion(tusddatabaseContext context)
        {
            _context = context;

        }
        public async  Task<Transaccion> CreateTransaccion(int usuarioId, Transaccion transaccion)
        {
            Transaccion tran = new Transaccion();
            tran.TransaccionId = transaccion.TransaccionId;
            tran.UserId = usuarioId;
            tran.TBancariaId = transaccion.TBancariaId;
            tran.Monto = transaccion.Monto;
            tran.TTransporteId = transaccion.TTransporteId;
            tran.Tercero = transaccion.Tercero;
            tran.FechaTransc = transaccion.FechaTransc;
            tran.TerceroId = transaccion.TerceroId ;

            await _context.Transaccions.AddAsync(tran);
            await _context.SaveChangesAsync();
            return tran;

        }
        public async Task<List<Transaccion>> GetAllTransacciones(int usuarioId)
        {
            return _context.Transaccions.Where(x => x.UserId == usuarioId).ToList();
        }
        public async Task<Transaccion> GetTransaccionById(int transaccionId) => await _context.Transaccions.FindAsync(transaccionId);

        public async Task DeleteTransaccion(int transaccionId)
        {
            var findTransac = await _context.Transaccions.FindAsync(transaccionId);
            _context.Remove(findTransac);
            await _context.SaveChangesAsync();
        }


    }
}
