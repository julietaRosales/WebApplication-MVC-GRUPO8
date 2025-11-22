using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class cambiosComentarioIncidencia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Incidencias_Incidenciaid",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_Incidenciaid",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "Incidenciaid",
                table: "Comentarios");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_idIncidencia",
                table: "Comentarios",
                column: "idIncidencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Incidencias_idIncidencia",
                table: "Comentarios",
                column: "idIncidencia",
                principalTable: "Incidencias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Incidencias_idIncidencia",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_idIncidencia",
                table: "Comentarios");

            migrationBuilder.AddColumn<int>(
                name: "Incidenciaid",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Incidenciaid",
                table: "Comentarios",
                column: "Incidenciaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Incidencias_Incidenciaid",
                table: "Comentarios",
                column: "Incidenciaid",
                principalTable: "Incidencias",
                principalColumn: "id");
        }
    }
}
