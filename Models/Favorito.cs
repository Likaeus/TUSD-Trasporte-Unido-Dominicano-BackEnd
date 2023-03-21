using System;
using System.Collections.Generic;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class Favorito
    {
        public int UserId { get; set; }
        public int FavoritoId { get; set; }

        public virtual Usuario FavoritoNavigation { get; set; }
        public virtual Usuario User { get; set; }
    }
}
