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
        public DbSet<TipoQuartos> TipoQuarto { get; set; } = null!;
        public DbSet<Hospedes> Hospede { get; set; } = null!;
        public DbSet<Reservas> Reserva { get; set; } = null!;
        public DbSet<ReservasQuartos> ReservaQuarto { get; set; } = null!;
    }
}

