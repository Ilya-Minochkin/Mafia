using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MafiaDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Record> Records { get; set; }

        public MafiaDbContext (DbContextOptions options): base(options) { }
    }
}
