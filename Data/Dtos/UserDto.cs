using System.ComponentModel.DataAnnotations;

namespace KanbanProjectFinal.Data.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        //public ICollection<Card> Cards { get; set; }
    }
}
