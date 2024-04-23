using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using sw.Datos;
using Microsoft.Extensions.Hosting;
using sw.Entidades.Identity;
using Microsoft.OpenApi.Models;


namespace sw.Controladores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(opciones => {
                opciones.AddDefaultPolicy(builder =>{
                    builder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
                });
            });
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Controladores", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Autorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var connectionString = Configuration.GetConnectionString("connectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRol>(options =>
                         {
                             options.Password.RequiredLength = 10;
                             options.Password.RequireUppercase = true;
                             options.Password.RequireLowercase = true;
                             options.Password.RequiredUniqueChars = 3;
                             options.Lockout.MaxFailedAccessAttempts = 3;
                             options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                         })
                       .AddEntityFrameworkStores<ApplicationDbContext>()
                       .AddDefaultTokenProviders();




            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   RequireExpirationTime = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });

            services.AddAuthorization(options =>
         {
             /* ADMINISTRACION */

             /* CONFIGURACION-CATALOGOS SAT */
             options.AddPolicy("Policy_FormaPago_Crear", policy => policy.RequireClaim("Forma de pago", new string[] { "Crear" }));
             options.AddPolicy("Policy_FormaPago_Actualizar", policy => policy.RequireClaim("Forma de pago", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_Impuestos_Crear", policy => policy.RequireClaim("Impuestos", new string[] { "Crear" }));
             options.AddPolicy("Policy_Impuestos_Actualizar", policy => policy.RequireClaim("Impuestos", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_Monedas_Crear", policy => policy.RequireClaim("Monedas", new string[] { "Crear" }));
             options.AddPolicy("Policy_Monedas_Actualizar", policy => policy.RequireClaim("Monedas", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_ProductosServicios_Crear", policy => policy.RequireClaim("Productos y servicios", new string[] { "Crear" }));
             options.AddPolicy("Policy_ProductosServicios_Actualizar", policy => policy.RequireClaim("Productos y servicios", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_RegimenFiscal_Crear", policy => policy.RequireClaim("Regimen fiscal", new string[] { "Crear" }));
             options.AddPolicy("Policy_RegimenFiscal_Actualizar", policy => policy.RequireClaim("Regimen fiscal", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_TipoComprobante_Crear", policy => policy.RequireClaim("Tipo de comprobante", new string[] { "Crear" }));
             options.AddPolicy("Policy_TipoComprobante_Actualizar", policy => policy.RequireClaim("Tipo de comprobante", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_TipoRecibo_Crear", policy => policy.RequireClaim("Tipo de recibo", new string[] { "Crear" }));
             options.AddPolicy("Policy_TipoRecibo_Actualizar", policy => policy.RequireClaim("Tipo de recibo", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_UnidadMedida_Crear", policy => policy.RequireClaim("Unidad de medida", new string[] { "Crear" }));
             options.AddPolicy("Policy_UnidadMedida_Actualizar", policy => policy.RequireClaim("Unidad de medida", new string[] { "Actualizar" }));
             options.AddPolicy("Policy_UsoCFDI_Crear", policy => policy.RequireClaim("Uso de CFDI", new string[] { "Crear" }));
             options.AddPolicy("Policy_UsoCFDI_Actualizar", policy => policy.RequireClaim("Uso de CFDI", new string[] { "Actualizar" }));

         });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHsts();
            }

            // allow credentials

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}