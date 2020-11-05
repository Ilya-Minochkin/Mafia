using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IRecordRepository
    {
        public Record GetRecordById(int id);
        public void SaveRecord(Record record);
        public void DeleteRecord(Record record);
    }
}
