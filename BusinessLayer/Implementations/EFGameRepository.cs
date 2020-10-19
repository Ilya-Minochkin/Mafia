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
    public class EFGameRepository : IGameRepository

    {
        private MafiaDbContext context;
        public EFGameRepository(MafiaDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Game> GetAllGames()
        {
            return context.Games.ToList();
        }

        public Game GetGameById(int gameId)
        {
            return context.Games.FirstOrDefault(x => x.Id == gameId);
        }

        public void SaveGame(Game game)
        {
            if (game.Id == 0)
                context.Add(game);
            else
                context.Entry(game).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteGame(Game game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
        }
    }
}
