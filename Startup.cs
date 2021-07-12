using IdentificadorApiCatalogoJogos.Controllers.ap;
using IdentificadorApiCatalogoJogos.Middleware;
using IdentificadorApiCatalogoJogos.Repositories;
using IdentificadorApiCatalogoJogos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace IdentificadorApiCatalogoJogos
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
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IJogoRepository, JogoRepository>();

            #region CicloDeVida

            services.AddSingleton<IIdentificadorSingleton, IdentificadorCicloDeVida>();
            services.AddScoped<IIdentificadorScoped, IdentificadorCicloDeVida>();
            services.AddTransient<IIdentificadorTransient, IdentificadorCicloDeVida>();

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ap", new OpenApiInfo { Title = "IdentificadorApiCatalogoJogos", Version = "v1" });

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                c.IncludeXmlComments(Path.Combine(basePath, fileName));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/ap/swagger.json", "ExemploApiCatalogoJogos v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
