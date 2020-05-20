using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class MatrixOperation
    {
        public static Matrix MultiplyByNumber(Matrix matrix, int multiplier)
        {
            matrix.Multiply(multiplier);
            return matrix;
        }
        public static Matrix SummationOfMatrixes(Matrix matrix , Matrix matrix1)
        {
            matrix.Substract(matrix1);
            return matrix;
        }
        public static Matrix MultiplyingOfMatrixes(Matrix matrix, Matrix matrix1)
        {
            var result = matrix.Multiply(matrix1);
            return result;
        }
    }

}
