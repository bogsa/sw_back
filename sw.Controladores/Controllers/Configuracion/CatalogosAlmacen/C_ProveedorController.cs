using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using sw.Controladores.Model.Configuracion.CatalogosAlmacen.Proveedor;
using sw.Datos;
using sw.Entidades.Configuracion.Almacen;


namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_ProveedorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_ProveedorController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_Proveedor/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Proveedor>> Listar()
        {
            var data = await _context.E_Proveedor.ToListAsync();


            return data.Select(a => new GET_Proveedor
            {
                IdProveedor = a.IdProveedor, 
                Nombre = a.Nombre,
                SitioWeb = a.SitioWeb,
                Email = a.Email,
                Telefono = a.Telefono,                
            });

        }


        // PUT: api/C_Proveedor/Actualizar
        //[Authorize(Policy = "Policy_Marca_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Proveedor model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            } 

            var Data = await _context.E_Proveedor.FirstOrDefaultAsync(a => a.IdProveedor == model.IdProveedor);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdProveedor = model.IdProveedor;
            Data.E_CorporativoId = model.E_CorporativoId;
            Data.Nombre = model.Nombre; 
            Data.SitioWeb = model.SitioWeb;
            Data.Email = model.Email;
            Data.Telefono = model.Telefono;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El registro se actualizo correctamente"
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


        // POST: api/C_Proveedor/Crear
        //[Authorize(Policy = "Policy_Marca_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Proveedor model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            
            var ExistNom = await _context.E_Proveedor.FirstOrDefaultAsync(a => a.Nombre == model.Nombre);

            if (ExistNom != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un  proveedor con este nombre: { model.Nombre}"
                });
            }


            E_Proveedor proveedor = new E_Proveedor
            {
                E_CorporativoId  = model.E_CorporativoId, 
                Nombre = model.Nombre,
                SitioWeb = model.SitioWeb,
                Email = model.Email,
                Telefono = model.Telefono,

            };

            _context.E_Proveedor.Add(proveedor);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El porveedor: { model.Nombre } se registro correctamente"
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
        
        
        // GET: api/C_Proveedor/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Proveedor>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var proveedor = await _context.E_Proveedor
            .OrderBy(a => a.Nombre)
            .Where(a => a.E_CorporativoId == IdCorporativo) 
            .ToListAsync();



            return proveedor.Select(a => new GET_Proveedor
            {
                IdProveedor = a.IdProveedor,
                E_CorporativoId = a.E_CorporativoId,
                Nombre = a.Nombre,
                SitioWeb = a.SitioWeb,
                Telefono = a.Telefono,
                Email= a.Email, 
             
            });

        }


    }
}
