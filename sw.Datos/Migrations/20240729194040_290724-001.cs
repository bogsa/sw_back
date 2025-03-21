using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _290724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pro_Producto_Cli_Proveedor_E_ProveedorId",
                table: "Pro_Producto");

            migrationBuilder.DropTable(
                name: "Cli_Marca");

            migrationBuilder.DropTable(
                name: "Cli_Proveedor");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Pro_Departamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pro_Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Marca", x => x.IdMarca);
                    table.ForeignKey(
                        name: "FK_Pro_Marca_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pro_Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Proveedor", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_Pro_Proveedor_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Marca_E_CorporativoId",
                table: "Pro_Marca",
                column: "E_CorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Proveedor_E_CorporativoId",
                table: "Pro_Proveedor",
                column: "E_CorporativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_Producto_Pro_Proveedor_E_ProveedorId",
                table: "Pro_Producto",
                column: "E_ProveedorId",
                principalTable: "Pro_Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pro_Producto_Pro_Proveedor_E_ProveedorId",
                table: "Pro_Producto");

            migrationBuilder.DropTable(
                name: "Pro_Marca");

            migrationBuilder.DropTable(
                name: "Pro_Proveedor");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Pro_Departamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Cli_Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cli_Marca", x => x.IdMarca);
                    table.ForeignKey(
                        name: "FK_Cli_Marca_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cli_Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cli_Proveedor", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_Cli_Proveedor_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cli_Marca_E_CorporativoId",
                table: "Cli_Marca",
                column: "E_CorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cli_Proveedor_E_CorporativoId",
                table: "Cli_Proveedor",
                column: "E_CorporativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pro_Producto_Cli_Proveedor_E_ProveedorId",
                table: "Pro_Producto",
                column: "E_ProveedorId",
                principalTable: "Cli_Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
