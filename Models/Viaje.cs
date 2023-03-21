using System;
using System.Collections.Generic;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class Viaje
    {
        public int ViajeId { get; set; }
        public int? UserId { get; set; }
        public DateTime? FechaViaje { get; set; }
        public string Partida { get; set; }
        public string Destino { get; set; }
        public string Descripcion { get; set; }

        public virtual Usuario User { get; set; }
    }
}
