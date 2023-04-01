using System;
namespace SecondTask
{
    class Program
    {// домовлялися, що будем мислити об'єктно -зорієнтовано!!!!
        // Алгоритмічно все добре.
        static void Main()
        {
            Console.WriteLine("Do you want to enter the matrix elements manually? (Y/N)");
            string choice = Console.ReadLine();
            bool manualInput = (choice == "Y" || choice == "y");

            Console.WriteLine("Enter the width of the matrix:");
            int width = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the height of the matrix:");
            int height = int.Parse(Console.ReadLine());

            int[,] matrix = new int[height, width];
            Random rand = new Random();

            if (manualInput)
            {
                Console.WriteLine("Enter the matrix elements separated by commas:");

                for (int i = 0; i < height; i++)
                {
                    Console.Write($"{i}:\t");
                    string[] rowValues = Console.ReadLine().Split(',');
                    for (int j = 0; j < width; j++)
                    {
                        matrix[i, j] = int.Parse(rowValues[j]);
                    }
                }
            }

            else
            {

                Console.WriteLine($"Generated matrix of size {height}x{width}:");
                Console.Write("  \t");
                for (int i = 0; i < width; i++)
                {
                    Console.Write($"{i}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < height; i++)
                {
                    Console.Write($"{i}:\t");
                    for (int j = 0; j < width; j++)
                    {
                        matrix[i, j] = rand.Next(0, 17);
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            int longestLineStart = 0;
            int longestLineEnd = 0;
            int longestLineLength = 0;
            int longestLineIndex = 0;
            int currentLineStart = 0;
            int currentLineLength = 0;

            for (int i = 0; i < height; i++)
            {
                currentLineStart = 0;
                currentLineLength = 1;

                for (int j = 1; j < width; j++)
                {
                    if (matrix[i, j] == matrix[i, j - 1])
                    {
                        currentLineLength++;
                    }
                    else
                    {
                        if (currentLineLength > longestLineLength)
                        {
                            longestLineStart = currentLineStart;
                            longestLineEnd = j - 1;
                            longestLineLength = currentLineLength;
                            longestLineIndex = i;
                        }

                        currentLineStart = j;
                        currentLineLength = 1;
                    }
                }

                if (currentLineLength > longestLineLength)
                {
                    longestLineStart = currentLineStart;
                    longestLineEnd = width - 1;
                    longestLineLength = currentLineLength;
                    longestLineIndex = i;
                }
            }

            Console.WriteLine($"The longest line starts at column {longestLineStart}, ends at column {longestLineEnd}, and has a length of {longestLineLength}.");
            Console.WriteLine($"The longest line is on row {longestLineIndex}.");
            Console.Write("The row with the longest lines: ");

            for (int j = longestLineStart; j <= longestLineEnd; j++)
            {
                Console.Write(matrix[longestLineIndex, j] + " ");
            }

            Console.ReadLine();
        }
    }
}
