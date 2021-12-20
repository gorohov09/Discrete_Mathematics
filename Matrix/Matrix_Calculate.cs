using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix_Calculate
    {
        private readonly int[,] _Matrix;
        IReadMatrix _readMatrix;

        public Matrix_Calculate(IReadMatrix readMatrix)
        {
            _readMatrix = readMatrix;
            _Matrix = readMatrix.Read();
        }

        public int FindWay(int v1, int v2, int count)
        {
            int[,] Current_Matrix = Copy_Matrix(_Matrix);
            int way = 1;
            while (Current_Matrix[v1-1, v2-1] == 0)
            {
                Current_Matrix = PowMatrix(Current_Matrix, _Matrix);

                way++;

                if (way == count)
                    return -1;
            }

            return way;
        }

        public int FindCount(int v1, int v2, int way)
        {
            int[,] Current_Matrix = Copy_Matrix(_Matrix);
            for (int i = 1; i < way; i++)
            {
                Current_Matrix = PowMatrix(Current_Matrix, _Matrix);
            }

            return Current_Matrix[v1 - 1, v2 - 1];
        }

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
