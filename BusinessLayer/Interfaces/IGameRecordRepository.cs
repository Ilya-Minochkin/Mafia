using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IGameRecordRepository
    {
        IEnumerable<GameRecord> GetAllGameRecords();
        GameRecord GetGameRecordById(int gameRecordId);
        void SaveGameRecord(GameRecord gameRecord);
        void DeleteGameRecord(GameRecord gameRecord);
    }
}
