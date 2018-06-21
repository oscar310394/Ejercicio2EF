using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ejercicio2.Models
{
    public partial class MundialDBContext : DbContext
    {
        public virtual DbSet<DirectorT> DirectorT { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Seleccion> Seleccion { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MundialDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        */

        public MundialDBContext(DbContextOptions<MundialDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectorT>(entity =>
            {
                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.Property(e => e.Ciudad)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.Property(e => e.Club)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNac)
                    .HasColumnName("Fecha_Nac")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Posicion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSelNavigation)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.IdSel)
                    .HasConstraintName("FK_SeleccionJugador");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Local)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Visita)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadioNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.IdEstadio)
                    .HasConstraintName("FK_EstadioPartido");
            });

            modelBuilder.Entity<Seleccion>(entity =>
            {
                entity.Property(e => e.Confederacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDirectorTNavigation)
                    .WithMany(p => p.Seleccion)
                    .HasForeignKey(d => d.IdDirectorT)
                    .HasConstraintName("FK_TecnicoSeleccion");
            });
        }
    }
}
