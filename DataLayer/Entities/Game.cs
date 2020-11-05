using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPlayer { get; set; }
        public List<Record> GameRecords { get; set; }

    }
}
