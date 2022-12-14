using MicroServiciosV1.Busquedas.Interfaces;
using MicroServiciosV1.Busquedas.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiciosV1.Busquedas
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IClientesService, ClientesService>();
            services.AddSingleton<IProductosService, ProductosService>();
            services.AddSingleton<IVentasService, VentasService>();

            services.AddHttpClient("clientesService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Clientes"]);
            });

            services.AddHttpClient("productosService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Productos"]);
            });

            services.AddHttpClient("ventasService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Ventas"]);
            });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
