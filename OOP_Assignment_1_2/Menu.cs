using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_1_2
{
	public class Menu
	{
		public static void Run()
		{
			Console.WriteLine("Enter the number of rows: ");
			int m = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the number of columns: ");
			int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlease enter the value of the Primary Matrix: ");
            ChessboardMatrix matrix = new ChessboardMatrix(m, n, true);

            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Find a Matrix entry");
                Console.WriteLine("2. Add Two Matrices");
                Console.WriteLine("3. Multiply Two Matrices");
                Console.WriteLine("4. Print the Matrix");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            FindEntry(matrix);
                            break;

                        case 2:
                            FindAddition(m, n, matrix);
                            break;

                        case 3:
                            FindMultiplication(n, m, matrix);
                            break;

                        case 4:
                            FindPrintMatrix(matrix);
                            break;

                        case 5:
                            Console.WriteLine("Exiting program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer choice.");
                    Console.WriteLine();
                }
            }

        }

        public static void FindEntry(ChessboardMatrix matrix)
		{
            Console.WriteLine("Enter the number of the row: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of the column: ");
            int b = Convert.ToInt32(Console.ReadLine());

            int value = matrix.GetValue(a, b);
            Console.WriteLine($"Value at ({a}, {b}) = {value}");
        }

		public static void FindAddition(int m, int n, ChessboardMatrix matrix)
		{
            Console.WriteLine("\nPlease enter the value of the Matrix used for Addition: ");
            ChessboardMatrix matrix2 = new ChessboardMatrix(m, n, true);

            ChessboardMatrix sum = ChessboardMatrix.Addition(matrix, matrix2);
            Console.WriteLine("Matrix 1 + Matrix 2:");
            Console.WriteLine(sum);
        }

        public static void FindMultiplication(int n, int m, ChessboardMatrix matrix)
        {
            Console.WriteLine("\nPlease enter the value of the Matrix used for Multiplication: ");
            ChessboardMatrix matrix3 = new ChessboardMatrix(n, m, true);

            ChessboardMatrix multiply = ChessboardMatrix.Multiply(matrix, matrix3);
            Console.WriteLine("Matrix 1 * Matrix 3:");
            Console.WriteLine(multiply);
        }

        public static void FindPrintMatrix(ChessboardMatrix matrix)
        {
            ChessboardMatrix.PrintMatrix(matrix);   
        }

    }
}