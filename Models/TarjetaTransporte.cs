using System;
using System.Collections.Generic;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class TarjetaTransporte
    {
        public TarjetaTransporte()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int TTransporteId { get; set; }
        public int? UserId { get; set; }
        public decimal? MontoActual { get; set; }

        public virtual Usuario User { get; set; }
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
