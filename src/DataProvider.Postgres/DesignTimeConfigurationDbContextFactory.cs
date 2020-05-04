using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace DataProvider.Postgres.Extensions
{
    public class DesignTimeConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        /// <summary>
        /// This is method that use by EntityFramework migration
        /// </summary>
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();
            var connectionString = "Host=localhost;Database=postgres;Username=postgres;Password=123";
            var migrationsAssembly = typeof(DesignTimeConfigurationDbContextFactory).GetTypeInfo().Assembly.GetName().Name;
            builder.UseNpgsql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            return new ConfigurationDbContext(builder.Options, new ConfigurationStoreOptions());
        }
    }
}
