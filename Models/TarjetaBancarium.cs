using System;
using System.Collections.Generic;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class TarjetaBancarium
    {
        public TarjetaBancarium()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int TBancariaId { get; set; }
        public int? UserId { get; set; }
        public string Codigo { get; set; }
        public string Cvv { get; set; }
        public string CardHolder { get; set; }
        public DateTime? ExpDate { get; set; }
        public string TipoTarjeta { get; set; }

        public virtual Usuario User { get; set; }
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
