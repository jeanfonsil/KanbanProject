using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KanbanProjectFinal.Entities
{
    public class Card
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }        
        public double Estimate { get; set; }
        public virtual Sprint Sprint { get; set; }
        public int SprintId { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Requested,
        In_Progress,
        Done,
    }
    
}
