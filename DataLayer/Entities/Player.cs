using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public List<Record> PlayerRecords { get; set; }

    }
}
