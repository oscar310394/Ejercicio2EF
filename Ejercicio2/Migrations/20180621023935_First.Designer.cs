﻿// <auto-generated />
using Ejercicio2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Ejercicio2.Migrations
{
    [DbContext(typeof(MundialDBContext))]
    [Migration("20180621023935_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ejercicio2.Models.DirectorT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nacionalidad")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("DirectorT");
                });

            modelBuilder.Entity("Ejercicio2.Models.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Capacidad");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Estadio");
                });

            modelBuilder.Entity("Ejercicio2.Models.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("Altura");

                    b.Property<string>("Club")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("FechaNac")
                        .HasColumnName("Fecha_Nac")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<int?>("IdSel");

                    b.Property<string>("Nombre")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<int?>("Numero");

                    b.Property<string>("Posicion")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdSel");

                    b.ToTable("Jugador");
                });

            modelBuilder.Entity("Ejercicio2.Models.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fecha")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("IdEstadio");

                    b.Property<string>("Local")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int?>("Marcador");

                    b.Property<string>("Visita")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdEstadio");

                    b.ToTable("Partido");
                });

            modelBuilder.Entity("Ejercicio2.Models.Seleccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Confederacion")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Grupo")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<int?>("IdDirectorT");

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdDirectorT");

                    b.ToTable("Seleccion");
                });

            modelBuilder.Entity("Ejercicio2.Models.Jugador", b =>
                {
                    b.HasOne("Ejercicio2.Models.Seleccion", "IdSelNavigation")
                        .WithMany("Jugador")
                        .HasForeignKey("IdSel")
                        .HasConstraintName("FK_SeleccionJugador");
                });

            modelBuilder.Entity("Ejercicio2.Models.Partido", b =>
                {
                    b.HasOne("Ejercicio2.Models.Estadio", "IdEstadioNavigation")
                        .WithMany("Partido")
                        .HasForeignKey("IdEstadio")
                        .HasConstraintName("FK_EstadioPartido");
                });

            modelBuilder.Entity("Ejercicio2.Models.Seleccion", b =>
                {
                    b.HasOne("Ejercicio2.Models.DirectorT", "IdDirectorTNavigation")
                        .WithMany("Seleccion")
                        .HasForeignKey("IdDirectorT")
                        .HasConstraintName("FK_TecnicoSeleccion");
                });
#pragma warning restore 612, 618
        }
    }
}
