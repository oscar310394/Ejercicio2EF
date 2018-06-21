using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ejercicio2.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectorT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nacionalidad = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estadio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacidad = table.Column<int>(nullable: true),
                    Ciudad = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seleccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Confederacion = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Grupo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    IdDirectorT = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seleccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TecnicoSeleccion",
                        column: x => x.IdDirectorT,
                        principalTable: "DirectorT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    IdEstadio = table.Column<int>(nullable: true),
                    Local = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Marcador = table.Column<int>(nullable: true),
                    Visita = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadioPartido",
                        column: x => x.IdEstadio,
                        principalTable: "Estadio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Altura = table.Column<double>(nullable: true),
                    Club = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Fecha_Nac = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    IdSel = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    Numero = table.Column<int>(nullable: true),
                    Posicion = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeleccionJugador",
                        column: x => x.IdSel,
                        principalTable: "Seleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_IdSel",
                table: "Jugador",
                column: "IdSel");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdEstadio",
                table: "Partido",
                column: "IdEstadio");

            migrationBuilder.CreateIndex(
                name: "IX_Seleccion_IdDirectorT",
                table: "Seleccion",
                column: "IdDirectorT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Seleccion");

            migrationBuilder.DropTable(
                name: "Estadio");

            migrationBuilder.DropTable(
                name: "DirectorT");
        }
    }
}
