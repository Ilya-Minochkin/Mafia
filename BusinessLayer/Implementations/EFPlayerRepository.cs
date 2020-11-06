using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class EFPlayerRepository : IPlayerRepository
    {
        private readonly MafiaDbContext _context;

        public EFPlayerRepository(MafiaDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayerById(int playerId)
        {
            return _context.Players
                .Include(x => x.PlayerRecords)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == playerId);
        }

        public void SavePlayer(Player player)
        {
            if (player.Id == 0)
                _context.Add(player);
            else
                _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}
