using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _310324001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AD_COORPORATIVO",
                columns: table => new
                {
                    IdCoorporativo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_COORPORATIVO", x => x.IdCoorporativo);
                });

            migrationBuilder.CreateTable(
                name: "AD_MENU",
                columns: table => new
                {
                    IdMenu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_MENU", x => x.IdMenu);
                });

            migrationBuilder.CreateTable(
                name: "AD_PERFIL",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePerfil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_PERFIL", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "AD_TFDsGLOBAL",
                columns: table => new
                {
                    IdTFDsGlobal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalTFD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_TFDsGLOBAL", x => x.IdTFDsGlobal);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tooltip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CO_FORMAPAGO",
                columns: table => new
                {
                    IdFormaPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "NvarChar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_FORMAPAGO", x => x.IdFormaPago);
                });

            migrationBuilder.CreateTable(
                name: "CO_IMPUESTO",
                columns: table => new
                {
                    IdImpuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "NvarChar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_IMPUESTO", x => x.IdImpuesto);
                });

            migrationBuilder.CreateTable(
                name: "CO_METODOPAGO",
                columns: table => new
                {
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "NvarChar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_METODOPAGO", x => x.IdMetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "CO_MONEDA",
                columns: table => new
                {
                    IdMoneda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "NvarChar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_MONEDA", x => x.IdMoneda);
                });

            migrationBuilder.CreateTable(
                name: "CO_OBJETOIMPUESTO",
                columns: table => new
                {
                    IdObjetoImpuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "NvarChar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_OBJETOIMPUESTO", x => x.IdObjetoImpuesto);
                });

            migrationBuilder.CreateTable(
                name: "CO_PRODUCTOSERVICIO",
                columns: table => new
                {
                    IdProductoServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_PRODUCTOSERVICIO", x => x.IdProductoServicio);
                });

            migrationBuilder.CreateTable(
                name: "CO_REGIMENFISCAL",
                columns: table => new
                {
                    IdRegimenFiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_REGIMENFISCAL", x => x.IdRegimenFiscal);
                });

            migrationBuilder.CreateTable(
                name: "CO_TIPOCOMPROBANTE",
                columns: table => new
                {
                    IdTipoComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_TIPOCOMPROBANTE", x => x.IdTipoComprobante);
                });

            migrationBuilder.CreateTable(
                name: "CO_TIPOFACTOR",
                columns: table => new
                {
                    IdTipoFactor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "NvarChar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_TIPOFACTOR", x => x.IdTipoFactor);
                });

            migrationBuilder.CreateTable(
                name: "CO_TIPORELACION",
                columns: table => new
                {
                    IdTipoRelacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_TIPORELACION", x => x.IdTipoRelacion);
                });

            migrationBuilder.CreateTable(
                name: "CO_UNIDADMEDIDA",
                columns: table => new
                {
                    IdUnidadMedida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_UNIDADMEDIDA", x => x.IdUnidadMedida);
                });

            migrationBuilder.CreateTable(
                name: "CO_USOCFDI",
                columns: table => new
                {
                    IdUsoCFDI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_USOCFDI", x => x.IdUsoCFDI);
                });

            migrationBuilder.CreateTable(
                name: "AL_DEPARTAMENTO",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_DEPARTAMENTO", x => x.IdDepartamento);
                    table.ForeignKey(
                        name: "FK_AL_DEPARTAMENTO_AD_COORPORATIVO_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "AD_COORPORATIVO",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_MARCA",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_MARCA", x => x.IdMarca);
                    table.ForeignKey(
                        name: "FK_AL_MARCA_AD_COORPORATIVO_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "AD_COORPORATIVO",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_PROVEEDOR",
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
                    table.PrimaryKey("PK_AL_PROVEEDOR", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_AL_PROVEEDOR_AD_COORPORATIVO_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "AD_COORPORATIVO",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CL_CLIENTES",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CoorporativoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    TelFijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelMovil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CL_CLIENTES", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_CL_CLIENTES_AD_COORPORATIVO_E_CoorporativoId",
                        column: x => x.E_CoorporativoId,
                        principalTable: "AD_COORPORATIVO",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_SUBMENU",
                columns: table => new
                {
                    IdSubMenu = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_SUBMENU", x => x.IdSubMenu);
                    table.ForeignKey(
                        name: "FK_AD_SUBMENU_AD_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "AD_MENU",
                        principalColumn: "IdMenu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_TFDsDETALLE",
                columns: table => new
                {
                    IdDetalleTFD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadTFD = table.Column<int>(type: "int", nullable: false),
                    E_TFDsGlobalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_TFDsDETALLE", x => x.IdDetalleTFD);
                    table.ForeignKey(
                        name: "FK_AD_TFDsDETALLE_AD_TFDsGLOBAL_E_TFDsGlobalId",
                        column: x => x.E_TFDsGlobalId,
                        principalTable: "AD_TFDsGLOBAL",
                        principalColumn: "IdTFDsGlobal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_MODULO",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    E_PerfilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_MODULO", x => x.IdModulo);
                    table.ForeignKey(
                        name: "FK_AD_MODULO_AD_PERFIL_E_PerfilId",
                        column: x => x.E_PerfilId,
                        principalTable: "AD_PERFIL",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AD_MODULO_AspNetRoles_RolId",
                        column: x => x.RolId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_EMPRESA",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CoorporativoId = table.Column<int>(type: "int", nullable: false),
                    E_RegimenFiscalId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoExterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoInterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaDirectorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaDirectorioVirtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaArchivoCER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaArchivoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CveKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContadorTimbre = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_EMPRESA", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_AD_EMPRESA_AD_COORPORATIVO_E_CoorporativoId",
                        column: x => x.E_CoorporativoId,
                        principalTable: "AD_COORPORATIVO",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AD_EMPRESA_CO_REGIMENFISCAL_E_RegimenFiscalId",
                        column: x => x.E_RegimenFiscalId,
                        principalTable: "CO_REGIMENFISCAL",
                        principalColumn: "IdRegimenFiscal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_CATEGORIA",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_CATEGORIA", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_AL_CATEGORIA_AL_DEPARTAMENTO_E_DepartamentoId",
                        column: x => x.E_DepartamentoId,
                        principalTable: "AL_DEPARTAMENTO",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_PERMISO",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ModuloId = table.Column<int>(type: "int", nullable: false),
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_PERMISO", x => x.IdPermiso);
                    table.ForeignKey(
                        name: "FK_AD_PERMISO_AD_MODULO_E_ModuloId",
                        column: x => x.E_ModuloId,
                        principalTable: "AD_MODULO",
                        principalColumn: "IdModulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AD_PERMISO_AspNetRoleClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "AspNetRoleClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_ASIGNACIONTFD",
                columns: table => new
                {
                    IdAsignacionTFDs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadTFD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_ASIGNACIONTFD", x => x.IdAsignacionTFDs);
                    table.ForeignKey(
                        name: "FK_AD_ASIGNACIONTFD_AD_EMPRESA_E_EmpresaId",
                        column: x => x.E_EmpresaId,
                        principalTable: "AD_EMPRESA",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_CENTROTRABAJO",
                columns: table => new
                {
                    IdCentroTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cve_Gerente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FolioInicial = table.Column<int>(type: "int", nullable: false),
                    LugarExpedicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensajePersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCentroTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_CENTROTRABAJO", x => x.IdCentroTrabajo);
                    table.ForeignKey(
                        name: "FK_AD_CENTROTRABAJO_AD_EMPRESA_E_EmpresaId",
                        column: x => x.E_EmpresaId,
                        principalTable: "AD_EMPRESA",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_ARTICULO",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificadorUnico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoBarras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_ProductoServicioId = table.Column<int>(type: "int", nullable: false),
                    E_CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Localizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CuentaPredial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusServicio = table.Column<bool>(type: "bit", nullable: false),
                    ControlaExistencias = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StatusProduccion = table.Column<bool>(type: "bit", nullable: false),
                    LotesCaducidades = table.Column<bool>(type: "bit", nullable: false),
                    Receta = table.Column<bool>(type: "bit", nullable: false),
                    NumerosSerie = table.Column<bool>(type: "bit", nullable: false),
                    Corrida = table.Column<bool>(type: "bit", nullable: false),
                    Paquete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_ARTICULO", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_AL_ARTICULO_AL_CATEGORIA_E_CategoriaId",
                        column: x => x.E_CategoriaId,
                        principalTable: "AL_CATEGORIA",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AL_ARTICULO_CO_PRODUCTOSERVICIO_E_ProductoServicioId",
                        column: x => x.E_ProductoServicioId,
                        principalTable: "CO_PRODUCTOSERVICIO",
                        principalColumn: "IdProductoServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_INVENTARIO",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CentroTrabajoId = table.Column<int>(type: "int", nullable: false),
                    E_ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Existencias = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_INVENTARIO", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_AL_INVENTARIO_AD_CENTROTRABAJO_E_CentroTrabajoId",
                        column: x => x.E_CentroTrabajoId,
                        principalTable: "AD_CENTROTRABAJO",
                        principalColumn: "IdCentroTrabajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_CentroTrabajoId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AD_CENTROTRABAJO_E_CentroTrabajoId",
                        column: x => x.E_CentroTrabajoId,
                        principalTable: "AD_CENTROTRABAJO",
                        principalColumn: "IdCentroTrabajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_ARTICULO_DETALLE_IMPUESTOS",
                columns: table => new
                {
                    IdArticuloDetalleImpuestos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ArticuloId = table.Column<int>(type: "int", nullable: false),
                    TipoImpuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_ARTICULO_DETALLE_IMPUESTOS", x => x.IdArticuloDetalleImpuestos);
                    table.ForeignKey(
                        name: "FK_AL_ARTICULO_DETALLE_IMPUESTOS_AL_ARTICULO_E_ArticuloId",
                        column: x => x.E_ArticuloId,
                        principalTable: "AL_ARTICULO",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AL_INVENTARIO_DETALLE_PRECIOS",
                columns: table => new
                {
                    IdInventarioDetallePrecios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_InventarioId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MargenUtilidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_INVENTARIO_DETALLE_PRECIOS", x => x.IdInventarioDetallePrecios);
                    table.ForeignKey(
                        name: "FK_AL_INVENTARIO_DETALLE_PRECIOS_AL_INVENTARIO_E_InventarioId",
                        column: x => x.E_InventarioId,
                        principalTable: "AL_INVENTARIO",
                        principalColumn: "IdInventario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AD_USUARIOCENTROTRABAJO",
                columns: table => new
                {
                    IdUsuarioCentroTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    E_CentroTrabajoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_USUARIOCENTROTRABAJO", x => x.IdUsuarioCentroTrabajo);
                    table.ForeignKey(
                        name: "FK_AD_USUARIOCENTROTRABAJO_AD_CENTROTRABAJO_E_CentroTrabajoId",
                        column: x => x.E_CentroTrabajoId,
                        principalTable: "AD_CENTROTRABAJO",
                        principalColumn: "IdCentroTrabajo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AD_USUARIOCENTROTRABAJO_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AD_USUARIOEMPRESAS",
                columns: table => new
                {
                    IdUsuarioEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    E_EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_USUARIOEMPRESAS", x => x.IdUsuarioEmpresa);
                    table.ForeignKey(
                        name: "FK_AD_USUARIOEMPRESAS_AD_EMPRESA_E_EmpresaId",
                        column: x => x.E_EmpresaId,
                        principalTable: "AD_EMPRESA",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AD_USUARIOEMPRESAS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AD_ASIGNACIONTFD_E_EmpresaId",
                table: "AD_ASIGNACIONTFD",
                column: "E_EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_CENTROTRABAJO_E_EmpresaId",
                table: "AD_CENTROTRABAJO",
                column: "E_EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_EMPRESA_E_CoorporativoId",
                table: "AD_EMPRESA",
                column: "E_CoorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_EMPRESA_E_RegimenFiscalId",
                table: "AD_EMPRESA",
                column: "E_RegimenFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_MODULO_E_PerfilId",
                table: "AD_MODULO",
                column: "E_PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_MODULO_RolId",
                table: "AD_MODULO",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_PERMISO_ClaimId",
                table: "AD_PERMISO",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_PERMISO_E_ModuloId",
                table: "AD_PERMISO",
                column: "E_ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_SUBMENU_MenuId",
                table: "AD_SUBMENU",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_TFDsDETALLE_E_TFDsGlobalId",
                table: "AD_TFDsDETALLE",
                column: "E_TFDsGlobalId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_USUARIOCENTROTRABAJO_E_CentroTrabajoId",
                table: "AD_USUARIOCENTROTRABAJO",
                column: "E_CentroTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_USUARIOCENTROTRABAJO_UserId",
                table: "AD_USUARIOCENTROTRABAJO",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_USUARIOEMPRESAS_E_EmpresaId",
                table: "AD_USUARIOEMPRESAS",
                column: "E_EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_AD_USUARIOEMPRESAS_UserId",
                table: "AD_USUARIOEMPRESAS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_ARTICULO_E_CategoriaId",
                table: "AL_ARTICULO",
                column: "E_CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_ARTICULO_E_ProductoServicioId",
                table: "AL_ARTICULO",
                column: "E_ProductoServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_ARTICULO_DETALLE_IMPUESTOS_E_ArticuloId",
                table: "AL_ARTICULO_DETALLE_IMPUESTOS",
                column: "E_ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_CATEGORIA_E_DepartamentoId",
                table: "AL_CATEGORIA",
                column: "E_DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DEPARTAMENTO_E_CorporativoId",
                table: "AL_DEPARTAMENTO",
                column: "E_CorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INVENTARIO_E_CentroTrabajoId",
                table: "AL_INVENTARIO",
                column: "E_CentroTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INVENTARIO_DETALLE_PRECIOS_E_InventarioId",
                table: "AL_INVENTARIO_DETALLE_PRECIOS",
                column: "E_InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_MARCA_E_CorporativoId",
                table: "AL_MARCA",
                column: "E_CorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_AL_PROVEEDOR_E_CorporativoId",
                table: "AL_PROVEEDOR",
                column: "E_CorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_E_CentroTrabajoId",
                table: "AspNetUsers",
                column: "E_CentroTrabajoId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CL_CLIENTES_E_CoorporativoId",
                table: "CL_CLIENTES",
                column: "E_CoorporativoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AD_ASIGNACIONTFD");

            migrationBuilder.DropTable(
                name: "AD_PERMISO");

            migrationBuilder.DropTable(
                name: "AD_SUBMENU");

            migrationBuilder.DropTable(
                name: "AD_TFDsDETALLE");

            migrationBuilder.DropTable(
                name: "AD_USUARIOCENTROTRABAJO");

            migrationBuilder.DropTable(
                name: "AD_USUARIOEMPRESAS");

            migrationBuilder.DropTable(
                name: "AL_ARTICULO_DETALLE_IMPUESTOS");

            migrationBuilder.DropTable(
                name: "AL_INVENTARIO_DETALLE_PRECIOS");

            migrationBuilder.DropTable(
                name: "AL_MARCA");

            migrationBuilder.DropTable(
                name: "AL_PROVEEDOR");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CL_CLIENTES");

            migrationBuilder.DropTable(
                name: "CO_FORMAPAGO");

            migrationBuilder.DropTable(
                name: "CO_IMPUESTO");

            migrationBuilder.DropTable(
                name: "CO_METODOPAGO");

            migrationBuilder.DropTable(
                name: "CO_MONEDA");

            migrationBuilder.DropTable(
                name: "CO_OBJETOIMPUESTO");

            migrationBuilder.DropTable(
                name: "CO_TIPOCOMPROBANTE");

            migrationBuilder.DropTable(
                name: "CO_TIPOFACTOR");

            migrationBuilder.DropTable(
                name: "CO_TIPORELACION");

            migrationBuilder.DropTable(
                name: "CO_UNIDADMEDIDA");

            migrationBuilder.DropTable(
                name: "CO_USOCFDI");

            migrationBuilder.DropTable(
                name: "AD_MODULO");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AD_MENU");

            migrationBuilder.DropTable(
                name: "AD_TFDsGLOBAL");

            migrationBuilder.DropTable(
                name: "AL_ARTICULO");

            migrationBuilder.DropTable(
                name: "AL_INVENTARIO");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AD_PERFIL");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AL_CATEGORIA");

            migrationBuilder.DropTable(
                name: "CO_PRODUCTOSERVICIO");

            migrationBuilder.DropTable(
                name: "AD_CENTROTRABAJO");

            migrationBuilder.DropTable(
                name: "AL_DEPARTAMENTO");

            migrationBuilder.DropTable(
                name: "AD_EMPRESA");

            migrationBuilder.DropTable(
                name: "AD_COORPORATIVO");

            migrationBuilder.DropTable(
                name: "CO_REGIMENFISCAL");
        }
    }
}
