using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Administracion.Perfiles;
using sw.Datos;
using sw.Entidades.Administracion.PerfilesPer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;
     
     public C_PerfilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/C_Perfil/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Perfil>> Listar()
        {
            var data = await _context.E_Perfil.ToListAsync();


            return data.Select(a => new GET_Perfil
            {
                IdPerfil = a.IdPerfil,
               NombrePerfil = a.NombrePerfil, 

            });

        }

        // PUT: api/C_Perfil/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Perfil model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var Exist = await _context.E_Perfil.FirstOrDefaultAsync(a => a.NombrePerfil == model.NombrePerfil);

            if (Exist != null)
            {
                
                    return BadRequest(new
                    {
                        error = $"Ya existe un perfil con el mismo nombre: { model.NombrePerfil}"
                    });
               

            }

         

            var Data = await _context.E_Perfil.FirstOrDefaultAsync(a => a.IdPerfil == model.IdPerfil);

            if (Data == null)
            {
                return NotFound();
            }
            Data.NombrePerfil = model.NombrePerfil; 


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El perfil: { model.NombrePerfil } se actualizo correctamente"
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

        // POST: api/C_Perfil/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Perfil model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var Exist = await _context.E_Perfil.FirstOrDefaultAsync(a => a.NombrePerfil == model.NombrePerfil);

            if (Exist != null)
            {
               
                    return BadRequest(new
                    {
                        error = $"Ya existe un perfil con el mismo nombre: { model.NombrePerfil}"
                    });
              

            }



            E_Perfil Perfil = new E_Perfil
            {
                NombrePerfil = model.NombrePerfil, 
            };

            _context.E_Perfil.Add(Perfil);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El perfil: { model.NombrePerfil } se registro correctamente"
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

        // GET: api/C_Perfil/ListarMisModulos
        [HttpGet("[action]/{idPerfil}")]
        public async Task<IEnumerable<GET_Modulo>> ListarMisModulos([FromRoute] int idPerfil)
        {
            var data = await _context.E_Modulo
                                     .Where(a => a.E_PerfilId == idPerfil)
                                     .Include(a => a.Rol)
                                     .ToListAsync(); 

            return data.Select(a => new GET_Modulo
            {
                IdModulo = a.IdModulo,
                NombreRol = a.Rol.Name,
                RolId = a.RolId, 
            });
        }

        // GET: api/C_Perfil/ListarModulosPermisos
        [HttpGet("[action]/{idPerfil}")] 
        public async Task<IEnumerable<GET_ModulosPerfil>> ListarModulosPermisos([FromRoute] int idPerfil)
        {
            List<GET_ModulosPerfil> list = new List<GET_ModulosPerfil>();

            var Tabla = await _context.E_Modulo
                            .Where(a => a.E_PerfilId == idPerfil)
                            .Include(a => a.E_Perfil)
                            .Include(a => a.Rol)
                            .ToListAsync();


            if (Tabla.Count == 0)
            {
                return Enumerable.Empty<GET_ModulosPerfil>();
            }
            else
            {
                foreach (var x in Tabla.ToList())
                {
                    list.Add(new GET_ModulosPerfil
                    {
                        id = x.IdModulo,
                        name = x.Rol.Name,
                        title = x.Rol.Name,
                        RolId = x.RolId,
                        children = BuscarPermisos(idPerfil, x.IdModulo).ToList()

                    });
                }
                return list;
            }
        }

        private IEnumerable<GET_PermisosPerfil> BuscarPermisos(int idPerfil, int idModulo)
        {
            var data = _context.E_Permiso
                        .Where(a => a.E_Modulo.E_PerfilId == idPerfil)
                        .Where(a => a.E_ModuloId == idModulo)
                        .Include(a => a.E_Modulo)
                        .Include(a => a.E_Modulo.E_Perfil)
                        .Include(a => a.Claim)
                        .ToList();


            return data.Select(a => new GET_PermisosPerfil
            {
                id = a.IdPermiso,
                name = a.Claim.ClaimType+ "/"+ a.Claim.ClaimValue,
                title = a.Claim.ClaimValue,
                ClaimName = a.Claim.ClaimType,
                ClaimValue = a.Claim.ClaimValue,
            });
        }




        // POST: api/C_Perfil/AsignarModuloPerfil
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AsignarModuloPerfil([FromBody] POST_ModuloPerfil model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var Exist = await _context.E_Modulo
                                 .Where(a => a.E_PerfilId == model.E_PerfilId)
                                 .Where(a => a.RolId == model.RolId).FirstOrDefaultAsync();


            if (Exist != null)
            {
                return BadRequest(new
                {
                    error = $"El modulo: { model.RolId } ya esta registrado en este perfil "
                });
            }



            E_Modulo Modulo = new E_Modulo
            {
                E_PerfilId = model.E_PerfilId,
                RolId = model.RolId,
            };

            _context.E_Modulo.Add(Modulo);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El modulo: { model.RolId } se registro correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar registrar el módulo"
                });
            }

        }

        // DELETE: api/C_Perfil/EliminarModuloPerfil
        [HttpDelete("[action]/{idPerfil}/{idModulo}")]
        public async Task<IActionResult> EliminarModuloPerfil([FromRoute] int idPerfil, int idModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registro = await _context.E_Modulo
                           .Where(a => a.E_PerfilId == idPerfil)
                           .Where(a => a.IdModulo == idModulo)
                           .FirstOrDefaultAsync();




            if (registro == null)
            {
                return BadRequest(new
                {
                    error = "No existe el modulo"
                });
            }

            _context.E_Modulo.Remove(registro);
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

        // GET: api/C_Perfil/ListarMisPermisos
        [HttpGet("[action]/{idmodulo}")]
        public async Task<IEnumerable<GET_Permiso>> ListarMisPermisos([FromRoute] int idmodulo)
        {
            var data = await _context.E_Permiso
                                     .Where(a => a.E_ModuloId == idmodulo)
                                     .Include(a => a.Claim)
                                     .ToListAsync();

            return data.Select(a => new GET_Permiso
            {
                id = a.IdPermiso,
                ClaimName = a.Claim.ClaimType,
                ClaimValue = a.Claim.ClaimValue,
             

            });
        }
        // POST: api/C_Perfil/AsignarPermiso
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AsignarPermiso([FromBody] POST_PermisoModulo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            E_Permiso Modulo = new E_Permiso
            {
                E_ModuloId = model.E_ModuloId,
                ClaimId = model.ClaimId,
            };

            _context.E_Permiso.Add(Modulo);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El permiso: { model.ClaimId } se registro correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar registrar el permiso"
                });
            }

        }
        // DELETE: api/C_Perfil/EliminarPermiso
        [HttpDelete("[action]/{idPermiso}")]
        public async Task<IActionResult> EliminarPermiso([FromRoute] int idPermiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.E_Permiso.FindAsync(idPermiso);

      
            if (registro == null)
            {
                return BadRequest(new
                {
                    error = "No existe el permiso"
                });
            }

            _context.E_Permiso.Remove(registro);
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
