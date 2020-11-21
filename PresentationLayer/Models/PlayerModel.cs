using System.Collections.Generic;
using DataLayer.Entities;

namespace PresentationLayer.Models
{
    public class PlayerViewModel
    {
        public Player Player { get; set; }
        public List<RecordViewModel> PlayerRecords { get; set; }
        public List<RecordEditModel> PlayerRecordEditModels { get; set; }
    }

    public class PlayerEditModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
    }
}
