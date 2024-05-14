using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Almacen.Departamento;
using sw.Datos;
using sw.Entidades.Articulos.Departamento;

using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_DepartamentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_DepartamentoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_Departamento/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Departamento>> Listar()
        {
            var Depto = await _context.E_Departamentos
            .Include(a => a.E_Corporativo)
            .OrderBy(a => a.Nombre)
            .ToListAsync();


            return Depto.Select(a => new GET_Departamento
            {
                IdDepartamento = a.IdDepartamento,
                E_CorporativoId = a.E_CorporativoId,
                NombreCorporativo = a.E_Corporativo.Nombre,
                Nombre = a.Nombre,
                Status = a.Status
            });

        }


        // PUT: api/C_Departamento/Actualizar 
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Departamento model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Depto = await _context.E_Departamentos.FirstOrDefaultAsync(a => a.IdDepartamento == model.IdDepartamento);

            if (Depto == null)
            {
                return NotFound();
            }

            Depto.IdDepartamento = model.IdDepartamento;
            Depto.E_CorporativoId = model.E_CorporativoId;
            Depto.Nombre = model.Nombre;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El departamento: {model.Nombre} se actualizo correctamente"
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

      


        // POST: api/C_Departamento/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Departamento model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistNombre = await _context.E_Departamentos.FirstOrDefaultAsync(a => a.Nombre == model.Nombre);

            if (ExistNombre != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un departamento con este nombre: {model.Nombre}"
                });
            }

            E_Departamento Depto = new E_Departamento
            {
                Nombre = model.Nombre,
                E_CorporativoId = model.E_CorporativoId,
                Status = true,

            };

            _context.E_Departamentos.Add(Depto);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El departamento: {model.Nombre} se registro correctamente"
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

        // GET: api/C_Departamento/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Departamento>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var depto = await _context.E_Departamentos
            .OrderBy(a => a.Nombre)
            .Where(a => a.E_CorporativoId == IdCorporativo)
            .Include(a => a.E_Corporativo)
            .ToListAsync();



            return depto.Select(a => new GET_Departamento
            {
                IdDepartamento = a.IdDepartamento,
                E_CorporativoId = a.E_CorporativoId,
                NombreCorporativo = a.E_Corporativo.Nombre,
                Nombre = a.Nombre,
                Status = a.Status


            });

        }


        // GET: api/C_Departamento/DGrafica
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_DGrafica>> DGrafica([FromRoute] int IdCorporativo)
        {
            var Tabla = await _context.E_Categorias
                .Include(v => v.E_Departamento)
                .Where(v => v.E_Departamento.E_CorporativoId == IdCorporativo)
                .GroupBy(v => v.E_Departamento.Nombre)
                .Select(x => new
                {
                    etiqueta = x.Key,
                    valor = x.Count(),
                })
                .OrderBy(x => x.etiqueta)
                .ToListAsync();

            return Tabla.Select(v => new GET_DGrafica
            {
                etiqueta = v.etiqueta,
                valor = v.valor


            });

        }

        // PUT: api/C_Departamento/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
               return BadRequest(new
                {
                    error = "El ID del departameno no existe"
                });
            }

            var departamento = await _context.E_Departamentos.FirstOrDefaultAsync(c => c.IdDepartamento == id);

            if (departamento == null)
            {
                return NotFound();
            }

            departamento.Status = false;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El departamento de deshabilito correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                  return BadRequest(new
                {
                    error = "Error al intentar deshabilitar el departamento"
                });
            }

    
        }

        // PUT: api/_Departamento/Activar/1
        [HttpPut("[action]/{id}")]
       public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                 return BadRequest(new
                {
                    error = "El ID del departameno no existe"
                });
            }

            var departamento = await _context.E_Departamentos.FirstOrDefaultAsync(c => c.IdDepartamento == id);

            if (departamento == null)
            {
                return NotFound();
            }

            departamento.Status = true;

           try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El departamento se activo correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                  return BadRequest(new
                {
                    error = "Error al intentar activar el departamento"
                });
            }
        }
    }
}
