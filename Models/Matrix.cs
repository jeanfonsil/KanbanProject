using System.Linq;

namespace KanbanProjectFinal.Models
{
    public class Matrix
    { 
        public static T[] GetRow<T>(T[,] matrix, int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
            {
                rowVector[i] = matrix[row, i];
            }
            return rowVector;
        }        
    }
}
