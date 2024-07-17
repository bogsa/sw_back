using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Productos.Categoria;
using sw.Datos;
using sw.Entidades.Productos.Categoria;


namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Categoria/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Categoria>> Listar()
        {
            var Categoria = await _context.E_Categorias
            .Include(a => a.E_Departamento)
            .OrderBy(a => a.Nombre)
            .ToListAsync();



            return Categoria.Select(a => new GET_Categoria

            {
                IdCategoria = a.IdCategoria,
                Nombre = a.Nombre,
                Status = a.Status,
                E_DepartamentoId = a.E_DepartamentoId,
                NombreDepartamento = a.E_Departamento.Nombre

            });

        }
      
       

        // PUT: api/Categoria/Actualizar
        //[Authorize(Roles = " Administrador")]
                [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Categoria model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Categoria = await _context.E_Categorias.FirstOrDefaultAsync(a => a.IdCategoria == model.IdCategoria);

            if (Categoria == null)
            {
                return NotFound();
            }


            Categoria.IdCategoria = model.IdCategoria;
            Categoria.Nombre = model.Nombre;
            Categoria.Status = model.Status;
            Categoria.E_DepartamentoId = model.E_DepartamentoId;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La categoria: {model.Nombre} se actualizo correctamente"
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
        // POST: api/Categoria/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Categoria model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistNombre = await _context.E_Categorias.FirstOrDefaultAsync(a => a.Nombre == model.Nombre);

            if (ExistNombre != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una categoria con este nombre: {model.Nombre}"
                });
            }

            E_Categoria Categoria = new E_Categoria
            {
                Nombre = model.Nombre,
                Status = model.Status,
                E_DepartamentoId = model.E_DepartamentoId

            };

            _context.E_Categorias.Add(Categoria);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La categoria: {model.Nombre} se registro correctamente"
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
        // GET: api/C_Categoria/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Categoria>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var Categoria = await _context.E_Categorias
            .Include(a => a.E_Departamento)
            .Include(a => a.E_Departamento.E_Corporativo)
            .Where(a => a.E_Departamento.E_CorporativoId == IdCorporativo)
            .OrderBy(a => a.Nombre)
            .ToListAsync();



            return Categoria.Select(a => new GET_Categoria

            {
                IdCategoria = a.IdCategoria,
                E_DepartamentoId = a.E_DepartamentoId,
                NombreDepartamento = a.E_Departamento.Nombre,
                NombreCorporativo = a.E_Departamento.E_Corporativo.Nombre,
                Nombre = a.Nombre,
                Status = a.Status,

            });

        }
        // GET: api/C_Categoria/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Categoria>> ListarporCorporativoStatus([FromRoute] int IdCorporativo)
        {
            var Categoria = await _context.E_Categorias
            .Include(a => a.E_Departamento)
            .Include(a => a.E_Departamento.E_Corporativo)
            .Where(a => a.E_Departamento.E_CorporativoId == IdCorporativo)
            .Where(a => a.Status == true)
            .OrderBy(a => a.Nombre)
            .ToListAsync();



            return Categoria.Select(a => new GET_Categoria

            {
                IdCategoria = a.IdCategoria,
                E_DepartamentoId = a.E_DepartamentoId,
                NombreDepartamento = a.E_Departamento.Nombre,
                NombreCorporativo = a.E_Departamento.E_Corporativo.Nombre,
                Nombre = a.Nombre,
                Status = a.Status,

            });

        }
        // PUT: api/C_Categoria/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest(new
                {
                    error = "El ID de la categoria no existe"
                });
            }

            var categoria = await _context.E_Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Status = false;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "La categoria de deshabilito correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar deshabilitar la categoria"
                });
            }


        }
        // PUT: api/_Categoria/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest(new
                {
                    error = "El ID  de la categoria no existe"
                });
            }

            var categoria = await _context.E_Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Status = true;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "La categoria se activo correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar activar la categoria"
                });
            }
        }


 
    }
}
