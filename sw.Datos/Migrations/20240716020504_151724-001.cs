using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _151724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conf_Gasto",
                columns: table => new
                {
                    IdGasto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_Gasto", x => x.IdGasto);
                    table.ForeignKey(
                        name: "FK_Conf_Gasto_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conf_Gasto_E_CorporativoId",
                table: "Conf_Gasto",
                column: "E_CorporativoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conf_Gasto");
        }
    }
}
