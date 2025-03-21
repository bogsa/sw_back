using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _051124001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CP",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Num_Ext",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Num_Int",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "Cli_Clientes");

            migrationBuilder.DropColumn(
                name: "TelFijo",
                table: "Cli_Clientes");

            migrationBuilder.RenameColumn(
                name: "TelMovil",
                table: "Cli_Clientes",
                newName: "Telefono");

            migrationBuilder.CreateTable(
                name: "Cli_ClienteDatosFiscales",
                columns: table => new
                {
                    IdClienteDatosFiscales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClientesIdCliente = table.Column<int>(type: "int", nullable: true),
                    E_RegimenFiscalId = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num_Ext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num_Int = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelMovil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cli_ClienteDatosFiscales", x => x.IdClienteDatosFiscales);
                    table.ForeignKey(
                        name: "FK_Cli_ClienteDatosFiscales_Cli_Clientes_ClientesIdCliente",
                        column: x => x.ClientesIdCliente,
                        principalTable: "Cli_Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Cli_ClienteDatosFiscales_Conf_RegimenFiscal_E_RegimenFiscalId",
                        column: x => x.E_RegimenFiscalId,
                        principalTable: "Conf_RegimenFiscal",
                        principalColumn: "IdRegimenFiscal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gas_Gasto",
                columns: table => new
                {
                    IdGastoreg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    E_CentroTrabajoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    E_GastoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas_Gasto", x => x.IdGastoreg);
                    table.ForeignKey(
                        name: "FK_Gas_Gasto_Admin_CentroTrabajo_E_CentroTrabajoId",
                        column: x => x.E_CentroTrabajoId,
                        principalTable: "Admin_CentroTrabajo",
                        principalColumn: "IdCentroTrabajo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Gas_Gasto_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        onDelete: ReferentialAction.NoAction,
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gas_Gasto_Conf_Gasto_E_GastoId",
                        column: x => x.E_GastoId,
                        principalTable: "Conf_Gasto",
                        principalColumn: "IdGasto",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cli_ClienteDatosFiscales_ClientesIdCliente",
                table: "Cli_ClienteDatosFiscales",
                column: "ClientesIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cli_ClienteDatosFiscales_E_RegimenFiscalId",
                table: "Cli_ClienteDatosFiscales",
                column: "E_RegimenFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Gas_Gasto_E_CentroTrabajoId",
                table: "Gas_Gasto",
                column: "E_CentroTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gas_Gasto_E_GastoId",
                table: "Gas_Gasto",
                column: "E_GastoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gas_Gasto_UserId",
                table: "Gas_Gasto",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cli_ClienteDatosFiscales");

            migrationBuilder.DropTable(
                name: "Gas_Gasto");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Cli_Clientes",
                newName: "TelMovil");

            migrationBuilder.AddColumn<string>(
                name: "CP",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Num_Ext",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Num_Int",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelFijo",
                table: "Cli_Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
