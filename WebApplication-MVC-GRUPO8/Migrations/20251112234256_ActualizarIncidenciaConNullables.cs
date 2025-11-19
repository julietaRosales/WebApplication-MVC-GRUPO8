using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_MVC_GRUPO8.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarIncidenciaConNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "sla",
                table: "Incidencias",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "prioridad",
                table: "Incidencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "idTecnico",
                table: "Incidencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "idEncargado",
                table: "Incidencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaInicioReparacion",
                table: "Incidencias",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaFinReparacion",
                table: "Incidencias",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaAsignacion",
                table: "Incidencias",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "costoTotal",
                table: "Incidencias",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "complejidad",
                table: "Incidencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Incidenciaid",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idEncargado",
                table: "Incidencias",
                column: "idEncargado");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idTecnico",
                table: "Incidencias",
                column: "idTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_idUsuario",
                table: "Incidencias",
                column: "idUsuario");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_idEncargado",
                table: "Incidencias",
                column: "idEncargado",
                principalTable: "Usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_idTecnico",
                table: "Incidencias",
                column: "idTecnico",
                principalTable: "Usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Usuarios_idUsuario",
                table: "Incidencias",
                column: "idUsuario",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Incidencias_Incidenciaid",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_idEncargado",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_idTecnico",
                table: "Incidencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Usuarios_idUsuario",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_idEncargado",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_idTecnico",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Incidencias_idUsuario",
                table: "Incidencias");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_Incidenciaid",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "Incidenciaid",
                table: "Comentarios");

            migrationBuilder.AlterColumn<decimal>(
                name: "sla",
                table: "Incidencias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "prioridad",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idTecnico",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idEncargado",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaInicioReparacion",
                table: "Incidencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaFinReparacion",
                table: "Incidencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaAsignacion",
                table: "Incidencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "costoTotal",
                table: "Incidencias",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "complejidad",
                table: "Incidencias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
