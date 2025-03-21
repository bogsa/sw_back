using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class R220724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Precio_Asignado",
                table: "Cli_Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Precio_Individual",
                table: "Cli_Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio_Asignado",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Precio_Individual",
                table: "Cli_Clientes");
        }
    }
}
