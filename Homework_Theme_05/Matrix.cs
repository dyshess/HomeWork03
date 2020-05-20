using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Matrix
    {
        /// <summary>
        /// Количество столбцов матрицы
        /// </summary>
        private int MatrixHeight
        {
            get { return matrixHeight; }
            set { if (value > 0) { matrixHeight = value; } else { Console.WriteLine("Неправильное значение высоты матрицы!"); } }
        }
        private int matrixHeight;
        /// <summary>
        /// Количество строк матрицы
        /// </summary>
        private int MatrixWidth
        {
            get { return matrixWidth; }
            set { if (value > 0) { matrixWidth = value; } else { Console.WriteLine("Неправильное значение ширины матрицы!"); } }
        }
        private int matrixWidth;
        private int MaxValue { get; set; }
        /// <summary>
        /// Матрица в виде двумерного массива
        /// </summary>
        public int[,] MatrixValue { get; set; }
        private int Multiplier { get; set; }

        Random random = new Random();

        /// <summary>
        /// Заполнение матрицы случайными числами
        /// </summary>
        /// <param name="width">Ширина матрицы></param>
        /// <param name="height">Высота матрицы</param>
        /// <param name="maxValue">Максимальное значение ячейки</param>
        public void Generate(int width, int height, int maxValue)
        {
            this.MatrixWidth = width;
            this.MatrixHeight = height;
            this.MaxValue = maxValue;
            this.MatrixValue = new int[this.MatrixWidth, this.MatrixHeight];
            for (int i = 0; i < this.MatrixWidth; i++)
            {
                for (int j = 0; j < this.MatrixHeight; j++)
                {
                    MatrixValue[i, j] = random.Next(0, this.MaxValue);
                }
            }
        }
        /// <summary>
        /// Отображение матрицы в консоль
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.MatrixWidth; i++)
            {
                Console.Write("|\t");
                for (int j = 0; j < this.MatrixHeight; j++)
                {
                    Console.Write(this.MatrixValue[i, j] + "\t");
                }
                Console.Write("|\n");
            }
        }
        /// <summary>
        /// Умножение на число
        /// </summary>
        /// <param name="matrix">множитель</param>
        public void Multiply(int multiplier)
        {
            this.Multiplier = multiplier;
            for (int i = 0; i < this.MatrixWidth; i++)
            {
                for (int j = 0; j < this.MatrixHeight; j++)
                {
                    this.MatrixValue[i, j] *= this.Multiplier;
                }
            }
        }
        /// <summary>
        /// Сложение с матрицей
        /// </summary>
        /// <param name="matrix">слагаемая матрица</param>
        public void Summ(Matrix matrix)
        {
            for (int i = 0; i < this.MatrixWidth; i++)
            {
                for (int j = 0; j < this.MatrixHeight; j++)
                {
                    this.MatrixValue[i, j] += matrix.MatrixValue[i, j];
                }
            }
        }
        /// <summary>
        /// Вычитание из матрицы
        /// </summary>
        /// <param name="matrix">вычитаемая матрица</param>
        public void Substract(Matrix matrix)
        {
            for (int i = 0; i < this.MatrixWidth; i++)
            {
                for (int j = 0; j < this.MatrixHeight; j++)
                {
                    this.MatrixValue[i, j] -= matrix.MatrixValue[i, j];
                }
            }
        }
        /// <summary>
        /// Умножение на матрицу
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>Результат</returns>
        public Matrix Multiply(Matrix matrix)
        {
            Matrix resultMatrix = new Matrix();

            if (matrix.MatrixWidth == this.MatrixHeight & this.MatrixWidth > 1 & this.MatrixHeight > 1) //Если матрицы равны по высоте и ширине и имеют > 1 строки и столбца
            {
                resultMatrix = MultiplyCycle(matrix);
            }
            else if (this.MatrixWidth == 1 & this.MatrixHeight == matrix.MatrixWidth & matrix.MatrixHeight == 1) //Если произведение имеет вид [1,n]*[n,1]
            {
                resultMatrix = SimpleMultiply(matrix);
            }
            else if (this.MatrixHeight == 1 & this.MatrixWidth == matrix.MatrixHeight & matrix.MatrixWidth == 1) //Если произведение имеет вид [n,1]*[1,n]
            {
                //Приведение произведения к виду [1,n] * [n,1] для использования в SimpleMultiply
                //Замена слагаемых матриц местами
                var tempMatrix = ReplaceMatrixes(matrix);
                resultMatrix = SimpleMultiply(tempMatrix);
            }
            else
            {
                Console.WriteLine("Невозможно выполнить операцию!");
            }
            return resultMatrix;
        }
        private Matrix MultiplyCycle(Matrix matrix)
        {
            Matrix resultMatrix = new Matrix();
            resultMatrix.MatrixWidth = this.MatrixWidth;
            resultMatrix.MatrixHeight = this.MatrixHeight;
            resultMatrix.MatrixValue = new int[this.MatrixWidth, this.MatrixHeight];
            for (int i = 0; i < this.MatrixWidth; i++)
            {
                for (int j = 0; j < this.MatrixHeight; j++)
                {
                    int result = 0;
                    for (int k = 0; k < this.MatrixHeight; k++)
                    {
                        result += this.MatrixValue[i, k] * matrix.MatrixValue[k, j];
                    }
                    resultMatrix.MatrixValue[i, j] = result;
                }
            }
            return resultMatrix;
        }
        /// <summary>
        /// Умножение одномерных матриц
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>Матрица[0,0]</returns>
        public Matrix SimpleMultiply(Matrix matrix)
        {
            Matrix resultMatrix = new Matrix();
            resultMatrix.MatrixWidth = 1;
            resultMatrix.MatrixHeight = 1;
            resultMatrix.MatrixValue = new int[1, 1];
            int result = 0;
            for (int k = 0; k < this.MatrixHeight; k++)
            {
                result += this.MatrixValue[0, k] * matrix.MatrixValue[k, 0];
            }
            resultMatrix.MatrixValue[0, 0] = result;
            return resultMatrix;
        }
        /// <summary>
        /// Замена умножаемой матрицы на матрицу-множитель
        /// </summary>
        /// <param name="matrix">Матрица-множитель</param>
        /// <returns>Умножаемая матрица</returns>
        private Matrix ReplaceMatrixes(Matrix matrix)
        {
            var tempMatrix = new Matrix();
            tempMatrix.MatrixHeight = this.MatrixHeight;
            tempMatrix.MatrixWidth = this.MatrixWidth;
            tempMatrix.MatrixValue = this.MatrixValue;

            this.MatrixHeight = matrix.MatrixHeight;
            this.MatrixWidth = matrix.MatrixWidth;
            this.MatrixValue = matrix.MatrixValue;
            return tempMatrix;
        }
    }
}
