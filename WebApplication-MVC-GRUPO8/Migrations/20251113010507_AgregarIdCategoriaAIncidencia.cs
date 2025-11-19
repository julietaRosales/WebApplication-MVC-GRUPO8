using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class AgregarIdCategoriaAIncidencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCategoria",
                table: "Incidencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idCategoria",
                table: "Incidencias",
                column: "idCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Categorias_idCategoria",
                table: "Incidencias",
                column: "idCategoria",
                principalTable: "Categorias",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Categorias_idCategoria",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_idCategoria",
                table: "Incidencias");

            migrationBuilder.DropColumn(
                name: "idCategoria",
                table: "Incidencias");
        }
    }
}
