﻿using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oakauth.Migrations.Sqlite.Extensions;
using System.Reflection;

namespace DataProvider.Sqlite.Extensions
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        /// <summary>
        /// This is method that use by EntityFramework migration
        /// </summary>
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();
            var connectionString = "Data Source=App_Data\\IdentityServer-dev.db;";
            var migrationsAssembly = typeof(DbContextOptionsBuilderExtensions).GetTypeInfo().Assembly.GetName().Name;
            builder.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            return new ConfigurationDbContext(builder.Options, new ConfigurationStoreOptions());
        }
    }
}
