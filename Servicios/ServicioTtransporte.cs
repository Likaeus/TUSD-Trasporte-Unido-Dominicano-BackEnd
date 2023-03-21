using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public class ServicioTtransporte : ITarjetaTransporte

    {
        private readonly tusddatabaseContext _context;

        public ServicioTtransporte(tusddatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<TarjetaTransporte>> GetTarjetaTransporte(int usuarioId)
        {
            return _context.TarjetaTransportes.Where(x => x.UserId == usuarioId).ToList();
        }
        public async Task<TarjetaTransporte> FindByNumber(int cardNumber) => await _context.TarjetaTransportes.FindAsync(cardNumber);
        

        public async Task<TarjetaTransporte> AddCard(int usuarioId, int cardNumber)
        {
            TarjetaTransporte ttrans = new TarjetaTransporte();
            ttrans.UserId = usuarioId;
            ttrans.TTransporteId = cardNumber;
            await _context.TarjetaTransportes.AddAsync(ttrans);
            await _context.SaveChangesAsync();
            return ttrans;
        }

        public async Task DeleteCard(int cardNumber)
        {
            var findTarjeta = await _context.TarjetaTransportes.FindAsync(cardNumber);
            _context.Remove(findTarjeta); 
            await _context.SaveChangesAsync();
        }

        public async Task AddFunds(int quantity)
        {
            throw new NotImplementedException();
        }

    }
}
