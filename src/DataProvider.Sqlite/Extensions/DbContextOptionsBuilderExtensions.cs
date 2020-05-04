using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Oakauth.Migrations.Sqlite.Extensions
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static IIdentityServerBuilder UseSqlite(this IServiceCollection services, string connectionString)
        {
            var migrationsAssembly = typeof(DbContextOptionsBuilderExtensions).GetTypeInfo().Assembly.GetName().Name;
            return services.AddIdentityServer()
                //.AddTestUsers(TestUsers.Users)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
                });
        }

        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {

                // migrate PersistedGrantDbContext
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                // migrate ConfigurationDbContext
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                // insert seed data
                //if (!context.Clients.Any())
                //{
                //    foreach (var client in Config.Clients)
                //    {
                //        context.Clients.Add(client.ToEntity());
                //    }
                //    context.SaveChanges();
                //}

                //if (!context.IdentityResources.Any())
                //{
                //    foreach (var resource in Config.GetResources())
                //    {
                //        context.IdentityResources.Add(resource.ToEntity());
                //    }
                //    context.SaveChanges();
                //}

                //if (!context.ApiResources.Any())
                //{
                //    foreach (var resource in Config.Apis)
                //    {
                //        context.ApiResources.Add(resource.ToEntity());
                //    }
                //    context.SaveChanges();
                //}
            }
        }
    }
}
