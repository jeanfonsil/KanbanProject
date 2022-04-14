using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KanbanProjectFinal.Entities
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]     
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}

