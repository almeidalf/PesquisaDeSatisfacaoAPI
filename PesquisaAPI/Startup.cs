using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PesquisaAPI.DB;
using PesquisaAPI.Repository;
using PesquisaAPI.Repository.Interfaces;

namespace PesquisaAPI
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
            services.AddDbContext<PesquisaSatisfacaoContext>(op =>
            {
                op.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IPesquisa, PesquisaRepository>();
            services.AddScoped<IRespostas, RespostasRepository>();
            services.AddScoped<ITiposRespostas, TiposRespostasRepository>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //Swagger
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Pesquisa de Satisfação",
                });
            });
            services.AddControllers();
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
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

        app.UseSwagger();
        app.UseSwaggerUI(cfg =>
        {
            cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "PesquisaSatisfacao");
        });
    }
}
}
