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
        private MafiaDbContext context;

        public EFPlayerRepository(MafiaDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Player> GetAllPlayers()
        {
            return context.Players.ToList();
        }

        public Player GetPlayerById(int playerId)
        {
            return context.Players.FirstOrDefault(x => x.Id == playerId);
        }

        public void SavePlayer(Player player)
        {
            if (player.Id == 0)
                context.Add(player);
            else
                context.Entry(player).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePlayer(Player player)
        {
            context.Players.Remove(player);
            context.SaveChanges();
        }
    }
}
