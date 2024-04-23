using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using sw.Datos;
using sw.Controladores.Model.Administracion.Empresa;
using sw.Entidades.Administracion.Empresa; 
namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext  _context;
        private readonly IWebHostEnvironment  _environment;

        public C_EmpresaController(ApplicationDbContext context,   IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        // GET: api/C_Empresa/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Empresa>> Listar()
        {
            var Empresa = await _context.E_Empresas
            .Include(a => a.E_Coorporativo)
            .OrderBy(a => a.Nombre)
            .ToListAsync();

            

            return Empresa.Select(a => new GET_Empresa
            {
                  IdEmpresa=a.IdEmpresa,
                  E_CoorporativoId= a.E_CoorporativoId,
                  E_RegimenFiscalId=a.E_RegimenFiscalId,
                  Nombre =a.Nombre ,
                  RFC =a.RFC,
                  RazonSocial = a.RazonSocial,
                  Calle =a.Calle,
                  NoExterior =a.NoExterior,
                  NoInterior =a.NoInterior,
                  Colonia =a.Colonia,
                  CP =a.CP,
                  Municipio = a.Municipio, 
                  Estado =a.Estado,
                  Pais =a.Pais,
                  RutaDirectorio =a.RutaDirectorio, 
                  RutaDirectorioVirtual =a.RutaDirectorioVirtual,
                  RutaArchivoCER =a.RutaArchivoCER,
                  RutaArchivoKey =a.RutaArchivoKey,
                  CveKey =a.CveKey,
                  RutaLogo =a.RutaLogo,
                  ContadorTimbre =a.ContadorTimbre, 
                  GuidCorporativo = a.E_Coorporativo.Guid,
                  Guid = a.Guid,
                  Nombrecoorporativo = a.E_Coorporativo.Nombre,
                
            });

        }


        // PUT: api/C_Empresa/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Empresa model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Empresa = await _context.E_Empresas.FirstOrDefaultAsync(a => a.IdEmpresa == model.IdEmpresa);

            if (Empresa == null)
            {
                return BadRequest(new
                {
                    error = "La empresa no existe"
                });
            }
                Empresa.IdEmpresa = model.IdEmpresa;
                Empresa.E_CoorporativoId = model.E_CoorporativoId;
                Empresa.E_RegimenFiscalId = model.E_RegimenFiscalId;
                Empresa.Nombre = model.Nombre;
                Empresa.RFC = model.RFC;
                Empresa.RazonSocial = model.RazonSocial;
                Empresa.Calle = model.Calle;
                Empresa.NoExterior = model.NoExterior;
                Empresa.NoInterior = model.NoInterior;
                Empresa.Colonia = model.Colonia;
                Empresa.CP = model.CP;
                Empresa.Municipio = model.Municipio;
                Empresa.Estado = model.Estado;
                Empresa.Pais = model.Pais;
                Empresa.RutaDirectorio = model.RutaDirectorio;
                Empresa.RutaDirectorioVirtual = model.RutaDirectorioVirtual;
                Empresa.RutaArchivoCER = model.RutaArchivoCER;
                Empresa.RutaArchivoKey = model.RutaArchivoKey;
                Empresa.CveKey = model.CveKey;
                Empresa.RutaLogo = model.RutaLogo;
                Empresa.ContadorTimbre = model.ContadorTimbre;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            { 
                return BadRequest(new
                {
                    error = "No fue posible actualizar los datos"
                });
            }

            return Ok(new 
            {
                result = "Los datos se actualizaron correctamente"
            });
        }


        // POST: api/C_Empresa/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Empresa model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            E_Empresa Empresa = new E_Empresa
            {
                E_CoorporativoId = model.E_CoorporativoId,
                E_RegimenFiscalId = model.E_RegimenFiscalId,
                Nombre = model.Nombre,
                RFC = model.RFC,
                RazonSocial = model.RazonSocial,
                Calle = model.Calle,
                NoExterior = model.NoExterior,
                NoInterior = model.NoInterior,
                Colonia = model.Colonia,
                CP = model.CP,
                Municipio = model.Municipio,
                Estado = model.Estado,
                Pais = model.Pais,
                RutaDirectorio = model.RutaDirectorio,
                RutaDirectorioVirtual = model.RutaDirectorioVirtual,
                RutaArchivoCER = model.RutaArchivoCER,
                RutaArchivoKey = model.RutaArchivoKey,
                CveKey = model.CveKey,
                RutaLogo = model.RutaLogo,
                ContadorTimbre = model.ContadorTimbre,
                Guid = model.Guid,

            };

            _context.E_Empresas.Add(Empresa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "No fue posible crear la empresa"
                });
            }

            return Ok(new
            {
                result = "La empresa se creo correctamente"
            });
        }


         

        // GET: api/Empresa/ListarporIdCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Empresa>> ListarporIdCorporativo([FromRoute]int IdCorporativo)
        {
            var Empresa = await _context.E_Empresas
             .Where(a => a.E_CoorporativoId == IdCorporativo)
            .Include(a => a.E_Coorporativo)
            .OrderBy(a => a.Nombre)
            .ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return Empresa.Select(a => new GET_Empresa
            {
                IdEmpresa = a.IdEmpresa,
                E_CoorporativoId = a.E_CoorporativoId,
                E_RegimenFiscalId = a.E_RegimenFiscalId,
                Nombre = a.Nombre,
                RFC = a.RFC,
                RazonSocial = a.RazonSocial,
                Calle = a.Calle,
                NoExterior = a.NoExterior,
                NoInterior = a.NoInterior,
                Colonia = a.Colonia,
                CP = a.CP,
                Municipio = a.Municipio,
                Estado = a.Estado,
                Pais = a.Pais,
                RutaDirectorio = a.RutaDirectorio,
                RutaDirectorioVirtual = a.RutaDirectorioVirtual,
                RutaArchivoCER = a.RutaArchivoCER,
                RutaArchivoKey = a.RutaArchivoKey,
                CveKey = a.CveKey,
                RutaLogo = a.RutaLogo,
                ContadorTimbre = a.ContadorTimbre,
                Numeracion = conteo(),
                GuidCorporativo = a.E_Coorporativo.Guid,
                Guid = a.Guid,
                Nombrecoorporativo = a.E_Coorporativo.Nombre,

            });

        }

        // GET: api/Empresa/InformacionEmpresa
        [HttpGet("[action]/{IdEmpresa}")]
        public async Task<IActionResult> InformacionEmpresa([FromRoute] int IdEmpresa)
        {
            var empresa = await _context.E_Empresas
                .Where(a => a.IdEmpresa == IdEmpresa)
                .FirstOrDefaultAsync();


            return Ok(new { Razonsocial = empresa.RazonSocial , rfc = empresa.RFC, Direccion= empresa.Colonia.ToUpper() +" "+ (empresa.NoExterior != "" ? empresa.NoExterior : "S/N") + " " + (empresa.NoInterior != " " ? empresa.NoInterior : "S/N")  + " " + empresa.Calle.ToUpper() + " " + empresa.CP + " " + empresa.Municipio.ToUpper() + " " + empresa.Estado.ToUpper() + " " + empresa.Pais.ToUpper() });

        }


        //[HttpPost("Post/{nombre}" )]
        [HttpPost("[action]/{nombreCarpetaEmpresa}/{nombreArchivo}/{nombreCarpetaCoorporativo}")]
        public async Task<IActionResult> Post(IFormFile file, [FromRoute] string nombreCarpetaEmpresa, string nombreArchivo, string nombreCarpetaCoorporativo)
        {
            try
            {

                //***********************************************************************************
                string patchp = Path.Combine(_environment.ContentRootPath, "Directorio_clientes\\" + nombreCarpetaCoorporativo);

                if (!Directory.Exists(patchp))
                    Directory.CreateDirectory(patchp);

                string patchp2 = Path.Combine(_environment.ContentRootPath, "Directorio_clientes\\" + nombreCarpetaCoorporativo + "\\" + nombreCarpetaEmpresa);

                if (!Directory.Exists(patchp2))
                    Directory.CreateDirectory(patchp2);

                string extension;

                extension = Path.GetExtension(file.FileName);


                var filePath = Path.Combine(_environment.ContentRootPath, "Directorio_clientes\\" + nombreCarpetaCoorporativo + "\\" + nombreCarpetaEmpresa, nombreArchivo + extension);
                var path = ("https://" + HttpContext.Request.Host.Value + "/Directorio_clientes/" + nombreCarpetaCoorporativo + "/" + nombreCarpetaEmpresa + "/" + nombreArchivo + extension);
                if (file.Length > 0)
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        await file.CopyToAsync(stream);


                return Ok(new { count = 1, ruta = path });


            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear  el directorio principal"
                });
            }
        }

        //[HttpPost("Post2/{nombre}" )]
        [HttpPost("[action]/{nombreCarpetaEmpresa}/{nombreArchivo}/{nombreCarpetaCoorporativo}")]
        public async Task<IActionResult> Post2(IFormFile file, [FromRoute] string nombreCarpetaEmpresa, string nombreArchivo, string nombreCarpetaCoorporativo)
        {
            try
            {

                //***********************************************************************************
                string patchp = Path.Combine(_environment.ContentRootPath, "Directorio_clientes\\" + nombreCarpetaCoorporativo);

                if (!Directory.Exists(patchp))
                    Directory.CreateDirectory(patchp);

                string patchp2 = Path.Combine(_environment.ContentRootPath, "Directorio_clientes\\" + nombreCarpetaCoorporativo + "\\" + nombreCarpetaEmpresa);

                if (!Directory.Exists(patchp2))
                    Directory.CreateDirectory(patchp2);

                string extension;

                extension = Path.GetExtension(file.FileName);


                var filePath = Path.Combine(_environment.ContentRootPath, "Directorio_clientes\\" + nombreCarpetaCoorporativo + "\\" + nombreCarpetaEmpresa, nombreArchivo );
                var path = ("https://" + HttpContext.Request.Host.Value + "/Directorio_clientes/" + nombreCarpetaCoorporativo + "/" + nombreCarpetaEmpresa + "/" + nombreArchivo );
                if (file.Length > 0)
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        await file.CopyToAsync(stream);


                return Ok(new { count = 1, ruta = path });


            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear  subir el archivo"
                });
            }
        }



    }
}
