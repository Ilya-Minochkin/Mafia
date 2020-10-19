using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IPlayerRecordRepository
    {
        IEnumerable<PlayerRecord> GetAllPlayerRecords();
        PlayerRecord GetPlayerRecordById(int playerRecordId);
        void SavePlayerRecord(PlayerRecord playerRecord);
        void DeletePlayerRecord(PlayerRecord playerRecord);
    }
}
