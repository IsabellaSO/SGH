using Microsoft.EntityFrameworkCore;
using SGH.Server.Models;

namespace SGH.Server.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        public DbSet<Quartos> Quartos { get; set; } = null!;
    }
}

