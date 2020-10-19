using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class EFPlayerRecordRepository : IPlayerRecordRepository
    {
        private MafiaDbContext context;
        public EFPlayerRecordRepository(MafiaDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<PlayerRecord> GetAllPlayerRecords()
        {
            return context.PlayerRecords.ToList();
        }

        public PlayerRecord GetPlayerRecordById(int playerRecordId)
        {
            return context.PlayerRecords.FirstOrDefault(x => x.Id == playerRecordId);
        }

        public void SavePlayerRecord(PlayerRecord playerRecord)
        {
            if (playerRecord.Id == 0)
                context.Add(playerRecord);
            else
                context.Entry(playerRecord).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePlayerRecord(PlayerRecord playerRecord)
        {
            context.PlayerRecords.Remove(playerRecord);
            context.SaveChanges();
        }
    }
}
