using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sw.Controladores.Model.Administracion.Perfiles;
using sw.Controladores.Model.Administracion.Usuarios;
using sw.Datos;
using sw.Entidades.Administracion.UsuarioEmpresas;
using sw.Entidades.Administracion.UsuarioCentroTrabajoes;
using sw.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRol> _roleManager;
        private readonly ILogger<C_UsuariosController> _logger;

        public C_UsuariosController(
           ApplicationDbContext context,
           UserManager<ApplicationUser> userManager,
           RoleManager<ApplicationRol> roleManager,
           ILogger<C_UsuariosController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CrearUsuario([FromBody] POST_Usuario model)
        {



            if (ModelState.IsValid)
            {
                var v_usuario = await _userManager.FindByNameAsync(model.Usuario);

                if (v_usuario != null)
                {
                    return BadRequest(new
                    {
                        error = $"Ya existe un usuario con el nombre {model.Usuario}"
                    });
                }

                var v_email = await _userManager.FindByEmailAsync(model.Email);

                if (v_email != null)
                {
                    return BadRequest(new
                    {
                        error = $"Ya existe un usuario con este email {model.Email}"
                    });
                }

                var user = new ApplicationUser
                {
                    Perfil = model.Perfil,
                    NombreCompleto = model.NombreCompleto,
                    PhoneNumber = model.Telefono,
                    Email = model.Email,
                    UserName = model.Usuario,
                    E_CentroTrabajoId = model.e_CentroTrabajoId,
                    Aprobado = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error al intentar crear el usuario");
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
        // PUT: api/C_FormaPago/ActualizarUsuario
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] PUT_Usuario model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }

            var Data = await _context.Users.FirstOrDefaultAsync(a => a.Id == model.idUsuario);

            if (Data == null)
            {
                return NotFound();
            }

            Data.NombreCompleto = model.NombreCompleto;
            Data.Email = model.Email;
            Data.PhoneNumber = model.Telefono;
            Data.Perfil = model.Perfil;
            Data.E_CentroTrabajoId = model.e_CentroTrabajoId;


            //if (model.cPassword == true)
            //{
            //    var v_usuario = await _userManager.FindByNameAsync(model.Usuario);
            //    if (v_usuario.PasswordHash != null)
            //    {
            //        await _userManager.RemovePasswordAsync(v_usuario);
            //    }

            //    await _userManager.AddPasswordAsync(v_usuario, model.Password);
            //    //await _userManager.ChangePasswordAsync(v_usuario, model.)
            //}


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El usuario: {model.Usuario} se actualizo correctamente"
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
        [HttpPost("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_UsuarioAprobado model)
        {



            if (ModelState.IsValid)
            {

                var msg = "";
                if (model.Aprobado == true)
                {
                    msg = "El usuario se aprobo correctamente";
                }
                else
                {
                    msg = "El usuario se desaprobo correctamente";
                }

                var user = await _userManager.FindByIdAsync(model.IdUsuario);


                user.Aprobado = model.Aprobado;



                var result = await _userManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        result = msg
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        error = "Error al intentar aprovar al usuario"
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

        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Usuarios>> ListarUsuarios()
        {
            var usuarios = await _userManager.Users
                                .Include(a => a.E_CentroTrabajo)
                                .Include(a => a.E_CentroTrabajo.E_Empresa)
                                .Include(a => a.E_CentroTrabajo.E_Empresa.E_Coorporativo)
                                .ToListAsync();


            return usuarios.Select(a => new GET_Usuarios
            {

                idUsuario = a.Id,
                UserName = a.UserName,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                LockoutEnd = a.LockoutEnd,
                LockoutEnable = a.LockoutEnabled,
                AccesFailedCount = a.AccessFailedCount,
                Perfil = a.Perfil,
                Aprobado = a.Aprobado,
                NombreCompleto = a.NombreCompleto,
                e_CentroTrabajoId = a.E_CentroTrabajoId,
                CentroTrabajo = a.E_CentroTrabajo.Nombre,
                e_CorporativoId = a.E_CentroTrabajo.E_Empresa.E_CoorporativoId,
                e_EmpresaId = a.E_CentroTrabajo.E_EmpresaId,




            });
        }

        [HttpPost("[action]")]
        public IActionResult ListarRolesUsuario([FromBody] POST_Roles model)
        {
            List<GET_RolesUsuario> list = new List<GET_RolesUsuario>();
            if (ModelState.IsValid)
            {
                foreach (var x in model.ListaRoles)
                {
                    list.AddRange(BuscarRol(x.IdRol).ToList());
                }
                return Ok(list);
            }
            else
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }

        }
        [HttpGet("[action]")]
        private IEnumerable<GET_RolesUsuario> BuscarRol(string IdRol)
        {
            var data = _context.Roles.Where(a => a.Id == IdRol).OrderBy(a => a.Prioridad).ToList();

            return data.Select(a => new GET_RolesUsuario
            {
                IdRol = a.Id,
                NombreRol = a.Name,
                Icono = a.Icono,
                Color = a.Color,
                Tooltip = a.Tooltip
            });
        }








         










        [HttpPost("[action]")]
        public async Task<IActionResult> AsignarRolUsuario([FromBody] POST_RolUsuario model)
        {
            if (ModelState.IsValid)
            {
                var idUsuario = model.IdUsuario.ToString();
                var user = await _userManager.FindByIdAsync(idUsuario);
                if (user == null)
                {
                    return BadRequest(new
                    {
                        error = "No existe un usuario con esta información"
                    });
                }

                try
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, roles.ToArray());

                    var claims = await _userManager.GetClaimsAsync(user);
                    await _userManager.RemoveClaimsAsync(user, claims.ToArray());

                    foreach (var rol in model.Roles)
                    {

                        var data = await _context.UserRoles
                                                  .Where(a => a.UserId == user.Id)
                                                  .Where(a => a.RoleId == rol.RolId)
                                                  .FirstOrDefaultAsync();
                        if (data == null)
                        {
                            ApplicationUserRole userRoles = new ApplicationUserRole
                            {
                                UserId = user.Id,
                                RoleId = rol.RolId,
                            };
                            _context.UserRoles.Add(userRoles);

                            foreach (var claim in rol.children)
                            {
                                var datac = await _context.UserClaims
                                                .Where(a => a.UserId == user.Id)
                                                .Where(a => a.ClaimType == claim.ClaimName)
                                                .Where(a => a.ClaimValue == claim.ClaimValue)
                                                .FirstOrDefaultAsync();
                                if (datac == null)
                                {
                                    ApplicationUserClaim userClaim = new ApplicationUserClaim
                                    {
                                        UserId = user.Id,
                                        ClaimType = claim.ClaimName,
                                        ClaimValue = claim.ClaimValue
                                    };
                                    _context.UserClaims.Add(userClaim);
                                }
                            }
                        }
                    }

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest(new
                    {
                        error = "Error al intentar asignar los roles y claims"
                    });
                }

                return Ok(new
                {
                    result = "Los roles y claims se agregaron correctamente"
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

        [HttpPost("[action]")]
        public async Task<IActionResult> AsignarClaimUsuario([FromBody] POST_ClaimUser model)
        {
            if (ModelState.IsValid)
            {
                var v_usuario = await _userManager.FindByNameAsync(model.Usuario);

                if (v_usuario == null)
                {
                    return BadRequest(new
                    {
                        error = $"No existe un usuario con el nombre {model.Usuario}"
                    });
                }

                var userClaim = new Claim(model.ClaimName, model.ClaimValue);
                var v_claimUser = await _userManager.GetUsersForClaimAsync(userClaim);

                if (v_claimUser == null)
                {
                    return BadRequest(new
                    {
                        error = $"El usuario  ya cuenta con el permiso: {model.ClaimName}"
                    });
                }

                var result = await _userManager.AddClaimAsync(v_usuario, userClaim);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest(new
                {
                    error = $"No fue posible agregar el permiso al usuario {model.Usuario}"
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
        //[HttpPost("[action]")]
        //public async Task<IActionResult> EliminarRolUsuario([FromBody] POST_RolUsuario model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var idUsuario = model.IdUsuario.ToString();
        //        var user = await _userManager.FindByIdAsync(idUsuario);
        //        if (user == null)
        //        {
        //            return BadRequest(new
        //            {
        //                error = $"No existe un usuario con esta información"
        //            });
        //        }



        //        var result = await _userManager.RemoveFromRoleAsync(user, model.Rol);

        //        if (result.Succeeded)
        //        {

        //            return Ok(new
        //            {
        //                result = $"Se elimino el rol: { model.Rol}"
        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                error = $"Error al intentar eliminar el rol: { model.Rol}."
        //            });
        //        }

        //    }
        //    else
        //    {
        //        return BadRequest(new
        //        {
        //            error = ModelState
        //        });
        //    }

        //}

        // GET: api/C_Usuarios/UsuarioEmpresas 
        [HttpGet("[action]/{UserId}")]
        public async Task<IEnumerable<GET_UsuarioEmpresas>> UsuarioEmpresas([FromRoute] string UserId)
        {
            var Empresas = await _context.E_UsuarioEmpresas
                                .Where(a => a.UserId == UserId)
                                .Include(a => a.E_Empresa)
                                .ToListAsync();


            if (Empresas.Count == 0)
            {
                return Enumerable.Empty<GET_UsuarioEmpresas>();
            }
            else
            {
                return Empresas.Select(a => new GET_UsuarioEmpresas
                {
                    E_EmpresaId = a.E_EmpresaId,
                    NombreEmpresa = a.E_Empresa.Nombre,

                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CrearUsuarioEmpresas([FromBody] POST_UsuarioEmpresas model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var empresa in model.Empresas)
            {

                var data = await _context.E_UsuarioEmpresas
                                .Where(a => a.E_EmpresaId == empresa.IdEmpresa)
                                .Where(a => a.UserId == model.idUsuario)
                                .FirstOrDefaultAsync();
                if (data == null)
                {
                    E_UsuarioEmpresas Empresa = new E_UsuarioEmpresas
                    {
                        UserId = model.idUsuario,
                        E_EmpresaId = empresa.IdEmpresa,


                    };

                    _context.E_UsuarioEmpresas.Add(Empresa);
                }
                else
                {
                    _context.E_UsuarioEmpresas.Remove(data);
                }

            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "No fue posible crear las empresas asignadas"
                });
            }

            return Ok(new
            {
                result = "La empresas se asignaron corretamente"
            });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearUsuarioCentroTrabajo([FromBody] POST_UsuarioCentroTrabajo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var ct in model.CentroTrabajoes)
            {
                var data = await _context.E_UsuarioCentroTrabajo
                               .Where(a => a.E_CentroTrabajoId == ct.IdCentroTrabajo)
                               .Where(a => a.UserId == model.IdUsuario)
                               .FirstOrDefaultAsync();
                if (data == null)
                {

                    E_UsuarioCentroTrabajoes CentroTrabajo = new E_UsuarioCentroTrabajoes
                    {
                        UserId = model.IdUsuario,
                        E_CentroTrabajoId = ct.IdCentroTrabajo,


                    };

                    _context.E_UsuarioCentroTrabajo.Add(CentroTrabajo);
                }
                else
                {
                    _context.E_UsuarioCentroTrabajo.Remove(data);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "No fue posible crear las empresas asignadas"
                });
            }

            return Ok(new
            {
                result = "La empresas se asignaron corretamente"
            });
        }

        // GET: api/C_Usuarios/UsuarioCentroTrabajoes 
        [HttpGet("[action]/{UserId}")]
        public async Task<IEnumerable<GET_UsuarioCentroTrabajo>> UsuarioCentroTrabajoes([FromRoute] string UserId)
        {
            var CentroTrabajo = await _context.E_UsuarioCentroTrabajo
                                .Where(a => a.UserId == UserId)
                                .Include(a => a.E_CentroTrabajo)
                                .ToListAsync();

            if (CentroTrabajo.Count == 0)
            {
                return Enumerable.Empty<GET_UsuarioCentroTrabajo>();
            }
            else
            {

                return CentroTrabajo.Select(a => new GET_UsuarioCentroTrabajo
                {
                    CentroTrabajoId = a.E_CentroTrabajoId,
                    NombreCentroTrabajo = a.E_CentroTrabajo.Nombre,

                });
            }
        }

        // GET: api/C_Usuarios/CentroTrabajoAsignada 
        [HttpGet("[action]/{user}")]
        public async Task<IActionResult> CentroTrabajoAsignado([FromRoute] string user)
        {
            var usuario = await _userManager.FindByIdAsync(user);
            if (usuario == null)
            {
                return BadRequest(new
                {
                    error = "Error el usuario no existe."
                });
            }

            var sucAsignada = await _context.E_CentroTrabajos.FirstOrDefaultAsync(a => a.IdCentroTrabajo == usuario.E_CentroTrabajoId);


            return Ok(new
            {
                result = sucAsignada.Nombre
            });
        }

        // PUT: api/C_Usuarios/AsignarCentroTrabajo 
        [HttpPut("[action]/{user}/{CentroTrabajo}")]
        public async Task<IActionResult> AsignarCentroTrabajo([FromRoute] string user, int CentroTrabajo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(user);
                usuario.E_CentroTrabajoId = CentroTrabajo;
                await _userManager.UpdateAsync(usuario);
                return Ok(new
                {
                    result = "El Centro de trabajo se asigno correctamente"
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
