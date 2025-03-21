using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _200325001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Pro_ProductoDetallePrecios");

            migrationBuilder.AddColumn<int>(
                name: "E_ProductoDetalleImpuestosId",
                table: "Pro_Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "E_ProductoDetallePreciosId",
                table: "Pro_Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Localizacion",
                table: "Pro_Producto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "E_ProductoDetalleImpuestosId",
                table: "Pro_Producto");

            migrationBuilder.DropColumn(
                name: "E_ProductoDetallePreciosId",
                table: "Pro_Producto");

            migrationBuilder.DropColumn(
                name: "Localizacion",
                table: "Pro_Producto");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Pro_ProductoDetallePrecios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
