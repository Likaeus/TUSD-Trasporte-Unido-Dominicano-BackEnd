using System;
using System.Collections.Generic;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class Transaccion
    {
        public int TransaccionId { get; set; }
        public int? TBancariaId { get; set; }
        public int? UserId { get; set; }
        public int? TTransporteId { get; set; }
        public DateTime? FechaTransc { get; set; }
        public decimal? Monto { get; set; }
        public int? Tercero { get; set; }
        public int? TerceroId { get; set; }

        public virtual TarjetaBancarium TBancaria { get; set; }
        public virtual TarjetaTransporte TTransporte { get; set; }
        public virtual Usuario TerceroNavigation { get; set; }
        public virtual Usuario User { get; set; }
    }
}
