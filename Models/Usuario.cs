using System;
using System.Collections.Generic;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            FavoritoFavoritoNavigations = new HashSet<Favorito>();
            FavoritoUsers = new HashSet<Favorito>();
            TarjetaBancaria = new HashSet<TarjetaBancarium>();
            TarjetaTransportes = new HashSet<TarjetaTransporte>();
            TransaccionTerceroNavigations = new HashSet<Transaccion>();
            TransaccionUsers = new HashSet<Transaccion>();
            Viajes = new HashSet<Viaje>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Favorito> FavoritoFavoritoNavigations { get; set; }
        public virtual ICollection<Favorito> FavoritoUsers { get; set; }
        public virtual ICollection<TarjetaBancarium> TarjetaBancaria { get; set; }
        public virtual ICollection<TarjetaTransporte> TarjetaTransportes { get; set; }
        public virtual ICollection<Transaccion> TransaccionTerceroNavigations { get; set; }
        public virtual ICollection<Transaccion> TransaccionUsers { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
