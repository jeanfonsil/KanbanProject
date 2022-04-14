using KanbanProjectFinal.Entities;
using System.ComponentModel.DataAnnotations;

namespace KanbanProjectFinal.Data.Dtos
{
    public class CreateCardDto
    {
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int UserId { get; set; }
        public double Estimate { get; set; }
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
