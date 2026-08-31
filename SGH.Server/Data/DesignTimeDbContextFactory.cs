using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SGH.Server.Data;

public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        // Carrega o appsettings.json da pasta do projeto SGH.Server
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<HotelDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Caso use PostgreSQL:
        builder.UseNpgsql(connectionString);

        // Caso use SQL Server, substitua a linha acima por:
        // builder.UseSqlServer(connectionString);

        return new HotelDbContext(builder.Options);
    }
}
