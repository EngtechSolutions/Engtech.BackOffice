using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Engtech.BackOffice.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BackOfficeDbContextFactory : IDesignTimeDbContextFactory<BackOfficeDbContext>
{
    public BackOfficeDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        BackOfficeEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<BackOfficeDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new BackOfficeDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Engtech.BackOffice.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
