using Microsoft.EntityFrameworkCore;
using ITS.Domain.Models;

namespace ITS.Core.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
    }
}
