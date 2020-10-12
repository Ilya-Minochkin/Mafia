using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class GameRecord
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }


    }
}
