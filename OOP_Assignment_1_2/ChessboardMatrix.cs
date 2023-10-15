using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_1_2
{
    public class ChessboardMatrix
    {
        private List<List<int>> matrix;
        private int rows;
        private int cols;

        public ChessboardMatrix(int m, int n, bool takeUserInput)
        {
            rows = m;
            cols = n;
            matrix = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                matrix.Add(new List<int>());

                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        matrix[i].Add(0);
                    }
                    else
                    {
                        if (takeUserInput == true)
                        {
                            Console.WriteLine($"Enter the value for matrix[{i + 1}][{j + 1}]: ");
                            int value = int.Parse(Console.ReadLine());
                            matrix[i].Add(value);
                        }
                        else
                        {
                            matrix[i].Add(0);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    output += matrix[i][j].ToString().PadLeft(4) + " ";
                }

                output += "\n";
            }

            return output;
        }

        public int GetValue(int row, int col)
        {
            int row_current = row - 1;
            int col_current = col - 1;

            if (row_current < 0 || row_current >= rows || col_current < 0 || col_current >= cols)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            return matrix[row_current][col_current];
        }

        public void SetValue(int row, int col, int value)
        {
            int row_current = row - 1;
            int col_current = col - 1;

            if (row_current < 0 || row_current >= rows || col_current < 0 || col_current >= cols)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            matrix[row_current][col_current] = value;
        }

        public int this[int row, int col]
        {
            get { return matrix[row][col]; }
            set { matrix[row][col] = value; }
        }

        public static ChessboardMatrix Addition(ChessboardMatrix matrix, ChessboardMatrix matrix2)
        {
            if (matrix.rows != matrix2.rows || matrix.cols != matrix2.cols)
            {
                throw new ArgumentException("Matrices must be of the same size.");
            }

            ChessboardMatrix result = new ChessboardMatrix(matrix.rows, matrix.cols, false);

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    result[i, j] = matrix[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static ChessboardMatrix Multiply(ChessboardMatrix matrix, ChessboardMatrix matrix3)
        {
            if (matrix.cols != matrix3.rows)
            {
                throw new ArgumentException("Matrices are not compatible for multiplication.");
            }

            ChessboardMatrix result = new ChessboardMatrix(matrix.rows, matrix3.cols, false);

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix3.cols; j++)
                {
                    for (int k = 0; k < matrix.cols; k++)
                    {
                        result[i, j] += matrix[i, k] * matrix3[k, j];
                    }
                }
            }

            return result;
        }

        public static void PrintMatrix(ChessboardMatrix matrix)
        {
            Console.WriteLine(matrix.ToString());
        }
    }
}
