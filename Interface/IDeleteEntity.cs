using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject.Interface
{
    public interface IDeleteEntity
    {
        void Delete();
    }

    public class DeleteService : IDeleteEntity
    {
        public void Delete()
        {
            Console.Write("Which entity do you want to delete? (User - 0, Sprint - 1, Card - 2): ");
            int ChoiceDelete = int.Parse(Console.ReadLine());
            Console.Write("Please, put the Id of the entity you want to delete: ");
            int Id = int.Parse(Console.ReadLine());
            var db = new KanbanContext();
            switch (ChoiceDelete)
            {
                case 0:
                    db.Users.RemoveRange(db.Users.Where(users => users.Id == Id));
                    break;
                case 1:
                    db.Sprints.RemoveRange(db.Sprints.Where(sprints => sprints.Id == Id));
                    break;
                case 2:
                    db.Users.RemoveRange(db.Users.Where(cards => cards.Id == Id));
                    break;
            }
            db.SaveChanges();
            Console.WriteLine("Entity deleted");
        }
    }
}
