﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataProvider.Sqlite.Extensions.Extensions
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
    }
}
