using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; 
using sw.Datos;
using Microsoft.Extensions.Logging; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using sw.Controladores.Model.Administracion.Modulos;
using Microsoft.AspNetCore.Authorization;
using sw.Entidades.Identity;
using sw.Controladores.Model.Administracion.Permisos;

namespace sw.Controladores.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class C_ModulosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRol> _roleManager;
        private readonly ILogger<C_ModulosController> _logger;

        public C_ModulosController(
           ApplicationDbContext context,
           UserManager<ApplicationUser> userManager,
           RoleManager<ApplicationRol> roleManager,
           ILogger<C_ModulosController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        
 
        [HttpGet("[action]")]  
        public async Task<IEnumerable<GET_Roles>> ListarRoles()
        {
            var Tabla = await _context.Roles
                            .OrderBy(x => x.Prioridad)
                            .ToListAsync();

            if (Tabla.Count == 0)
            {
                return Enumerable.Empty<GET_Roles>();
            }
            else
            {
                return Tabla.Select(a => new GET_Roles
                {
                    IdRol = a.Id,
                    NombreRol = a.Name,
                    Icono = a.Icono,
                    Color = a.Color,
                    Prioridad = a.Prioridad,
                    Tooltip = a.Tooltip,
                    Activo = a.Activo,
                    Status = false,
                    idModulo = 0,
                    
                });
            }
        }

      

        [HttpGet("[action]/{idUsuario}")]
        public async Task<IActionResult> ListarMisRoles([FromRoute] string idUsuario)
        {

            var user = await _userManager.FindByIdAsync(idUsuario);

            var userRoles = await _userManager.GetRolesAsync(user);


     
            return Ok(new
            {
                result = userRoles
            });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearRol([FromBody] POST_Rol model)
        {
            if (ModelState.IsValid)
            {
                var v_rol = await _roleManager.FindByNameAsync(model.NombreRol);

                if (v_rol != null)
                {
                    return BadRequest(new
                    {
                        error = $"Ya existe un rol con este nombre { model.NombreRol}"
                    });
                }


                var result = await _roleManager.CreateAsync(new ApplicationRol(model.NombreRol, model.Icono, model.Color, model.Tooltip, model.Prioridad, model.Activo));


                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        result = $"El rol { model.NombreRol} se creo correctamente"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        error = "Error al intentar crear el rol"
                    });

                }
            }
            else
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }

        }

     
        [HttpDelete("[action]/{IdRol}")]
        public async Task<IActionResult> EliminarRol([FromRoute] Guid IdRol)
        {
            if (ModelState.IsValid)
            {

                var rol = await _roleManager.FindByIdAsync(IdRol.ToString());
                if (rol == null)
                {
                    return BadRequest(new
                    {
                        error = $"No existe un modulo con esta información"
                    });
                }

                var result = await _roleManager.DeleteAsync(rol);

                if (result.Succeeded)
                {

                    return Ok(new
                    {
                        result = "El módulo se elimino correctamente."
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        error = "Error al intentar eliminar el módulo"
                    });
                }

            }
            else
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }

        }

        
        [HttpPost("[action]")]
        public async Task<IActionResult> ActualizarRol([FromBody] PUT_Rol model)
        {
            if (ModelState.IsValid)
            {
                var id = model.IdRol.ToString();
                var role = await _roleManager.FindByIdAsync(id);
                role.Name = model.NombreRol;
                role.Color = model.Color;
                role.Icono = model.Icono;
                role.Tooltip = model.Tooltip;
                role.Prioridad = model.Prioridad;
                role.Activo = model.Activo;

                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {

                    return Ok(new
                    {
                        result = $"El rol { model.NombreRol } se actualizo correctamente"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        error = "Error al intentar actualizar el rol."
                    });
                }

            }
            else
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }

        }

       
    }
}
