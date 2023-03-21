using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Interfaces;
using TUSDWebApi.Models;

namespace TUSDWebApi.Servicios
{
    public class ServicioTBancaria:ITarjetaBancaria
    {
        private readonly tusddatabaseContext _context;

        public ServicioTBancaria(tusddatabaseContext context)
        {
            _context = context;

        }
        public async Task<List<TarjetaBancarium>> GetTarjetaBancaria(int usuarioId)
        {
            return _context.TarjetaBancaria.Where(x => x.UserId == usuarioId).ToList();
        }
        public async Task<TarjetaBancarium> FindTarjetaBankById(string cardNumber) => await _context.TarjetaBancaria.FindAsync(cardNumber);

        public async Task<TarjetaBancarium> LinkTarjeta(int usuarioId, TarjetaBancarium tb)
        {
            TarjetaBancarium tBank = new TarjetaBancarium();
            tBank.TBancariaId = tb.TBancariaId;
            tBank.UserId = usuarioId;
            tBank.Codigo = tb.Codigo;
            tBank.CardHolder = tb.CardHolder;
            tBank.Cvv = tb.Cvv;
            tBank.ExpDate = tb.ExpDate;
            tBank.TipoTarjeta = tb.TipoTarjeta;

            await _context.TarjetaBancaria.AddAsync(tBank);
            await _context.SaveChangesAsync();
            return tBank;
        }

        public async Task DeleteCard(int tbId)
        {
            var findTarjeta = await _context.TarjetaBancaria.FindAsync(tbId);
            _context.Remove(findTarjeta);
            await _context.SaveChangesAsync();
        }

       

        
    }
}
