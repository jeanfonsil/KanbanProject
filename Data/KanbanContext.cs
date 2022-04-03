using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanbanProject.Entities;

namespace KanbanProject.Data
{
    public class KanbanContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KanbanDb;Trusted_Connection=true;");
            optionsBuilder.UseNpgsql("Host=Host;Port=5432;Database=Database;User Id=Id;Password=Password;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
