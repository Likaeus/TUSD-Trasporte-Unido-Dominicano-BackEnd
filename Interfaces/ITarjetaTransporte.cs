using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSDWebApi.Models;

namespace TUSDWebApi.Interfaces
{
    public interface ITarjetaTransporte
    {
        Task<List<TarjetaTransporte>> GetTarjetaTransporte(int usuarioId);
        Task<TarjetaTransporte> FindByNumber(int cardNumber);
        Task<TarjetaTransporte> AddCard(int usuarioId, int cardNumber);
        Task DeleteCard(int cardNumber);


    }
}
