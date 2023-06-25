using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroEF.Migrations
{
    /// <inheritdoc />
    public partial class pruebaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pruebaMigration",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pruebaMigration",
                table: "Tarea");
        }
    }
}
