using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Administracion.TFDs;
using sw.Controladores.Model.Administracion.TFDs;
using sw.Datos;
using sw.Entidades.Administracion.TFDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_TFDController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_TFDController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_TFD/ListarTFDsGlobal
        [HttpGet("[action]")]

        // GET: api/C_Coorporativo/ListarTFDsGlobal
        [HttpGet("[action]/{IdCoorporativo}")]
        public async Task<IActionResult> ListarTFDsGlobal()
        {
            var totalTFDs = await _context.E_TFDsGlobals 
                .FirstOrDefaultAsync();


            return Ok(new { total = totalTFDs.TotalTFD  });
             

        }

        
        // GET: api/C_TFD/ListarTFDsDetalle
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_TFDsDetalle>> ListarTFDsDetalle()
        {
            var data = await _context.E_TFDsDetalles.ToListAsync();


            return data.Select(a => new GET_TFDsDetalle
            {
                IdDetalleTFD = a.IdDetalleTFD,
                FechaCompra = a.FechaCompra,
                Precio = a.Precio,
                CantidadTFD = a.CantidadTFD,    
            });

        }

        // GET: api/C_TFD/ListarAsignacionTFDs
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_AsignacionTFD>> ListarAsignacionTFDs()
        {
            var data = await _context.E_AsignacionTFDs
                            .Include(a => a.E_Empresa)    
                            .ToListAsync();


            return data.Select(a => new GET_AsignacionTFD
            {
                IdAsignacionTFDs = a.IdAsignacionTFDs,
                FechaAsignacion = a.FechaAsignacion,
                Precio = a.Precio,
                NombreEmpresa = a.E_Empresa.Nombre,
                RFC = a.E_Empresa.RFC,
                CantidadTFD = a.CantidadTFD,
            });

        }

        // POST: api/C_TFD/CrearTFDsDetalle
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearTFDsDetalle([FromBody] POST_TFDsDetalle model)
        {

            var fechaHora = DateTime.Now;
            E_TFDsDetalle registro = new E_TFDsDetalle
            {
                Precio =  model.Precio,
                FechaCompra = fechaHora,
                CantidadTFD = model.CantidadTFD,
                E_TFDsGlobalId = 1,
            };

            _context.E_TFDsDetalles.Add(registro);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"Los timbres fiscales digitales se registrarón correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear el registro"
                });
            }

        }


        // POST: api/C_TFD/CrearAsignacionTFDs
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearAsignacionTFDs([FromBody] POST_AsignacionTFDs model)
        {

            var fechaHora = DateTime.Now;

            E_AsignacionTFD registro = new E_AsignacionTFD
            {
                E_EmpresaId = model.E_EmpresaId,
                Precio = model.Precio,
                CantidadTFD = model.CantidadTFD,
                FechaAsignacion = fechaHora,
               
            };

            _context.E_AsignacionTFDs.Add(registro);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"Los timbres fiscales digitales se registrarón correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear el registro"
                });
            }

        }
        // DELETE: api/C_TFD/EliminarTDFsDetalle
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> EliminarTDFsDetalle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.E_TFDsDetalles.FindAsync(id);
            if (registro == null)
            {
                return BadRequest(new
                {
                    error = "No existe el menú"
                });
            }

            _context.E_TFDsDetalles.Remove(registro);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El registro  se elimino correctamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.ToString()
                });
            }

        }

    }
}
