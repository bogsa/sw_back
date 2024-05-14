using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using sw.Datos;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using sw.Controladores.Model.Administracion.Permisos;
using sw.Entidades.Identity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_PermisosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRol> _roleManager;
        private readonly ILogger<C_PermisosController> _logger;

        public C_PermisosController(
           ApplicationDbContext context,
           UserManager<ApplicationUser> userManager,
           RoleManager<ApplicationRol> roleManager,
           ILogger<C_PermisosController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }


        [HttpGet("[action]/{rolname}")]
        public async Task<IActionResult> ListarClaimsRol([FromRoute] string rolname)
        {
            var rol = await _roleManager.FindByNameAsync(rolname);
            if (rol == null)
            {
                return BadRequest(new
                {
                    error = "Error, el rol no existe."
                });
            }
            var claims = await _roleManager.GetClaimsAsync(rol);
            return Ok(new
            {
                result = claims
            });
        }
        [HttpGet("[action]/{idRol}")]
        public async Task<IEnumerable<GET_ClaimRol>> ListarClaimsModulo([FromRoute] string idRol)
        {

            var Tabla = await _context.RoleClaims
                                  .Where(a => a.RoleId == idRol)
                                  .ToListAsync();

            if (Tabla.Count == 0)
            {
                return Enumerable.Empty<GET_ClaimRol>();
            }
            else
            {
                return Tabla.Select(a => new GET_ClaimRol
                {
                    id = a.Id,
                    ClaimName = a.ClaimType,
                    ClaimValue = a.ClaimValue,
                    Status = false,
                    IdPermiso = 0,

                });
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CrearClaimRol([FromBody] POST_ClaimRol model)
        {
            if (ModelState.IsValid)
            {
                var v_rol = await _roleManager.FindByNameAsync(model.Rol);
                if (v_rol == null)
                {
                    return BadRequest(new
                    {
                        error = $"El rol: {model.Rol} no existe"
                    });
                }
                var v_claimRol = await _roleManager.GetClaimsAsync(v_rol);
                foreach (var claim in v_claimRol)
                {
                    if (claim.Value == model.ClaimValue)
                    {
                        return BadRequest(new
                        {
                            error = $"El rol: {model.Rol} ya tiene un permiso con el nombre: {model.ClaimValue}"
                        });
                    }
                }

                var rolClaim = new Claim(model.ClaimName, model.ClaimValue);
                var result = await _roleManager.AddClaimAsync(v_rol, rolClaim);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        result = "El permiso se agrego correctamente"
                    });
                }
                return BadRequest(new
                {
                    error = $"No fue posible agregar el permiso: {model.ClaimName}"
                });


            }
            else
            {
                return BadRequest(new
                {
                    error = $"No fue posible agregar el permiso: {model.ClaimName}"
                });
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ElimnarClaimRol([FromBody] POST_ClaimRol model)
        {
            var v_rol = await _roleManager.FindByNameAsync(model.Rol);
            if (v_rol == null)
            {
                return BadRequest(new
                {
                    error = $"No existe un rol con este nombre {model.Rol}"
                });
            }
            var rolClaim = new Claim(model.ClaimName, model.ClaimValue);
            var removeClaimRol = await _roleManager.RemoveClaimAsync(v_rol, rolClaim);

            if (removeClaimRol.Succeeded)
            {
                return Ok(new
                {
                    result = $"El permiso {model.ClaimName} se elimino correctamente"
                });
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
