using System;
using System.Collections.Generic;
using DataLayer.Entities;

namespace PresentationLayer.Models
{
    public class GameViewModel
    {
        public Game Game { get; set; }
        public List<RecordViewModel> GameRecords { get; set; }
    }

    public class GameEditModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPlayer { get; set; }
    }
}
