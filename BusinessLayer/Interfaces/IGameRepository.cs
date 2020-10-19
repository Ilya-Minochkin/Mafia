using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int gameId);
        void SaveGame(Game game);
        void DeleteGame(Game game);
    }
}
