using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using sw.Datos;
using Microsoft.Extensions.Logging; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq; 
using sw.Entidades.Administracion.Menus;
using sw.Controladores.Model.Administracion.Menus;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_MenusController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        private readonly ILogger<C_MenusController> _logger;

        public C_MenusController(
            ApplicationDbContext context, 
            ILogger<C_MenusController> logger)
        {
            _context = context; 
            _logger = logger;
        }
      
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearMenu([FromBody] POST_Menu model)
        {
            
            if (ModelState.IsValid)
            {
                var v_menu = await _context.E_Menus
                                           .Where(a => a.IdRol == model.IdRol)
                                           .Where(a => a.Titulo == model.Titulo) 
                                           .ToListAsync();
                if (v_menu.Count > 0)
                {
                    
                    return BadRequest(new
                    {
                        error = $"El menu: { model.Titulo} ya existe ingresa otro nombre"
                    });
                }
                else
                {

                    E_Menu menu = new E_Menu
                    {
                        IdRol = model.IdRol,
                        Titulo = model.Titulo,
                        Icono = model.Icono,
                    };
                    _context.E_Menus.Add(menu);

                    try
                    {
                        await _context.SaveChangesAsync();

                        return Ok(new
                        {
                            result = $"El menú: {model.Titulo} se creo correctamente"
                        });
                    }
                    catch (Exception)
                    {
                        return BadRequest(new
                        {
                            error = $"Error al intentar crear el menu:{ model.Titulo}"
                        });
                    }


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

    
        [HttpDelete("[action]/{menuid}")]
        public async Task<IActionResult> EliminarMenu([FromRoute] Guid menuid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.E_Menus.FindAsync(menuid);
            if (menu == null)
            {
                return BadRequest(new
                {
                    error = "No existe el menú"
                });
            }

            _context.E_Menus.Remove(menu);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El menú se elimino correctamente"
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

 
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearSubMenu([FromBody] POST_SubMenu model)
        {
            if (ModelState.IsValid)
            {
                var v_menu = await _context.E_SubMenus
                                           .Where(a => a.MenuId == model.MenuId)
                                           .Where(a => a.Titulo == model.Titulo)
                                           .ToListAsync();
                if (v_menu.Count == 0)
                {
                    E_SubMenu submenu = new E_SubMenu
                    {
                        MenuId = model.MenuId,
                        Titulo = model.Titulo,
                        Icono = model.Icono,
                        Link = model.Link,
                    };
                    _context.E_SubMenus.Add(submenu);

                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok(new
                        {
                            result = $"El sub menú: {model.Titulo} se creo correctamente"
                        });
                    }
                    catch (Exception)
                    {
                        return BadRequest(new
                        {
                            error = $"Error al intentar crear el submenu:{ model.Titulo}"
                        });
                    }

                }
                else
                {

                    return BadRequest(new
                    {
                        error = $"El submenu: { model.Titulo} ya existe ingresa otro nombre"
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
 
        [HttpDelete("[action]/{submenuid}")]
        public async Task<IActionResult> EliminarSubMenu([FromRoute] Guid submenuid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submenu = await _context.E_SubMenus.FindAsync(submenuid);
            if (submenu == null)
            {
                return BadRequest(new
                {
                    error = "No existe el menú"
                });
            }

            _context.E_SubMenus.Remove(submenu);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El submenú se elimino correctamente"
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
 
        [HttpGet("[action]/{rolId}")]
        public async Task<IEnumerable<GET_MenuSubMenu>> ListarMenuSubMenu([FromRoute] Guid rolId)
        {
            List<GET_MenuSubMenu> list = new List<GET_MenuSubMenu>();

            var Tabla = await _context.E_Menus
                        .Where(a => a.IdRol == rolId)
                        .OrderBy(a => a.Titulo)
                      .ToListAsync();


            if (Tabla.Count == 0)
            {
                return Enumerable.Empty<GET_MenuSubMenu>();
            }
            else
            {
                foreach (var x in Tabla.ToList())
                {
                    list.Add(new GET_MenuSubMenu
                    {
                        Id = x.IdMenu,
                        RolId = x.IdRol,
                        Titulo = x.Titulo,
                        Icono = x.Icono,
                        Active = false,
                        SubMenus = BuscarSubMenu(x.IdMenu).ToList()

                    });


                }
                return list;
            }
        }

        [HttpGet("[action]/{rolId}")]
        public async Task<IEnumerable<GET_Menu>> ListarMenus([FromRoute] Guid rolId)
        {
       

            var data = await _context.E_Menus
                        .Where(a => a.IdRol == rolId)
                        .OrderByDescending(a => a.IdMenu) 
                        .ToListAsync();


            return data.Select(a => new GET_Menu
            {
                IdMenu = a.IdMenu,
                Titulo = a.Titulo,
                Icono = a.Icono,
                IdRol = a.IdRol,
            });
        }
        [HttpGet("[action]/{menuId}")]
        public async Task<IEnumerable<GET_SubMenu>> ListarSubMenus([FromRoute] Guid menuId)
        {
       

            var data = await _context.E_SubMenus
                        .Where(a => a.MenuId == menuId) 
                        .ToListAsync();


            return data.Select(a => new GET_SubMenu
            {
                IdSubMenu = a.IdSubMenu,
                Titulo = a.Titulo,
                Icono = a.Icono, 
            });
        }

        private IEnumerable<GET_SubMenu> BuscarSubMenu(Guid MenuId)
        {
            var data = _context.E_SubMenus.Where(a => a.MenuId == MenuId).OrderBy(a => a.Titulo).ToList();

            return data.Select(a => new GET_SubMenu
            {
                IdSubMenu = a.IdSubMenu,
                Titulo = a.Titulo,
                Icono = a.Icono,
                Link = a.Link,
            });
        }

    }
}
