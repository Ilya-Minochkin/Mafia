using DataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int? gameId);
        void SaveGame(Game game);
        void DeleteGame(Game game);
    }
}
