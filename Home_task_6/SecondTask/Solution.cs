using System;
using System.Collections.Generic;

namespace Task_2
{
    public static class Solution
    {
        //метод для демонстрации
        public static void Demo()
        {
            var array1 = new[] { 2, 4, 1, 6 };
            var array2 = new[] { 3, 5, 9 };
            var array3 = new[] { 7, 8, 9 };
            var mergedArray = MergeAndSortArrays(array1, array2, array3);

            PrintArr(mergedArray);
        }
        //метод для вывода всего массива
        public static void PrintArr(IEnumerable<int> nums)
        {
            int i = 0;
            foreach (int x in nums)
            {
                i++;
                Console.WriteLine($"{i}). {x}");
            }
        }
        //метод обёртка для слияния и сортировки
        public static IEnumerable<int> MergeAndSortArrays(params int[][] arrays)
        {
            var mergedAr = MergeArrays(arrays);
            var sortedAr = SortArray(mergedAr);

            return sortedAr;
        }
        //метод для слияния
        public static IEnumerable<int> MergeArrays(params int[][] arrays)
        {
            List<int> mergedList = new List<int>();

            foreach (int[] array in arrays)
            {
                mergedList.AddRange(array);
            }

            foreach (int num in mergedList)
            {
                yield return num;
            }
        }
        //метод для сортировки
        public static IEnumerable<int> SortArray(IEnumerable<int> array)
        {
            List<int> sortedList = new List<int>(array);
            for (int i = 1; i < sortedList.Count; i++)
            {
                int j = i;
                while (j > 0 && sortedList[j - 1] > sortedList[j])
                {
                    int temp = sortedList[j];
                    sortedList[j] = sortedList[j - 1];
                    sortedList[j - 1] = temp;
                    j--;
                }
            }

            foreach (int num in sortedList)
            {
                yield return num;
            }
        }

    }
}
