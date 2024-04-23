using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _010424001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Alm_Inventario_E_ArticuloId",
                table: "Alm_Inventario",
                column: "E_ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Inventario_Alm_Articulo_E_ArticuloId",
                table: "Alm_Inventario",
                column: "E_ArticuloId",
                principalTable: "Alm_Articulo",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Inventario_Alm_Articulo_E_ArticuloId",
                table: "Alm_Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Alm_Inventario_E_ArticuloId",
                table: "Alm_Inventario");
        }
    }
}
