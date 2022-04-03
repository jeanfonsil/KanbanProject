using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanbanProject.Entities;

namespace KanbanProject
{
    public class KanbanContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KanbanDb;Trusted_Connection=true;");
            optionsBuilder.UseNpgsql("Host=tuffi.db.elephantsql.com;Port=5432;Database=rdgqpync;User Id=rdgqpync;Password=c26o8K3Tpdoz63gj1t1aMop0Ih9QNNxA;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
