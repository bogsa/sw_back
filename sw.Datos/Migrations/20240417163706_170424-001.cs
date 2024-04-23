using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _170424001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo",
                column: "E_CategoriaId",
                principalTable: "Alm_Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo");

            migrationBuilder.DropTable(
                name: "Conf_Prueba");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo",
                column: "E_CategoriaId",
                principalTable: "Alm_Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
