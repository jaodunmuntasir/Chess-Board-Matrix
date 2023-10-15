using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Assignment_1_2;
using System.Numerics;

namespace ChessboardMatrix_Test
{
    [TestClass]
    public class Matrix_Test
    {
        [TestMethod]
        public void GetValueTest()
        {
            ChessboardMatrix matrix = new ChessboardMatrix(4, 4, false);

            matrix.SetValue(1, 2, 10);
            matrix.SetValue(2, 3, 20);
            matrix.SetValue(4, 3, 30);

            int value1 = matrix.GetValue(1, 2);
            int value2 = matrix.GetValue(2, 3);
            int value3 = matrix.GetValue(4, 3);
            int value4 = matrix.GetValue(1, 1);
            int value5 = matrix.GetValue(3, 1);

            Assert.AreEqual(10, value1);
            Assert.AreEqual(20, value2);
            Assert.AreEqual(30, value3);
            Assert.AreEqual(0, value4);
            Assert.AreEqual(0, value5);
        }

        [TestMethod]
        public void AdditionTest1()
        {
            ChessboardMatrix matrix1 = new ChessboardMatrix(3, 3, false);
            matrix1.SetValue(1, 2, 4);
            matrix1.SetValue(2, 1, 8);
            matrix1.SetValue(2, 3, 12);
            matrix1.SetValue(3, 2, 16);

            ChessboardMatrix matrix2 = new ChessboardMatrix(3, 3, false);
            matrix2.SetValue(1, 2, 3);
            matrix2.SetValue(2, 1, 7);
            matrix2.SetValue(2, 3, 11);
            matrix2.SetValue(3, 2, 15);

            ChessboardMatrix result = ChessboardMatrix.Addition(matrix1, matrix2);

            Assert.AreEqual(0, result.GetValue(1, 1));
            Assert.AreEqual(7, result.GetValue(1, 2));
            Assert.AreEqual(0, result.GetValue(1, 3));
            Assert.AreEqual(15, result.GetValue(2, 1));
            Assert.AreEqual(0, result.GetValue(2, 2));
            Assert.AreEqual(23, result.GetValue(2, 3));
            Assert.AreEqual(0, result.GetValue(3, 1));
            Assert.AreEqual(31, result.GetValue(3, 2));
            Assert.AreEqual(0, result.GetValue(3, 3));
        }

        [TestMethod]
        public void AdditionTest2()
        {
            ChessboardMatrix matrix1 = new ChessboardMatrix(3, 3, false);
            matrix1.SetValue(1, 2, 4);
            matrix1.SetValue(2, 1, 8);
            matrix1.SetValue(2, 3, 12);
            matrix1.SetValue(3, 2, 16);

            ChessboardMatrix matrix2 = new ChessboardMatrix(3, 2, false);
            matrix2.SetValue(1, 2, 3);
            matrix2.SetValue(2, 1, 7);
            matrix2.SetValue(3, 2, 15);

            Assert.ThrowsException<ArgumentException>(() => ChessboardMatrix.Addition(matrix1, matrix2));
        }

        [TestMethod]
        public void MultiplicationTest1()
        {
            ChessboardMatrix matrix1 = new ChessboardMatrix(3, 3, false);
            matrix1.SetValue(1, 2, 1);
            matrix1.SetValue(2, 1, 2);
            matrix1.SetValue(2, 3, 3);
            matrix1.SetValue(3, 2, 4);

            ChessboardMatrix matrix3 = new ChessboardMatrix(3, 3, false);
            matrix3.SetValue(1, 2, 1);
            matrix3.SetValue(2, 1, 2);
            matrix3.SetValue(2, 3, 3);
            matrix3.SetValue(3, 2, 4);

            ChessboardMatrix result = ChessboardMatrix.Multiply(matrix1, matrix3);

            Assert.AreEqual(2, result.GetValue(1, 1));
            Assert.AreEqual(0, result.GetValue(1, 2));
            Assert.AreEqual(3, result.GetValue(1, 3));
            Assert.AreEqual(0, result.GetValue(2, 1));
            Assert.AreEqual(14, result.GetValue(2, 2));
            Assert.AreEqual(0, result.GetValue(2, 3));
            Assert.AreEqual(8, result.GetValue(3, 1));
            Assert.AreEqual(0, result.GetValue(3, 2));
            Assert.AreEqual(12, result.GetValue(3, 3));
        }

        [TestMethod]
        public void MultiplicationTest2()
        {
            ChessboardMatrix matrix1 = new ChessboardMatrix(3, 3, false);
            matrix1.SetValue(1, 2, 1);
            matrix1.SetValue(2, 1, 2);
            matrix1.SetValue(2, 3, 3);
            matrix1.SetValue(3, 2, 4);

            ChessboardMatrix matrix3 = new ChessboardMatrix(2, 3, false);
            matrix3.SetValue(1, 2, 1);
            matrix3.SetValue(2, 1, 2);
            matrix3.SetValue(2, 3, 3);

            Assert.ThrowsException<ArgumentException>(() => ChessboardMatrix.Multiply(matrix1, matrix3));
        }

        [TestMethod]
        public void PrintMatrixTest()
        {
            int m = 3;
            int n = 3;
            bool takeUserInput = false;

            ChessboardMatrix matrix = new ChessboardMatrix(m, n, takeUserInput);

            matrix.SetValue(1, 2, 5);
            matrix.SetValue(2, 1, 8);
            matrix.SetValue(2, 3, 2);
            matrix.SetValue(3, 2, 7);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ChessboardMatrix.PrintMatrix(matrix);

                string printedMatrix = sw.ToString().Trim();

                string expectedMatrix = matrix.ToString().Trim();

                Assert.AreEqual(expectedMatrix, printedMatrix);
            }
        }

    }
}