using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
        //public static List<Sprint> All()
        //{
        //    var db = new KanbanContext();
        //    return db.Sprints.ToList();
        //}

        public void Save()
        {
            var db = KanbanContext.GetInstance();
            db.Sprints.Add(this);
            db.SaveChanges();
        }
    }
}
