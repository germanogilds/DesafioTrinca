using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Domain.Services;
using Churrasco.Domain.Services.Interfaces;
using Churrasco.Infra.Repository;
using Churrasco.Infra.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Churrasco.WebApi
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
            //services.AddRazorPages();
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<EventoChurrascoContext>(options =>
            {
                options.UseSqlServer("server=DESENV-009\\SQLSERVER2014;Initial Catalog=EventoChurrasco;Integrated Security=True;", b => b.MigrationsAssembly("Churrasco.WebApi"));
            });

            //Repositories
            services.AddTransient<IEventoChurrascoRepository, EventoChurrascoRepository>();
            services.AddTransient<IParticipanteRepository, ParticipanteRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            
            //Services
            services.AddTransient<IEventoChurrascoService, EventoChurrascoService>();
            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
