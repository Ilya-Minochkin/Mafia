using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class PlayerRecord
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public DateTime Date { get; set; }
        public int Role { get; set; }
        public int Result { get; set; }

    }
}
