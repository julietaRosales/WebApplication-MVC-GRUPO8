using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class seAgregaFechaDescarte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaDescarte",
                table: "Incidencias",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaDescarte",
                table: "Incidencias");
        }
    }
}
