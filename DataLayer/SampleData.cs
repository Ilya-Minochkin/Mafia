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

                context.SaveChanges();

            

                context.Games.Add(new Game() {Date = new DateTime(2020, 1, 1), NumberOfPlayer = 2, Id = 100});

                context.SaveChanges();

                context.GameRecords.Add(new GameRecord() {Game = context.Games.First(), GameId = 100, Player = context.Players.First()});
                context.GameRecords.Add(new GameRecord() { Game = context.Games.First(), GameId = 100, Player = context.Players.Last()});

                context.SaveChanges();

                context.PlayerRecords.Add(new PlayerRecord()
                {
                    Date = context.Games.First().Date, Player = context.Players.First(), Result = 1,
                    Role = (int) RolesEnum.Role.Mafia,
                    PlayerId = context.Players.First().Id
                });

                context.PlayerRecords.Add(new PlayerRecord()
                {
                    Date = context.Games.First().Date,
                    Player = context.Players.Last(),
                    Result = 0,
                    Role = (int)RolesEnum.Role.Innocent,
                    PlayerId = context.Players.Last().Id
                });
            }
        }
    }
}
