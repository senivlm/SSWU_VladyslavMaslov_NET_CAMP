using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public static class Solution
    {
        public static void Demo()
        {
            var text = "Диктант №243 (50 слів)\r\nВосени у кущах поблизу болота діти знайшли журавля." +
                " У нього було пере6ите крило. Діти принесли журавля додому Диктант №243 (50 слів)\r\nВосени " +
                "у кущах поблизу болота діти знайшли журавля. У нього було пере6ите крило. Діти принесли журавля додому";

            PrintUniqueWords(text);
        }
        public static void PrintUniqueWords(string text)
        {
            var textLength = GetWordsCount(text);
            Console.WriteLine($"Text length : {textLength} words");

            var uniqueWords = GetUniqueWords(text);
            Console.WriteLine($"Number of unique words: {uniqueWords.Count()}\n");

            int i = 0;
            foreach(var word in uniqueWords)
            {
                i++;
                Console.WriteLine($"{i}). {word}");
            }
        }
        public static int GetWordsCount(string text) => 
            text.Split(new[] { ' ', ',', '.', ';', ':', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Count();

        public static IEnumerable<string> GetUniqueWords(string text)
        {
            HashSet<string> uniqueWords = new HashSet<string>();
            string[] words = text.Split(new[] { ' ', ',', '.', ';', ':', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (!uniqueWords.Contains(word))
                {
                    uniqueWords.Add(word);
                    yield return word;
                }
            }
        }

    }
}
