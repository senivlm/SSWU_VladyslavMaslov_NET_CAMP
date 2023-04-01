using System;

namespace ThirdTask
{
    class Program
    {
        static void Main()
        {
            int size = 3;
            int[,,] cube = new int[size, size, size];
            Random rand = new Random();
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        cube[x, y, z] = rand.Next(0, 2);
                    }
                }
            }

            Console.WriteLine("Cube:");
            for (int z = 0; z < size; z++)
            {
                Console.WriteLine("Layer " + z + ":");
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        Console.Write(cube[z, y, x] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            for (int i = 0; i < size; i++)
            {
                bool diagonalHole = true;
                bool reverseDiagonalHole = true;
                for (int j = 0; j < size; j++)
                {
                    bool horizontalHole = true;
                    bool perpendicularHorizontalHole = true;
                    bool verticalHole = true;
                    if (cube[i, j, j] == 1 && diagonalHole)
                    {
                        diagonalHole = false;
                    }
                    if (cube[i, size - j - 1, j] == 1 && reverseDiagonalHole)
                    {
                        reverseDiagonalHole = false;
                    }

                    for (int k = 0; k < size; k++)
                    {
                        if (cube[i, j, k] == 1 && horizontalHole)
                        {
                            horizontalHole = false;
                        }
                        if (cube[i, k, j] == 1 && perpendicularHorizontalHole)
                        {
                            perpendicularHorizontalHole = false;
                        }
                        if (cube[k, i, j] == 1 && verticalHole)
                        {
                            verticalHole = false;
                        }
                    }
                    if (horizontalHole)
                    {
                        Console.WriteLine("({0}, {1}, 0),({0}, {1}, {2})", i, j, size - 1);
                    }
                    if (perpendicularHorizontalHole)
                    {
                        Console.WriteLine("({0}, 0, {1}),({0}, {2}, {1})", i, j, size - 1);
                    }
                    if (verticalHole)
                    {
                        Console.WriteLine("(0, {0}, {1}),({2}, {0}, {1})", i, j, size - 1);
                    }
                }
                if (diagonalHole) { Console.WriteLine("({0}, 0, 0),({0}, {1}, {1})", i, size - 1); }
                if (reverseDiagonalHole) { Console.WriteLine("({0}, 0, {1}),({0}, {1}, 0)", i, size - 1); }
            }
        }
    }
}