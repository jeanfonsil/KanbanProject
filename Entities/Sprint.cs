using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
        //public void Save(IKanbanContext context)
        //{
        //    context.Save();
        //}
    }
}
