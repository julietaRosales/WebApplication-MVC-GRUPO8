using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class seAgregaIdUserDescarte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idUserDescar",
                table: "Incidencias",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idUserDescar",
                table: "Incidencias");
        }
    }
}
