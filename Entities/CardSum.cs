using Microsoft.EntityFrameworkCore;

namespace KanbanProjectFinal.Entities
{
    [Keyless]
    public class CardSum
    {
        public int Status { get; set; }
        public double PercentTask { get; set; }
    }
}
