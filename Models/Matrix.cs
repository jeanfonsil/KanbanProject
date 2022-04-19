using System.Linq;
using System.Globalization;

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





        public static T[] GetPercentage<T>(T[,] matrix, int row, T Sum)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new T[rowLength];
            var rowVectorSum = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
            {
                rowVector[i] = matrix[row, i];
                rowVectorSum[i] = (T)(object)((dynamic)rowVector[i] / Sum);
            }
            return rowVectorSum;
        }
    }
}
