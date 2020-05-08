using System;
using Applications.Interfaces;
using Applications.Sqlite;
using AutoMapper;
using DataProvider.Sqlite.Extensions.Extensions;
using DataProvider.Postgres.Extensions.Extensions;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Web.Demo;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IApplicationsService, ApplicatonsService>();

            AddIdentityServer(services);

            services.AddControllersWithViews();
            // In production
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to 
                // change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseIdentityServer();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }

        private void AddIdentityServer(IServiceCollection services)
        {
            IIdentityServerBuilder builder = null;
            var sqliteConnectionString = GetSqliteConnectionString();
            if (!string.IsNullOrEmpty(sqliteConnectionString))
            {
                builder = services.UseSqlite(sqliteConnectionString);
                AddCredential(builder);
            }
            var postgresConnectionString = GetPostgresConnectionString();
            if (!string.IsNullOrEmpty(postgresConnectionString))
            {
                builder = services.UseNpgsql(postgresConnectionString);
            }

            if (builder == null) throw new Exception("Can not find any connection string!");

            AddCredential(builder);
        }

        private void AddCredential(IIdentityServerBuilder builder)
        {
            var certPassword = Configuration.GetValue<string>("cert:password");
            if (string.IsNullOrEmpty(certPassword))
            {
                certPassword = Environment.GetEnvironmentVariable("APPSETTING_certPassword");
            }
            var certFile = Configuration.GetValue<string>("cert:file");
            if (string.IsNullOrEmpty(certFile))
            {
                certFile = Environment.GetEnvironmentVariable("APPSETTING_certFile");
            }

            var cert = new X509Certificate2(
                Path.Combine(Directory.GetCurrentDirectory(), certFile)
                , certPassword);
            builder.AddSigningCredential(cert);

            //builder.AddDeveloperSigningCredential();
        }

        private string GetPostgresConnectionString()
        {
            var postgres = Configuration.GetConnectionString("Postgres");
            if (!string.IsNullOrEmpty(postgres))
            {
                return postgres;
            }

            return Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_Postgres");
        }

        private string GetSqliteConnectionString()
        {
            return Configuration.GetConnectionString("Sqlite");
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // migrate PersistedGrantDbContext
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                // migrate ConfigurationDbContext
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                // insert seed data
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.GetResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.Apis)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
