using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Configuracion.CentroTrabajo;
using sw.Datos;
using sw.Entidades.Administracion.CentroTrabajo;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_CentroTrabajoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_CentroTrabajoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/CentroTrabajo/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_CentroTrabajo>> Listar()
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
            .OrderBy(a => a.Nombre)
            .Include(a => a.E_Empresa.E_Coorporativo)
            .ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return CentroTrabajo.Select(a => new GET_CentroTrabajo
            {
                IdCentroTrabajo = a.IdCentroTrabajo,
                E_EmpresaId = a.E_EmpresaId,
                Nombre = a.Nombre,
                Responsable = a.Responsable,
                Direccion = a.Direccion,
                Telefono = a.Telefono,
                Email = a.Email,
                Cve_Gerente = a.Cve_Gerente,
                Serie = a.Serie,
                Activo = a.Activo,
                FolioInicial = a.FolioInicial,
                LugarExpedicion = a.LugarExpedicion,
                Numeracion = conteo(),
                IdCoorporativo = a.E_Empresa.E_CoorporativoId,
                MensajePersonal = a.MensajePersonal,
                TipoCentroTrabajo = a.TipoCentroTrabajo,

            });

        }


        // PUT: api/CentroTrabajo/Actualizar
        //[Authorize(Roles = " Administrador")]
        //[HttpPut("[action]")]
        //public async Task<IActionResult> Actualizar([FromBody] PUT_CentroTrabajo model)
        //{
        //    if (model.idrangoerror == 0)
        //    {
        //        E_CorteCajaDetalles Corte = new E_CorteCajaDetalles
        //        {

        //            E_CentroTrabajoId = model.IdCentroTrabajo,
        //            RangoError = model.RangoError,

        //        };

        //        _context.E_CorteCajaDetalles.Add(Corte);

        //    }
        //    else
        //    {
        //        var x = await _context.E_CorteCajaDetalles
        //            .Where(a => a.IdCorteCajaDetalles == model.idrangoerror)
        //            .FirstOrDefaultAsync();

        //        x.RangoError = model.RangoError;
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }


        //    var CentroTrabajo = await _context.E_CentroTrabajos.FirstOrDefaultAsync(a => a.IdCentroTrabajo == model.IdCentroTrabajo);

        //    if (CentroTrabajo == null)
        //    {
        //        return NotFound();
        //    }
        //    CentroTrabajo.IdCentroTrabajo = model.IdCentroTrabajo;
        //    CentroTrabajo.E_EmpresaId = model.E_EmpresaId;
        //    CentroTrabajo.Nombre = model.Nombre;
        //    CentroTrabajo.Responsable = model.Responsable;
        //    CentroTrabajo.Direccion = model.Direccion;
        //    CentroTrabajo.Telefono = model.Telefono;
        //    CentroTrabajo.Email = model.Email;
        //    CentroTrabajo.Cve_Gerente = model.Cve_Gerente;
        //    CentroTrabajo.Serie = model.Serie;
        //    CentroTrabajo.Activo = model.Activo;
        //    CentroTrabajo.FolioInicial = model.FolioInicial;
        //    CentroTrabajo.LugarExpedicion = model.LugarExpedicion;
        //    CentroTrabajo.MensajePersonal = model.MensajePersonal;
        //    CentroTrabajo.AlmacenGeneralE = model.AlmacenGeneralE;
        //    CentroTrabajo.AlmacenGeneralC = model.AlmacenGeneralC;
            

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        // Guardar Excepción
        //        return BadRequest();
        //    }

        //    return Ok();
        //}




        // POST: api/CentroTrabajo/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_CentroTrabajo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            E_CentroTrabajo CentroTrabajo = new E_CentroTrabajo
            {


                E_EmpresaId = model.E_EmpresaId,
                Nombre = model.Nombre,
                Responsable = model.Responsable,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                Email = model.Email,
                Cve_Gerente = model.Cve_Gerente,
                Serie = model.Serie,
                Activo = model.Activo,
                FolioInicial = model.FolioInicial,
                LugarExpedicion = model.LugarExpedicion,
                MensajePersonal = model.MensajePersonal,
                TipoCentroTrabajo  = model.TipoCentroTrabajo,

            };

            _context.E_CentroTrabajos.Add(CentroTrabajo);

            /*como añadir un rango error desde el back
            if(model.RangoError != 0)
            {

                E_CorteCajaDetalles Detalle = new E_CorteCajaDetalles
                {
                    E_CentroTrabajoId = CentroTrabajo.IdCentroTrabajo,
                    RangoError = model.RangoError,

                };

                _context.E_CorteCajaDetalles.Add(Detalle);

            }
            */

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(new {idCentroTrabajo = CentroTrabajo.IdCentroTrabajo});
        }



        // GET: api/C_CentroTrabajo/ListarporEmpresa
        [HttpGet("[action]/{IdEmpresa}")]
        public async Task<IEnumerable<GET_CentroTrabajo>> ListarporEmpresa([FromRoute] int IdEmpresa)
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
            .OrderBy(a => a.Nombre)
            .Where(a => a.E_EmpresaId == IdEmpresa)
            .Include(a => a.E_Empresa.E_Coorporativo)
            .ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return CentroTrabajo.Select(a => new GET_CentroTrabajo
            {
                IdCentroTrabajo = a.IdCentroTrabajo,
                E_EmpresaId = a.E_EmpresaId,
                Nombre = a.Nombre,
                Responsable = a.Responsable,
                Direccion = a.Direccion,
                Telefono = a.Telefono,
                Email = a.Email,
                Cve_Gerente = a.Cve_Gerente,
                Serie = a.Serie,
                Activo = a.Activo,
                FolioInicial = a.FolioInicial,
                LugarExpedicion = a.LugarExpedicion,
                Numeracion = conteo(),
                IdCoorporativo = a.E_Empresa.E_CoorporativoId,
                MensajePersonal = a.MensajePersonal,
                TipoCentroTrabajo = a.TipoCentroTrabajo,

            });

        }


        // GET: api/C_CentroTrabajo/ListarporIdEmpresa
        [HttpGet("[action]/{IdEmpresa}")]
        public async Task<IEnumerable<GET_CentroTrabajo>> ListarporIdEmpresa([FromRoute]int IdEmpresa)
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
                .Where(a=> a.E_EmpresaId == IdEmpresa)
                .OrderBy(a => a.Nombre)
                .Include(a => a.E_Empresa.E_Coorporativo)
                .ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return CentroTrabajo.Select(a => new GET_CentroTrabajo
            {
                IdCentroTrabajo = a.IdCentroTrabajo,
                E_EmpresaId = a.E_EmpresaId,
                Nombre = a.Nombre,
                Responsable = a.Responsable,
                Direccion = a.Direccion,
                Telefono = a.Telefono,
                Email = a.Email,
                Cve_Gerente = a.Cve_Gerente,
                Serie = a.Serie,
                Activo = a.Activo,
                FolioInicial = a.FolioInicial,
                LugarExpedicion = a.LugarExpedicion,
                Numeracion = conteo(),
                IdCoorporativo = a.E_Empresa.E_CoorporativoId,
                MensajePersonal = a.MensajePersonal,  
                TipoCentroTrabajo = a.TipoCentroTrabajo

            });

        }

        // GET: api/C_CentroTrabajo/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_CentroTrabajo>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
            .OrderBy(a => a.Nombre)
            .Where(a => a.E_Empresa.E_Coorporativo.IdCoorporativo == IdCorporativo)
            
            .ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return CentroTrabajo.Select(a => new GET_CentroTrabajo
            {
                IdCentroTrabajo = a.IdCentroTrabajo,
                E_EmpresaId = a.E_EmpresaId,
                Nombre = a.Nombre,
                Responsable = a.Responsable,
                Direccion = a.Direccion,
                Telefono = a.Telefono,
                Email = a.Email,
                Cve_Gerente = a.Cve_Gerente,
                Serie = a.Serie,
                Activo = a.Activo,
                FolioInicial = a.FolioInicial,
                LugarExpedicion = a.LugarExpedicion,
                Numeracion = conteo(),
                MensajePersonal = a.MensajePersonal,
                TipoCentroTrabajo = a.TipoCentroTrabajo,


            });

        }


        // GET: api/C_CentroTrabajo/ListarporEmpresaGenerales
        [HttpGet("[action]/{IdEmpresa}")]
        public async Task<IEnumerable<GET_CentroTrabajo>> ListarporEmpresaGenerales([FromRoute] int IdEmpresa)
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
            .OrderBy(a => a.Nombre)
            .Where(a => a.E_EmpresaId == IdEmpresa)
            .Where(a => a.TipoCentroTrabajo == "Concina" || a.TipoCentroTrabajo =="Alamcen")
            .Include(a => a.E_Empresa.E_Coorporativo)
            .ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return CentroTrabajo.Select(a => new GET_CentroTrabajo
            {
                IdCentroTrabajo = a.IdCentroTrabajo,
                E_EmpresaId = a.E_EmpresaId,
                Nombre = a.Nombre,
                Responsable = a.Responsable,
                Direccion = a.Direccion,
                Telefono = a.Telefono,
                Email = a.Email,
                Cve_Gerente = a.Cve_Gerente,
                Serie = a.Serie,
                Activo = a.Activo,
                FolioInicial = a.FolioInicial,
                LugarExpedicion = a.LugarExpedicion,
                Numeracion = conteo(),
                IdCoorporativo = a.E_Empresa.E_CoorporativoId,
                MensajePersonal = a.MensajePersonal,
               TipoCentroTrabajo = a.TipoCentroTrabajo,

            });

        }


        // GET: api/CentroTrabajo/ListarUna
        [HttpGet("[action]/{IdCentroTrabajo}")]
        public async Task <IActionResult> ListarUna([FromRoute]int IdCentroTrabajo)
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
                .Where(a => a.IdCentroTrabajo == IdCentroTrabajo)
                .FirstOrDefaultAsync();

            return Ok(new { Direccion = CentroTrabajo.Direccion });

        }

        // GET: api/CentroTrabajo/ListarMsjCentroTrabajo
        [HttpGet("[action]/{IdCentroTrabajo}")]
        public async Task<IActionResult> ListarMsjCentroTrabajo([FromRoute] int IdCentroTrabajo)
        {
            var CentroTrabajo = await _context.E_CentroTrabajos
                .Where(a => a.IdCentroTrabajo == IdCentroTrabajo)
                .FirstOrDefaultAsync();

            return Ok(new { Msj = CentroTrabajo.MensajePersonal });

        }

    }
}
