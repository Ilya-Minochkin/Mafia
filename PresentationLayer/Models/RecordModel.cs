using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using DataLayer.Enums;

namespace PresentationLayer.Models
{
    public class RecordViewModel
    {
        public Record Record { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
    }

    public class RecordEditModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public RolesEnum.Role Role { get; set; }
        public int Result { get; set; }
    }
}
