using KanbanProjectFinal.Entities;
using System.ComponentModel.DataAnnotations;

namespace KanbanProjectFinal.Data.Dtos
{
    public class ReadCardDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public double Estimate { get; set; }
        public Sprint Sprint { get; set; }
        public Status Status { get; set; }
    }
}
