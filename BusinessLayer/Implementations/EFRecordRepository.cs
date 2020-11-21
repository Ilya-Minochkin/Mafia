using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLayer.Implementations
{
    public class EFRecordRepository : IRecordRepository
    {
        private readonly MafiaDbContext _context;

        public EFRecordRepository(MafiaDbContext context)
        {
            _context = context;
        }
        public Record GetRecordById(int id)
        {
            return _context.Records
                .Include(x => x.Game)
                .Include(x => x.Player)
                .FirstOrDefault(x => x.Id == id);
        }

        public void SaveRecord(Record record)
        {
            if (record.Id == 0)
                _context.Add(record);
            else
                _context.Entry(record).State = EntityState.Modified; 
            _context.SaveChanges();
        }

        public void DeleteRecord(Record record)
        {
            _context.Records.Remove(record);
            _context.SaveChanges();
        }

    }
}
