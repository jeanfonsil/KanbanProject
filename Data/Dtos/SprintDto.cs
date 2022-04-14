using KanbanProjectFinal.Entities;
using System.ComponentModel.DataAnnotations;

namespace KanbanProjectFinal.Data.Dtos
{
    public class SprintDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public virtual List<Card> Cards { get; set; }
    }
}
