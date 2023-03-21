using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TUSDWebApi.Models
{
    public partial class tusddatabaseContext : DbContext
    {
        public tusddatabaseContext()
        {
        }

        public tusddatabaseContext(DbContextOptions<tusddatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<TarjetaBancarium> TarjetaBancaria { get; set; }
        public virtual DbSet<TarjetaTransporte> TarjetaTransportes { get; set; }
        public virtual DbSet<Transaccion> Transaccions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FavoritoId })
                    .HasName("PK__favorito__48C7AD8CC74FCAAE");

                entity.ToTable("favoritos");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.FavoritoId).HasColumnName("favoritoID");

                entity.HasOne(d => d.FavoritoNavigation)
                    .WithMany(p => p.FavoritoFavoritoNavigations)
                    .HasForeignKey(d => d.FavoritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favoritos__favor__5FB337D6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoritoUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favoritos__userI__5EBF139D");
            });

            modelBuilder.Entity<TarjetaBancarium>(entity =>
            {
                entity.HasKey(e => e.TBancariaId)
                    .HasName("PK__tarjetaB__0D4126121B08D3C6");

                entity.ToTable("tarjetaBancaria");

                entity.Property(e => e.TBancariaId)
                    .ValueGeneratedNever()
                    .HasColumnName("tBancariaID");

                entity.Property(e => e.CardHolder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cardHolder");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cvv");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("date")
                    .HasColumnName("expDate");

                entity.Property(e => e.TipoTarjeta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tipoTarjeta");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TarjetaBancaria)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tarjetaBa__userI__656C112C");
            });

            modelBuilder.Entity<TarjetaTransporte>(entity =>
            {
                entity.HasKey(e => e.TTransporteId)
                    .HasName("PK__tarjetaT__8ADAB56DD9308091");

                entity.ToTable("tarjetaTransporte");

                entity.Property(e => e.TTransporteId)
                    .ValueGeneratedNever()
                    .HasColumnName("tTransporteID");

                entity.Property(e => e.MontoActual)
                    .HasColumnType("money")
                    .HasColumnName("montoActual");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TarjetaTransportes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tarjetaTr__userI__628FA481");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.ToTable("transaccion");

                entity.Property(e => e.TransaccionId).HasColumnName("transaccionID");

                entity.Property(e => e.FechaTransc)
                    .HasColumnType("date")
                    .HasColumnName("fechaTransc");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.TBancariaId).HasColumnName("tBancariaID");

                entity.Property(e => e.TTransporteId).HasColumnName("tTransporteID");

                entity.Property(e => e.Tercero).HasColumnName("tercero");

                entity.Property(e => e.TerceroId).HasColumnName("terceroID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.TBancaria)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.TBancariaId)
                    .HasConstraintName("FK__transacci__tBanc__693CA210");

                entity.HasOne(d => d.TTransporte)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.TTransporteId)
                    .HasConstraintName("FK__transacci__tTran__6B24EA82");

                entity.HasOne(d => d.TerceroNavigation)
                    .WithMany(p => p.TransaccionTerceroNavigations)
                    .HasForeignKey(d => d.TerceroId)
                    .HasConstraintName("FK__transacci__terce__6D0D32F4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransaccionUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__transacci__userI__6A30C649");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__usuario__CB9A1CDF7712BF73");

                entity.ToTable("usuario");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.ToTable("viajes");

                entity.Property(e => e.ViajeId).HasColumnName("viajeID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Destino)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("destino");

                entity.Property(e => e.FechaViaje)
                    .HasColumnType("date")
                    .HasColumnName("fechaViaje");

                entity.Property(e => e.Partida)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("partida");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__viajes__userID__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
