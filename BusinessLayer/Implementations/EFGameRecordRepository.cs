using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;

namespace BusinessLayer.Implementations
{
    public class EFGameRecordRepository : IGameRecordRepository
    {
        private MafiaDbContext context;

        public EFGameRecordRepository(MafiaDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GameRecord> GetAllGameRecords()
        {
            return context.GameRecords.ToList();
        }

        public GameRecord GetGameRecordById(int gameRecordId)
        {
            return context.GameRecords.FirstOrDefault(x => x.Id == gameRecordId);
        }


        public void SaveGameRecord(GameRecord gameRecord)
        {
            if (gameRecord.Id == 0)
                context.GameRecords.Add(gameRecord);
            else
                context.Entry(gameRecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteGameRecord(GameRecord gameRecord)
        {
            context.GameRecords.Remove(gameRecord);
            context.SaveChanges();
        }
    }
}
