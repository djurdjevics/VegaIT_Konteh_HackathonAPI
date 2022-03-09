using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaIT_Konteh_Hackathon.Domain.Interfaces;
using VegaIT_Konteh_Hackathon.Domain.Services;
using VegaIT_Konteh_Hakaton.Repository;
using VegaIT_Konteh_HakatonAPI.Data;
using VegaIT_Konteh_HakatonAPI.Data.Context;

namespace VegaIT_Konteh_HackathonAPI
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

            services.AddDbContext<HackathonContext>(options =>
            {
                options
                .UseSqlServer(Configuration.GetConnectionString("HackathonConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VegaIT_Konteh_HackathonAPI", Version = "v1" });
            //});

            //Repositories
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IDeskRepository, DeskRepository>();

            //Services
            services.AddTransient<IFacultyService, FacultyService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IDeskService, DeskService>();

            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VegaIT_Konteh_HackathonAPI v1"));
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
