using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace DataProvider.Sqlite.Extensions
{
    public class DesignTimePersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        /// <summary>
        /// This is method that use by EntityFramework migration
        /// </summary>
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            var connectionString = "Host=localhost;Database=postgres;Username=postgres;Password=123";
            var migrationsAssembly = typeof(DesignTimePersistedGrantDbContextFactory).GetTypeInfo().Assembly.GetName().Name;
            builder.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            return new PersistedGrantDbContext(builder.Options, new OperationalStoreOptions());
        }
    }
}
