using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroEF.Migrations
{
    /// <inheritdoc />
    public partial class datosDeInicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "pruebaMigration",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("0ca6d57a-9817-4a6c-a80f-af672816a57f"), null, "Actividades Pendientes", 20 },
                    { new Guid("5b080b9d-e620-4e11-9b9f-5ca932ff5fe3"), null, "Actividades Pendientes", 30 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "pruebaMigration" },
                values: new object[,]
                {
                    { new Guid("402606b1-801e-4e3c-bc74-257f6fb73009"), new Guid("0ca6d57a-9817-4a6c-a80f-af672816a57f"), null, new DateTime(2023, 6, 24, 22, 24, 31, 970, DateTimeKind.Local).AddTicks(5142), 1, "Pago de Servicios Publicos", null },
                    { new Guid("c2aeeb3d-8037-4cda-9e46-8edbd10196cc"), new Guid("5b080b9d-e620-4e11-9b9f-5ca932ff5fe3"), null, new DateTime(2023, 6, 24, 22, 24, 31, 970, DateTimeKind.Local).AddTicks(5159), 0, "Termina Cursos Platzi", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("402606b1-801e-4e3c-bc74-257f6fb73009"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c2aeeb3d-8037-4cda-9e46-8edbd10196cc"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("0ca6d57a-9817-4a6c-a80f-af672816a57f"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("5b080b9d-e620-4e11-9b9f-5ca932ff5fe3"));

            migrationBuilder.AlterColumn<string>(
                name: "pruebaMigration",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
