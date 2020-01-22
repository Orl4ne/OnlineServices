using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacilityServices.BusinessLayer.UseCases;
using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;

namespace OnlineServices.WebUx.Mvc6
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
            services.AddControllersWithViews();

            // MustKnow Logging Step 1: Log configuration avec SERILOG
            services.AddLogging();

            ConfigureFacilitiesServices(services);

        }

        public void ConfigureFacilitiesServices(IServiceCollection services)
        {
            services.AddDbContext<FacilityContext>(optionsBuilder => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FacilityDB;Trusted_Connection=True;"));

            // Facility
            services.AddTransient<IComponentTypeRepository, ComponentTypeRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IIncidentRepository, IncidentRepository>();
            services.AddTransient<IFSUnitOfWork, FSUnitOfWork>();
            services.AddTransient<IFSAttendeeRole, FacilityServices.BusinessLayer.UseCases.AttendeeRole>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // MustKnow Logging Step 2: Add ILoggerFactory à la liste de parametres pour configure SERILOG
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "defaultAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
