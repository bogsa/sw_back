using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosAlmacen.Marca;
using sw.Datos;
using sw.Entidades.Configuracion.Almacen;


namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_MarcaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_MarcaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_Marca/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Marca>> Listar()
        {
            var data = await _context.E_Marcas.ToListAsync();


            return data.Select(a => new GET_Marca
            {
                IdMarca = a.IdMarca, 
                Descripcion = a.Descripcion,
                
            });

        }


        // PUT: api/C_Marca/Actualizar
        //[Authorize(Policy = "Policy_Marca_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Marca model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
    


            var Data = await _context.E_Marcas.FirstOrDefaultAsync(a => a.IdMarca == model.IdMarca);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdMarca = model.IdMarca;
            Data.E_CorporativoId = model.E_CorporativoId;
            Data.Descripcion = model.Descripcion; 


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La forma de pago: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_Marca/Crear
        //[Authorize(Policy = "Policy_Marca_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Marca model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            

            var ExistDesc = await _context.E_Marcas.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una marca con este nombre: { model.Descripcion}"
                });
            }


            E_Marca marca = new E_Marca
            {
                Descripcion = model.Descripcion, 
                E_CorporativoId = model.E_CorporativoId,
            };

            _context.E_Marcas.Add(marca);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La  marca: { model.Descripcion } se registro correctamente"
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
        
        
        // GET: api/C_Marca/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Marca>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var Marca = await _context.E_Marcas
            .OrderBy(a => a.Descripcion)
            .Where(a => a.E_CorporativoId == IdCorporativo) 
            .ToListAsync();



            return Marca.Select(a => new GET_Marca
            {
                IdMarca = a.IdMarca,
                E_CorporativoId = a.E_CorporativoId,
                Descripcion = a.Descripcion,
             
            });

        }


    }
}
