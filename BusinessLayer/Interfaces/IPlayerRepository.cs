using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int playerId);
        void SavePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
