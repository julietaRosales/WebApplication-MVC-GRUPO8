using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class creacionDBIncidencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagenIncidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaReporte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idEncargado = table.Column<int>(type: "int", nullable: false),
                    idTecnico = table.Column<int>(type: "int", nullable: false),
                    fechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sla = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    justificacionDescarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaInicioReparacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinReparacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descripcionGasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagenFinalIncidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prioridad = table.Column<int>(type: "int", nullable: false),
                    estadoIncidencia = table.Column<int>(type: "int", nullable: false),
                    complejidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencias");
        }
    }
}
