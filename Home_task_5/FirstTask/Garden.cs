using System;
using System.Collections.Generic;
using System.Drawing;

class Garden
{// Ви правильно реалізували алгоритм
    public static void Demo()
    {
        Console.WriteLine("Enter the number of trees in the first garden");
        int x0 = int.Parse(Console.ReadLine());
        var Garden = new Garden(x0, 10, 10);

        Garden.PrintTreesInfo();

        Console.WriteLine($"Fence length 0: {Garden.GetFenceLength()}");

        Console.WriteLine("Enter the number of trees in the second garden");
        int x1 = int.Parse(Console.ReadLine());

        var Garden1 = new Garden(x1, 10, 10);

        Garden1.PrintTreesInfo();

        Console.WriteLine($"Fence length 1: {Garden1.GetFenceLength()}");

        Console.WriteLine($"The length of the first fence is longer: {Garden1 < Garden}");
        Console.WriteLine($"The length of the second fence is longer: {Garden1 > Garden}");
        Console.WriteLine($"The length of the fences is the same: {Garden1 == Garden}");

        Console.ReadLine();


    }

    public List<Point> Trees { get; set; }

    public double GetFenceLength()
    {
        if (Trees.Count < 2)
        {
            return 0;
        }

        // Знайдемо найлівішу точку (з найменшою координатою x)
        Point leftmost = Trees[0];
        for (int i = 1; i < Trees.Count; i++)
        {
            if (Trees[i].X < leftmost.X)
            {
                leftmost = Trees[i];
            }
        }

        // Сортуємо точки за кутом відносно найлівішої точки
        Trees.Sort((a, b) =>
        {
            double angleA = Math.Atan2(a.Y - leftmost.Y, a.X - leftmost.X);
            double angleB = Math.Atan2(b.Y - leftmost.Y, b.X - leftmost.X);
            if (angleA < angleB)
            {
                return -1;
            }
            else if (angleA > angleB)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        });

        // Обхід множини точок та обчислення довжини ланцюга
        double fenceLength = 0;
        Point prev = Trees[Trees.Count - 1];
        for (int i = 0; i < Trees.Count; i++)
        {
            Point curr = Trees[i];
            fenceLength += Math.Sqrt(Math.Pow(curr.X - prev.X, 2) + Math.Pow(curr.Y - prev.Y, 2));
            prev = curr;
        }

        return fenceLength;
    }

    public Garden(int treesCount, int maxWidth, int maxLength)
    {
        Trees = new List<Point>();
        var random = new Random();
        for (int i = 0; i < treesCount; i++)
        {
            var tree = new Point(random.Next(-maxWidth, maxWidth), random.Next(-maxLength, maxLength));

            Trees.Add(tree);
        }
        //FencePosts = FindShortestFence();
    }

    public void PrintTreesInfo()
    {
        int i = 0;
        foreach (var tree in Trees)
        {
            i++;
            Console.WriteLine($"{i}). x: {tree.X} y: {tree.Y}");
        }
    }

    public static bool operator <(Garden g1, Garden g2)
    {
        return g1.GetFenceLength() < g2.GetFenceLength();
    }

    public static bool operator >(Garden g1, Garden g2)
    {
        return g1.GetFenceLength() > g2.GetFenceLength();
    }

    public static bool operator <=(Garden g1, Garden g2)
    {
        return g1.GetFenceLength() <= g2.GetFenceLength();
    }

    public static bool operator >=(Garden g1, Garden g2)
    {
        return g1.GetFenceLength() >= g2.GetFenceLength();
    }
}
