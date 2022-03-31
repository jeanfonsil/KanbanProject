using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanbanProjectFinal.Entities;

namespace KanbanProjectFinal.Data
{
    public class KanbanContext : DbContext
    {
        public KanbanContext(DbContextOptions<KanbanContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }


        public DbSet<User> Users { get; set; }
        //public DbSet<Card> Cards { get; set; }
        //public DbSet<Sprint> Sprints { get; set; }
    }
}
