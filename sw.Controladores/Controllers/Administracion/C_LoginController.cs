using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using sw.Datos;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using sw.Controladores.Model.Login;
using IdentityServer4.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using sw.Entidades.Identity;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRol> _roleManager;
        private readonly ILogger<C_LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;



        public C_LoginController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRol> roleManager,
            ILogger<C_LoginController> logger,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> Login(POST_Login model)
        {
            Console.WriteLine("Error asd");
            if (ModelState.IsValid)
            {
                var v_usuario = await _userManager.FindByNameAsync(model.Usuario);

                if (v_usuario == null)
                {

                    _logger.LogError($"El nombre de usuario: {model.Usuario} no existe por favor verifiquelo");
                    return BadRequest(new
                    {

                        error = $"El nombre de usuario: {model.Usuario} no existe por favor verifiquelo"

                    });
                }


                var login = await _signInManager.PasswordSignInAsync(model.Usuario, model.Password, true, true);



                if (login.Succeeded)
                {
                    _logger.LogInformation($"El Usuario {model.Usuario} se autentifico correcatamente");
                    var claims = await GetValidClaims(v_usuario);

                    return Ok(
                        new { token = GenerarToken(claims) }
                    );
                }
                if (login.IsLockedOut)
                {
                    _logger.LogError($"El Usuario {model.Usuario} fue bloqueado por exceder el numero de intentos espere 10 minutos e intentelo de nuevo");
                    return BadRequest(new
                    {

                        error = $"El Usuario {model.Usuario} fue bloqueado por exceder el numero de intentos espere 10 minutos e intentelo de nuevo"
                    });
                }
                if (login.IsNotAllowed)
                {
                    return BadRequest(new
                    {
                        error = $"El Usuario {model.Usuario} no esta autorizado"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        error = "Error en el inicio de sesión es posible que su contraseña sea incorrecta"
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
        private async Task<List<Claim>> GetValidClaims(ApplicationUser user)
        {
            //*******************************************************************//
            // SELECCIONAMOS EL CORPORATIVO, EMPREA Y CentroTrabajo A LA QUE PERTENESE
            //*******************************************************************//
            var ces = await _context.E_CentroTrabajos
                             .Where(a => a.IdCentroTrabajo == user.E_CentroTrabajoId)
                             .Include(a => a.E_Empresa)
                             .FirstOrDefaultAsync();

            var idCorporativo = "";
            var idEmpresa = "";
            var idCentroTrabajo = "";

            if (ces != null)
            {
                idCorporativo = ces.E_Empresa.E_CoorporativoId.ToString();
                idEmpresa = ces.E_EmpresaId.ToString();
                idCentroTrabajo = ces.IdCentroTrabajo.ToString();

            }

            //*******************************************************************//


            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Typ, user.Perfil),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
                new Claim("ID_Corporativo", idCorporativo),
                new Claim("ID_Empresa", idEmpresa),
                new Claim("ID_CentroTrabajo", idCentroTrabajo),



            };
            
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole); 
                
                claims.Add(new Claim(ClaimTypes.Role, role.Id));
            }         


            return claims;
        }
        private string GenerarToken(List<Claim> claims)
        {


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}