using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.Impuesto;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_ImpuestoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_ImpuestoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/C_Impuesto/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Impuesto>> Listar()
        {
            var Impuesto = await _context.E_Impuesto
                .OrderBy (a => a.Clave) 
                .ToListAsync();

           

            return Impuesto.Select(a => new GET_Impuesto
            {
                IdImpuesto = a.IdImpuesto,
                Clave = a.Clave,
                Descripcion = a.Descripcion, 

            });

        }      

        // PUT: api/C_Impuesto/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        //[Authorize(Policy = "Policy_Impuestos_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Impuesto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            


            var Impuesto = await _context.E_Impuesto.FirstOrDefaultAsync(a => a.IdImpuesto == model.IdImpuesto);

            if (Impuesto == null)
            {
                return NotFound();
            }
            Impuesto.IdImpuesto = model.IdImpuesto;
            Impuesto.Clave = model.Clave;
            Impuesto.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El impuesto: { model.Descripcion } se actualizo correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar actualizar el registro"
                });
            }
        }
        // POST: api/C_Impuesto/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        //[Authorize(Policy = "Policy_Impuestos_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_Impuesto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_Impuesto.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_Impuesto.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un impuesto con este nombre: { model.Descripcion}"
                });
            }

            E_Impuesto Impuesto = new E_Impuesto
            {
                Clave = model.Clave,
                Descripcion = model.Descripcion

            };

            _context.E_Impuesto.Add(Impuesto);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El impuesto: { model.Descripcion } se registro correctamente"
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


    }
}
