using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _140524001G : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dcto_Individual",
                table: "Cli_Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dcto_Individual",
                table: "Cli_Clientes");
        }
    }
}
