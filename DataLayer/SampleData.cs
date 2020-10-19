using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(MafiaDbContext context)
        {
            if (!EnumerableExtensions.Any(context.Players))
            {
                context.Players.Add(new Player() {Name = "Максим", NickName = "SexKamaz"});
                context.Players.Add(new Player() { Name = "Александр", NickName = "Sowajkee" });

                //context.SaveChanges();

            

                context.Games.Add(new Game() {Date = new DateTime(2020, 1, 1), NumberOfPlayer = 2});

                context.SaveChanges();

                context.GameRecords.Add(new GameRecord() { Game = context.Games.First(), Player = context.Players.First(), GameId = context.Games.First().Id });
                context.GameRecords.Add(new GameRecord() { Game = context.Games.First(), Player = context.Players.Find(2), GameId = context.Games.First().Id });

                //context.SaveChanges();

                context.PlayerRecords.Add(new PlayerRecord()
                {
                    Date = context.Games.First().Date, Player = context.Players.First(), 
                    Result = 1,
                    Role = RolesEnum.Role.Mafia,
                    PlayerId = context.Players.First().Id
                });

                context.PlayerRecords.Add(new PlayerRecord()
                {
                    Date = context.Games.First().Date,
                    Player = context.Players.Find(2),
                    Result = 0,
                    Role = RolesEnum.Role.Innocent,
                    PlayerId = 2
                });

                context.SaveChanges();

            }
        }
    }
}
