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
        private readonly MafiaDbContext _context;
        public EFGameRepository(MafiaDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public Game GetGameById(int gameId)
        {
            return _context.Games
                .Include(x => x.GameRecords)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == gameId);
        }

        public void SaveGame(Game game)
        {
            if (game.Id == 0)
                _context.Add(game);
            else
                _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGame(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }
    }
}
