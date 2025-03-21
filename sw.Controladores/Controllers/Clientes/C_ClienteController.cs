using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sw.Controladores.Model.Clientes;
using sw.Controladores.Model.Configuracion.Gastos;
using sw.Datos;
using sw.Entidades.Clientes.Cliente;
using sw.Entidades.Configuracion.Gastos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;




namespace sw.Controladores.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public C_ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/C_Cliente/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Cliente>> Listar()
        {
            var data = await _context.E_Clientes.ToListAsync();


            return data.Select(a => new GET_Cliente
            {
                IdCliente = a.IdCliente,
                Nombre = a.Nombre,
                //RazonSocial = a.RazonSocial,
                //RFC = a.RFC,

            });

        }


        // POST: api/C_Cliente/Crear
        //[Authorize(Policy = "Policy_Cliente_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }


            var ExistDesc = await _context.E_Clientes.FirstOrDefaultAsync(a => a.Nombre == model.Nombre && a.E_CoorporativoId==model.E_CoorporativoId);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un cliente con este nombre: {model.Nombre}"
                });
            }


            E_Clientes cliente = new E_Clientes
            {
                Nombre = model.Nombre,
                E_CoorporativoId = model.E_CoorporativoId,
                //RazonSocial=model.RazonSocial,
                //RFC = model.RFC,
                //Calle=model.Calle,
                //Num_Ext=model.Num_Ext,
                //Num_Int=model.Num_Int,
                //Colonia=model.Colonia,
                //CP = model.CP,
                //Municipio=model.Municipio,
                //Estado=model.Estado,
                //Pais=model.Pais,
                //TelFijo=model.TelFijo,
                //TelMovil=model.TelMovil,
                Email=model.Email,
                Default=model.Default,
                Descuento=model.Descuento,
                Dcto_Individual=model.Dcto_Individual,
                Precio_Individual=model.Precio_Individual,
                Precio_Asignado=model.Precio_Asignado,
            };

            _context.E_Clientes.Add(cliente);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El cliente: {model.Nombre} se registro correctamente"
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


        // PUT: api/C_Cliente/Actualizar
        //[Authorize(Policy = "Policy_Cliente_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }



            var Data = await _context.E_Clientes.FirstOrDefaultAsync(a => a.IdCliente == model.IdCliente);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdCliente = model.IdCliente;
            Data.E_CoorporativoId = model.E_CoorporativoId;
            Data.Nombre = model.Nombre;
            //Data.RazonSocial = model.RazonSocial;
            //Data.RFC = model.RFC;
            //Data.Calle = model.Calle;
            //Data.Num_Ext = model.Num_Ext;
            //Data.Num_Int = model.Num_Int;
            //Data.Colonia = model.Colonia;
            //Data.CP = model.CP;
            //Data.Municipio = model.Municipio;
            //Data.Estado = model.Estado;
            //Data.Pais = model.Pais;
            //Data.TelFijo = model.TelFijo;
            //Data.TelMovil = model.TelMovil;
            Data.Email = model.Email;
            Data.Default = model.Default;
            Data.Descuento = model.Descuento;
            Data.Dcto_Individual = model.Dcto_Individual;
            Data.Precio_Individual = model.Precio_Individual;
            Data.Precio_Asignado = model.Precio_Asignado;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El cliente: {model.Nombre} se actualizo correctamente"
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

        // GET: api/C_Cliente/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Cliente>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var Cliente = await _context.E_Clientes
            .OrderBy(a => a.Nombre)
            .Where(a => a.E_CoorporativoId == IdCorporativo)
            .ToListAsync();



            return Cliente.Select(a => new GET_Cliente
            {
                IdCliente = a.IdCliente,
                E_CoorporativoId = a.E_CoorporativoId,
                Nombre = a.Nombre,
                //RazonSocial = a.RazonSocial,
                //RFC = a.RFC,
                Default = a.Default,
            });

        }

    }
}
