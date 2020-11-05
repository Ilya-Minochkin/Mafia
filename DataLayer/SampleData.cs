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
                context.Players.Add(new Player() {Name = "Александр", NickName = "Sowajkee"});




                context.Games.Add(new Game() {Date = new DateTime(2020, 1, 1), NumberOfPlayer = 2});

                context.SaveChanges();

                context.Records.Add(new Record()
                {
                    Game = context.Games.First(), 
                    Player = context.Players.First(), 
                    GameId = context.Games.First().Id,
                    PlayerId = context.Players.First().Id, 
                    Result = 1, 
                    Role = RolesEnum.Role.Mafia
                });
                context.Records.Add(new Record()
                {
                    Game = context.Games.First(), 
                    Player = context.Players.Find(2), 
                    GameId = context.Games.First().Id,
                    PlayerId = context.Players.First().Id,
                    Result = 0,
                    Role = RolesEnum.Role.Innocent
                });



                context.SaveChanges();
            }
        }
    }
}
