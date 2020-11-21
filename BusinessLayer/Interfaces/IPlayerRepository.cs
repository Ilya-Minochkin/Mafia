using DataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int? playerId);
        void SavePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
