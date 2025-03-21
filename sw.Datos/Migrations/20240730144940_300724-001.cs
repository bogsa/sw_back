using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _300724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conf_Prueba");

            migrationBuilder.DropColumn(
                name: "Localizacion",
                table: "Pro_Producto");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Pro_ProductoDetallePrecios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localizacion",
                table: "Alm_Inventario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioBase",
                table: "Alm_Inventario",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Pro_ProductoDetallePrecios");

            migrationBuilder.DropColumn(
                name: "Localizacion",
                table: "Alm_Inventario");

            migrationBuilder.DropColumn(
                name: "PrecioBase",
                table: "Alm_Inventario");

            migrationBuilder.AddColumn<string>(
                name: "Localizacion",
                table: "Pro_Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conf_Prueba",
                columns: table => new
                {
                    IdPrueba = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_Prueba", x => x.IdPrueba);
                });
        }
    }
}
