using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class seForeignKeyIdUserDescar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idUserDescar",
                table: "Incidencias",
                column: "idUserDescar");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_idUserDescar",
                table: "Incidencias",
                column: "idUserDescar",
                principalTable: "Usuarios",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_idUserDescar",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_idUserDescar",
                table: "Incidencias");
        }
    }
}
