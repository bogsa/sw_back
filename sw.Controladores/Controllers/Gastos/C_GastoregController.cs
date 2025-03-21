using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.Gastos;
using sw.Datos;
using sw.Entidades.Configuracion.Gastos;
using sw.Entidades.Gastos;
using sw.Controladores.Model.Gastos;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_GastoregController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public C_GastoregController(ApplicationDbContext context)
        {
            _context = context;
        }


        // PUT: api/C_Gastoreg/Actualizar
        //[Authorize(Policy = "Policy_Gastoreg_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Gastoreg model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }



            var Data = await _context.E_Gastoreg.FirstOrDefaultAsync(a => a.IdGastoreg == model.IdGastoreg);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdGastoreg = model.IdGastoreg;
            Data.Monto = model.Monto;
            Data.Descripcion = model.Descripcion;
            Data.Fecha = model.Fecha;
            Data.E_GastoId = model.E_GastoId;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El gasto: {model.Descripcion} se actualizo correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar actualizar el registro"
                });
            }

        }


        // POST: api/C_Gastoreg/Crear
        //[Authorize(Policy = "Policy_Gastoreg_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Gastoreg model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }


            //var ExistDesc = await _context.E_Gastos.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion && a.E_CorporativoId == model.E_CorporativoId);

            //if (ExistDesc != null)
            //{
            //    return BadRequest(new
            //    {
            //        error = $"Ya existe un tipo de gasto con este nombre: {model.Descripcion}"
            //    });
            //}


            E_Gastoreg gastoreg = new E_Gastoreg
            {
                Monto = model.Monto,
                Descripcion = model.Descripcion,
                Fecha = model.Fecha,
                E_CentroTrabajoId = model.E_CentroTrabajoId,
                UserId = model.UserId,
                E_GastoId=model.E_GastoId,
            };

            _context.E_Gastoreg.Add(gastoreg);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El gasto: {model.Descripcion} se registro correctamente"
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


        // GET: api/C_Gastoreg/ListarporCentroTrabajoyFecha
        [HttpGet("[action]/{IdCentroTrabajo}/{Fecha}")]
        public async Task<IEnumerable<GET_Gastoreg>> ListarporCorporativo([FromRoute] int IdCentroTrabajo, DateTime Fecha)
        {
            var Gastoreg = await _context.E_Gastoreg
            .OrderBy(a => a.Descripcion)
            .Where(a => a.E_CentroTrabajoId == IdCentroTrabajo)
            .Where(a => a.Fecha == Fecha)
            .ToListAsync();



            return Gastoreg.Select(a => new GET_Gastoreg
            {
                IdGastoreg = a.IdGastoreg,
                E_CentroTrabajoId = a.E_CentroTrabajoId,
                Descripcion = a.Descripcion,
                Fecha = a.Fecha,
                E_GastoDesc= a.E_Gasto.Descripcion,
            });

        }


    }
}
