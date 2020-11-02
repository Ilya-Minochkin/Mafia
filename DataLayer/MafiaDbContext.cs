using Microsoft.EntityFrameworkCore;
using System;
using DataLayer.Entities;

namespace DataLayer
{
    public class MafiaDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerRecord> PlayerRecords { get; set; }



        public MafiaDbContext (DbContextOptions options): base(options) { }
    }
}
