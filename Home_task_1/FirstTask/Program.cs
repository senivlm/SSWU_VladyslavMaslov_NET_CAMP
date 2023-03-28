using System;
namespace FirstTask
{// Це швидше функціональний підхід. У одному класі у вас і реалізація візуалізації і модельна задача. Це не дуже добре. будем ще вивчати. Алгоритмічно - добре. Хоча можна ще оптимізувати по кількості циклів.
    class SpiralMatrix
    {
        public enum SpiralDirection
        {
            Clockwise,
            CounterClockwise
        }

        public static int[,] GenerateSpiralArray(int rows, int columns, SpiralDirection direction)
        {
            int[,] spiralArray = new int[rows, columns];
            int num = 1;
            //int row = 0, col = 0;
            int rowLimit = rows - 1, colLimit = columns - 1;
            int rowStart = 0, colStart = 0;

            while (rowStart <= rowLimit && colStart <= colLimit)
            {
                if (direction == SpiralDirection.Clockwise)
                {
                    for (int i = colStart; i <= colLimit; i++)
                    {
                        spiralArray[rowStart, i] = num++;
                    }
                    rowStart++;

                    for (int i = rowStart; i <= rowLimit; i++)
                    {
                        spiralArray[i, colLimit] = num++;
                    }
                    colLimit--;

                    for (int i = colLimit; i >= colStart; i--)
                    {
                        spiralArray[rowLimit, i] = num++;
                    }
                    rowLimit--;

                    for (int i = rowLimit; i >= rowStart; i--)
                    {
                        spiralArray[i, colStart] = num++;
                    }
                    colStart++;
                }
                else // direction == SpiralDirection.CounterClockwise
                {
                    for (int i = colLimit; i >= colStart; i--)
                    {
                        spiralArray[rowStart, i] = num++;
                    }
                    rowStart++;

                    for (int i = rowStart; i <= rowLimit; i++)
                    {
                        spiralArray[i, colStart] = num++;
                    }
                    colStart++;

                    for (int i = colStart; i <= colLimit; i++)
                    {
                        spiralArray[rowLimit, i] = num++;
                    }
                    rowLimit--;

                    for (int i = rowLimit; i >= rowStart; i--)
                    {
                        spiralArray[i, colLimit] = num++;
                    }
                    colLimit--;
                }
            }

            return spiralArray;
        }

        static void PrintMatrix(int rows, int columns, SpiralDirection direction)
        {
            int[,] spiralArray = GenerateSpiralArray(rows, columns, direction);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,3} ", spiralArray[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
