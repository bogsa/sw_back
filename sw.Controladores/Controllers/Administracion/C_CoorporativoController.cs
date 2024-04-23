using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using sw.Datos;
using sw.Controladores.Model.Administracion.Coorporativo;
using sw.Entidades.Administracion.Coorporativo;
using sw.Entidades.Clientes;
using sw.Entidades.Administracion.Empresa;
using sw.Entidades.Administracion.CentroTrabajo;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class C_CoorporativoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_CoorporativoController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
        }
        // GET: api/C_Coorporativo/ListarCoorporativos

        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Coorporativo>> ListarCoorporativos()
        {
            var corp = await _context.E_Coorporativos.ToListAsync();



            return corp.Select(a => new GET_Coorporativo
            {

                IdCoorporativo = a.IdCoorporativo,
                Nombre = a.Nombre,
                Status = a.Status, 
                Guid = a.Guid,

            });

        }


        // PUT: api/C_Coorporativo/ActualizarCoorporativo
        //[Authorize(Roles = " Administrador")]

        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarCoorporativo([FromBody] PUT_Coorporativo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var coorporativo = await _context.E_Coorporativos.FirstOrDefaultAsync(a => a.IdCoorporativo == model.IdCoorporativo);

            if (coorporativo == null)
            {
                return NotFound();
            }


            coorporativo.Nombre = model.Nombre;
            coorporativo.Status = model.Status; 

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El coorporativo se actualizo correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar actualizarl el coorporativo"
                });
            }


        }


        // POST: api/C_Coorporativo/CrearCoorporativo
        //[Authorize(Roles = " Administrador")] 
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearCorporativo([FromBody] POST_Coorporativo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid g = Guid.NewGuid();

                    E_Coorporativo Corporativo = new E_Coorporativo
                    {

                        Nombre = model.Nombre,
                        Status = model.Status, 
                        Guid = g.ToString()


                    };

                    _context.E_Coorporativos.Add(Corporativo);
                    await _context.SaveChangesAsync();

                    E_Clientes Cliente = new E_Clientes
                    {

                        E_CoorporativoId = Corporativo.IdCoorporativo,
                        Nombre = "Publico en general",
                        RazonSocial = "",
                        RFC = "XAXX010101000",
                        Calle = "",
                        Num_Ext = "",
                        Num_Int = "",
                        Colonia = "",
                        CP = "",
                        Municipio = "",
                        Estado = "",
                        Pais = "",
                        TelFijo = "",
                        TelMovil = "",
                        Email = "",
                        Default = true,

                    };

                    _context.E_Clientes.Add(Cliente);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                }
                catch (Exception)
                {

                    transaction.Rollback();
                }
                return Ok(new
                {
                    result = "El coorporativo se creo correctamente"
                });
            }
        }
        // GET: api/C_Coorporativo/ListarCoorporativo 
        [HttpGet("[action]/{idCorp}")]
        public async Task<IActionResult> ListarCorporativo([FromRoute] int idCorp) 
        {        
            var corporativo = await _context.E_Coorporativos.FirstOrDefaultAsync(a => a.IdCoorporativo == idCorp);

            if (corporativo == null)
            {
                return NotFound();
            }

            return Ok(new GET_Coorporativo
            {
                IdCoorporativo = corporativo.IdCoorporativo,
                Nombre = corporativo.Nombre,
                Status = corporativo.Status, 
                Guid = corporativo.Guid,

            });
        }
        // POST: api/C_Coorporativo/CrearCorEmprSuc
        //[Authorize(Roles = " Administrador")] 
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearCorEmprSuc([FromBody] POST_AllinOne model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    E_Coorporativo corporativo = new E_Coorporativo
                    {

                        Nombre = model.CrearCorporativo ? model.NombreCor : model.CrearEmpresa ? model.NombreEmp : model.NombreSuc,
                        Status = true, 
                        Guid = model.GuidCorporativo

                    };

                    _context.E_Coorporativos.Add(corporativo);
                    await _context.SaveChangesAsync();


                    var regimen = await _context.E_RegimenFiscals
                        .FirstOrDefaultAsync();


                    E_Empresa empresa = new E_Empresa
                    {
                        E_CoorporativoId = corporativo.IdCoorporativo,
                        E_RegimenFiscalId = model.CrearEmpresa ? model.E_RegimenFiscalId : regimen.IdRegimenFiscal,
                        Nombre = model.CrearEmpresa ? model.NombreEmp : model.NombreSuc,
                        RFC = model.RFC,
                        RazonSocial = model.RazonSocial,
                        Calle = model.Calle,
                        NoExterior = model.NoExterior,
                        NoInterior = model.NoInterior,
                        Colonia = model.Colonia,
                        CP = model.CP,
                        Municipio = model.Municipio,
                        Estado = model.Estado,
                        Pais = model.Pais,
                        //RutaDirectorio = model.RutaDirectorio,
                        //RutaDirectorioVirtual = model.RutaDirectorioVirtual,
                        RutaArchivoCER = model.RutaArchivoCER,
                        RutaArchivoKey = model.RutaArchivoKey,
                        CveKey = model.CveKey,
                        RutaLogo = model.RutaLogo,
                        ContadorTimbre = model.ContadorTimbre,
                        Guid = model.GuidEmpresa

                    };


                    _context.E_Empresas.Add(empresa);
                    await _context.SaveChangesAsync();

                    E_CentroTrabajo CentroTrabajo = new E_CentroTrabajo
                    {

                        E_EmpresaId = empresa.IdEmpresa,
                        Nombre = model.NombreSuc,
                        Responsable = model.ResponsableSuc,
                        Direccion = model.DireccionSuc,
                        Telefono = model.TelefonoSuc,
                        Email = model.Email,
                        Cve_Gerente = model.Cve_Gerente,
                        Serie = model.Serie,
                        Activo = true,
                        FolioInicial = model.FolioInicial,
                        LugarExpedicion = model.LugarExpedicion,
                        MensajePersonal = model.MensajePersonal,
                        TipoCentroTrabajo = model.TipoCentroTrabajo,
                    };

                    _context.E_CentroTrabajos.Add(CentroTrabajo);
                    await _context.SaveChangesAsync();

                    E_Clientes Cliente = new E_Clientes
                    {

                        E_CoorporativoId = corporativo.IdCoorporativo,
                        Nombre = "Publico en general",
                        RazonSocial = "Publico en general",
                        RFC = "XAXX010101000",
                        Calle = "",
                        Num_Ext = "",
                        Num_Int = "",
                        Colonia = "",
                        CP = "",
                        Municipio = "",
                        Estado = "",
                        Pais = "",
                        TelFijo = "",
                        TelMovil = "",
                        Email = "",
                        Default = true,

                    };

                    _context.E_Clientes.Add(Cliente);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return Ok(new { idCorp = corporativo.IdCoorporativo });

                }
                catch (Exception)
                {
                    transaction.Rollback();

                }

                return Ok(new { result = "El registro se completo exitosamente" });
            }


        }
        // GET: api/C_Coorporativo/Guidcorporativo 
        [HttpGet("[action]/{IdCoorporativo}")]
        public async Task<IActionResult> Guidcorporativo([FromRoute] int IdCorporativo)
        {
            var guid = await _context.E_Coorporativos
                .Where(a => a.IdCoorporativo == IdCorporativo)
                .FirstOrDefaultAsync();


            return Ok(new { Guidcorporativo = guid != null ? guid.Guid : "0" });

        }

        [HttpGet("[action]/{idCorp}")]
        public async Task<IActionResult> ListarCorpEmpSuc([FromRoute] int idCorp)
        {
            List<GET_CorpEmpSuc> list = new List<GET_CorpEmpSuc>();

            var tabla = await _context.E_Coorporativos.FirstOrDefaultAsync(a => a.IdCoorporativo == idCorp);

            if (tabla == null)
            {
                return NotFound();
            }

            return Ok(new GET_CorpEmpSuc
            {
                id = tabla.IdCoorporativo,
                name = "Corporativo", 
                children = BuscarEmpresas(tabla.IdCoorporativo).ToList()
            });
        }

        private IEnumerable<GET_Emp> BuscarEmpresas(int idCorp)
        {
            var data = _context.E_Empresas.Where(a => a.E_CoorporativoId == idCorp).ToList();

            return data.Select(a => new GET_Emp
            {
                id = a.IdEmpresa,
                name = "Empresa",
                title = a.Nombre,
                children = BuscarCentroTrabajo(a.IdEmpresa).ToList()
            });
        }
        private IEnumerable<GET_Suc> BuscarCentroTrabajo(int idEmp)
        {
            var data = _context.E_CentroTrabajos.Where(a => a.E_EmpresaId == idEmp).ToList();

            return data.Select(a => new GET_Suc
            {
                id = a.IdCentroTrabajo,
                name = "Centro de trabajo",
                title = a.Nombre,
            });
        }

    }
}
