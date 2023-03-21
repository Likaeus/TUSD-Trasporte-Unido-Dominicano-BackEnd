using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Interfaces
{
    public interface ITarjetaBancaria
    {
        Task<List<TarjetaBancarium>> GetTarjetaBancaria(int usuarioId);
        Task<TarjetaBancarium> FindTarjetaBankById(string cardNUmber);
        Task<TarjetaBancarium> LinkTarjeta(int usuarioId, TarjetaBancarium tb);
        
        Task DeleteCard(int tbId);
    }
}
