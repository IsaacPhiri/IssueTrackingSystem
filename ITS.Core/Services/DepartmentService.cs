using ITS.Core.Data;
using ITS.Domain.Models;
using ITS.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        DatabaseContext db;
        public DepartmentService(DatabaseContext _db)
        {
            db = _db;
        }
        public async Task<bool> Add(Department model)
        {
            db.Departments.Add(model);
            return  await db.SaveChangesAsync()!=0;
        }

        public async Task<bool> Delete(int id)
        {
            var record = db.Departments.AsNoTracking().FirstOrDefault(d => d.Id == id);
            if (record == null)
            {
                return false;
            }
            db.Departments.Remove(record);
            var deleted = await db.SaveChangesAsync();
            return deleted !=0;
        }

        public async Task<Department> Get(int id)
        {
            return await db.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<bool> Update(Department model)
        {
            db.Departments.Update(model);
            return await db.SaveChangesAsync() != 0;
        }
    }
}
