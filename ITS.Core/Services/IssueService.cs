using ITS.Core.Data;
using ITS.Domain.Models;
using ITS.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ITS.Core.Services
{
    public class IssueService : IIssueService
    {
        DatabaseContext db;
        public IssueService(DatabaseContext _db)
        {
            db = _db;
        }
        public async Task<bool> Add(Issue model)
        {
            db.Issues.Add(model);
            return await db.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            var record = db.Issues.AsNoTracking().FirstOrDefault(i => i.Id == id);
            if (record == null) 
            {
                return false;
            }
            db.Issues.Remove(record);
            var deleted = await db.SaveChangesAsync();
            return deleted != 0;
        }

        public async Task<Issue> Get(int id)
        {
            return await db.Issues.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            return await db.Issues.Include(i=>i.Equipment).Include(i=>i.Inspector).ToListAsync();
        }

        public async Task<bool> Update(Issue model)
        {
            db.Issues.Update(model);
            return await db.SaveChangesAsync() != 0;
        }
    }
}
