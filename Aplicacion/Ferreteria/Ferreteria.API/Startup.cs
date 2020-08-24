using Ferreteria.DAL;
using Ferreteria.Model.Autenticacion;
using Ferreteria.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Ferreteria.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            services.AgregarDependencias("Ferreteria.BLL");
            services.AddSingleton<IUnitOfWork>(option => new FerreteriaUnitOfWork(
                Configuration.GetConnectionString("DbContext")
                ));
            services.AddSwaggerGen();
            var tokenProvider = new JwtProvider("issuer", "audience", "ferreteria");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });
            services.AddAuthorization(auth => {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Enable CORS
            app.UseCors("CorsPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FereteriaApi");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    public static class Dependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection services, string nombreProyecto)
        {
            var assemblyRuta = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), nombreProyecto + ".dll");
            var assembly = Assembly.Load(AssemblyLoadContext.GetAssemblyName(assemblyRuta));

            var tiposClases = assembly.ExportedTypes.Select(t => IntrospectionExtensions.GetTypeInfo(t)).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var tipo in tiposClases)
            {
                var interfaces = tipo.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var tipoInterfaz in interfaces.Where(i => i.IsInterface))
                {
                    services.AddTransient(tipoInterfaz.AsType(), tipo.AsType());
                }
            }

            return services;
        }
    }
}
