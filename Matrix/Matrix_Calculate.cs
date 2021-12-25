using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix_Calculate
    {
        private readonly int[,] _Matrix; //Матрица, сохраненная в виде двумерного массива целых чисел
        IReadMatrix _readMatrix; //Интерфейс для считывания данных(может хранится ссылка на объект одного из 3 классов)

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="readMatrix"></param>
        public Matrix_Calculate(IReadMatrix readMatrix)
        {
            _readMatrix = readMatrix; //Получение ссылки на класс - поставщик данных
            _Matrix = readMatrix.Read(); //Считывание данных
        }

        /// <summary>
        /// Метод нахождения пути между двумя вершинами
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindWay(int v1, int v2)
        {
            int count_vertex = _Matrix.GetLength(0); //Кол-во вершин графа
            int[,] Current_Matrix = Copy_Matrix(_Matrix); //Копируем значение исходной матрицы
            int way = 1; //Текущая степень матрицы
            while (Current_Matrix[v1-1, v2-1] == 0)
            {
                Current_Matrix = PowMatrix(Current_Matrix, _Matrix); //Возведение матрицы в следующую степень

                way++;

                if (way == count_vertex) //Случай, когда вершины не имеют связей
                    return -1;
            }

            return way; //Возвращение пути между двумя вершинами
        }

        /// <summary>
        /// Нахождение колличества маршрутов
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="way"></param>
        /// <returns></returns>
        public int FindCount(int v1, int v2, int way)
        {
            int[,] Current_Matrix = Copy_Matrix(_Matrix); //Копируем значение исходной матрицы
            for (int i = 1; i < way; i++) //Возведение исходной матрицы в степень way
            {
                Current_Matrix = PowMatrix(Current_Matrix, _Matrix);
            }

            return Current_Matrix[v1 - 1, v2 - 1]; //пересечение вершин в матрице- количество маршрутов длины, равной степени матрицы
        }

        /// <summary>
        /// Возведение матрицы в степень
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private int[,] PowMatrix(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Копирование матрицы по значению
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private int[,] Copy_Matrix(int[,] matrix)
        {
            int[,] Current_Matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Current_Matrix[i, j] = matrix[i, j];
                }
            }
            return Current_Matrix;
        }
    }
}
