using DataLayer;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models.DatabaseCommunication;
using Services;
using Services.Interfaces;
using SignalR;

namespace Server
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

            services.AddControllers();
            services.AddSignalR();

            // Services
            services.AddScoped<IFizickaKnjigaService, FizickaKnjigaService>();
            services.AddScoped<IKnjigaService, KnjigaService>();
            services.AddScoped<IFilterService, FilterService>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IRadnikService, RadnikService>();
            services.AddScoped<IPrijavaService, PrijavaService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<IRasporedService, RasporedService>();
            services.AddScoped<ICitaonicaService, CitaonicaService>();
            services.AddScoped<ICitanjeService, CitanjeService>();
            services.AddScoped<IMestoService, MestoService>();
            services.AddScoped<IOgranakBibliotekeService, OgranakBibliotekeService>();
            services.AddScoped<IIzdavacService, IzdavacService>();
            services.AddScoped<IIznajmljivanjeService, IznajmljivanjeService>();
            services.AddScoped<ICekanjeService, CekanjeService>();
            services.AddScoped<IVestService, VestService>();
            services.AddScoped<IKomentarService, KomentarService>();
            services.AddScoped<IAzuriranjeService, AzuriranjeService>();
            services.AddScoped<ISlikaService, SlikaService>();
            services.AddScoped<IStatistikaService, StatistikaService>();

            // Dao
            services.AddScoped<IAutorDao, AutorDao>();
            services.AddScoped<ICitanjeDao, CitanjeDao>();
            services.AddScoped<ICitaonicaDao, CitaonicaDao>();
            services.AddScoped<IFilterDao, FilterDao>();
            services.AddScoped<IFizickaKnjigaDao, FizickaKnjigaDao>();
            services.AddScoped<IIzdavacDao, IzdavacDao>();
            services.AddScoped<IIznajmljivanjeDao, IznajmljivanjeDao>();
            services.AddScoped<IKnjigaDao, KnjigaDao>();
            services.AddScoped<IKorisnikDao, KorisnikDao>();
            services.AddScoped<IMestoDao, MestoDao>();
            services.AddScoped<IOgranakBibliotekeDao, OgranakBibliotekeDao>();
            services.AddScoped<IPrijavaDao, PrijavaDao>();
            services.AddScoped<IRadnikDao, RadnikDao>();
            services.AddScoped<IRasporedDao, RasporedDao>();
            services.AddScoped<ISlikaDao, SlikaDao>();
            services.AddScoped<IFilterDao, FilterDao>();
            services.AddScoped<ICekanjeDao, CekanjeDao>();
            services.AddScoped<IVestDao, VestDao>();
            services.AddScoped<IKomentarDao, KomentarDao>();

            services.AddDbContext<Context>(options =>
            {
               options.UseSqlServer(Configuration.GetConnectionString("CSProjekat")); 
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true)
                        .AllowCredentials();
                        // .WithOrigins
                        // (
                        //     "http://localhost:3000", 
                        //     "https://localhost:3000",
                        //     "http://127.0.0.1:3000",
                        //     "https://127.0.0.1:3000",
                        //     "http://localhost:3001",
                        //     "https://localhost:3001",
                        //     "http://127.0.0.1:3001",
                        //     "https://127.0.0.1:3001"
                        // );
            }));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseCors(app =>
            // {
            //     app
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader()
            //     .AllowCredentials();
            // });
            app.UseCors("CorsPolicy");

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<KomentarHub>("/komentarHub");
            });
        }
    }
}
