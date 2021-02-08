using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PredmetnoPoslovanjeNetCore.Models;
using PredmetnoPoslovanjeNetCore.PredmetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.Extensions.DependencyInjection;

namespace PredmetnoPoslovanjeNetCore
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
            //AddTransient, AddScoped and AddSingleton Services Differences
            /*
            Transient objects are always different; a new instance is provided to every controller and every service.
            Scoped objects are the same within a request, but different across different requests.
            Singleton objects are the same for every object and every request.
            */
            services.AddControllers();

            services.AddDbContextPool<PredmetnoPoslovanjeContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("PredmetnoPoslovanjeContextConnectionString")));

            services.AddScoped<IPredmetData, SqlPredmetData>();
            services.AddScoped<IAktData, SqlAktData>();
            services.AddScoped<IRadnikData, SqlRadnikData>();

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
        }
    }
}
