using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OS.AttendanceServices.BusinessLayer.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OS.Common.AttendanceServices.Interfaces;
using OS.Common.AttendanceServices;
using OS.Common.RegistrationServices;
using OS.WebAPI.Services.Mocks;
using OS.RegistrationServices.DataLayer;
using OS.WebAPI.Services.Features.Authentication;
using OS.WebAPI.Services.Features.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace OS.WebAPI.Services
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
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            })
                .AddXmlDataContractSerializerFormatters()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            })
                .AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyEmployees, policy => policy.Requirements.Add(new OnlyEmployeesRequirement()));
                options.AddPolicy(Policies.OnlyManagers, policy => policy.Requirements.Add(new OnlyManagersRequirement()));
                options.AddPolicy(Policies.OnlyThirdParties, policy => policy.Requirements.Add(new OnlyThirdPartiesRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, OnlyEmployeesAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyManagersAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyThirdPartiesAuthorizationHandler>();


            RegistrationServicesDependencyInjections(services);
            AttendanceServicesDependencyInjections(services);
        }

        private static void RegistrationServicesDependencyInjections(IServiceCollection services)
        {
            services.AddDbContext<RegistrationContext>(optionsBuilder =>
                optionsBuilder
                    //.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RegistrationDB;Trusted_Connection=True;")
                    .UseInMemoryDatabase(databaseName: "RegistrationDB")
            );

            //Mocks to implement...
            services.AddTransient<IRSAssistantRole>(x => RegistrationServicesMockHelper.RSAssistantRoleObject());
            services.AddTransient<IRSAttendeeRole>(x => RegistrationServicesMockHelper.RSAttendeeRoleObject());

            //Implementations
            //...
        }

        private static void AttendanceServicesDependencyInjections(IServiceCollection services)
        {
            //Mocks to implement...
            services.AddTransient<ICheckInRepository>(x => AttendenceServicesMockHelper.CheckInRepositoryObject());

            //Implementations
            //services.AddTransient<IASUnitOfWork, ASUnitOfWork>();
            services.AddTransient<IASAttendeeRole, ASAttendeeRole>();
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
                //app.UseExceptionHandler(appBuilder =>
                //{
                //    appBuilder.Run(async context =>
                //    {
                //        context.Response.StatusCode = 500;
                //        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                //    });
                //});
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
