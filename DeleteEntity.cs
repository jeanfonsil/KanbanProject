using KanbanProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject
{
    public class DeleteEntity : IDeleteEntity
    {
        public void Delete(IDeleteEntity deleteEntity)
        {
            deleteEntity.Delete();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
