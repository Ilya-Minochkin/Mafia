using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
        public int? GameId { get; set; }
        public Game Game { get; set; }
        public RolesEnum.Role Role { get; set; }
        public int Result { get; set; }

    }
}
