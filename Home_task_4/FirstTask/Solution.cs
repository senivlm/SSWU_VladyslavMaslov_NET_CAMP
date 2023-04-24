using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{// не об'єктно-зорієнтовано мислите. І розв'язуєте простішу задачу, ніж я визначила. У вас на вході мала бути не одна стрічка, а кілька стрічок, які не можна зливати в одну.
    public static class Solution
    {
        public static void Demo()
        {
            Console.WriteLine("Enter some text here");
            var text = Console.ReadLine();
            
            var sentenses = SentencesWithBrackets(text);

            PrintSentencesWithBrackets(sentenses);
        }
        public static void Demo2()
        {
            Console.WriteLine("original text:");
            var text = "This is a sentence with data in parentheses " +
                "(information in parentheses), and this is without. " +
                "This is the second sentence with data in parentheses" +
                " (data in second parentheses), and this is without " +
                "data. And this is a sentence without data in brackets.";

            var sentenses = SentencesWithBrackets(text);

            PrintSentencesWithBrackets(sentenses);
        }

        public static void PrintSentencesWithBrackets(List<string> sentenses)
        {
            Console.WriteLine("\nsentenses with brackets:\b");

            int i = 0;
            foreach (var sentence in sentenses)
            {
                i++;
                Console.WriteLine($"{i}). {sentence};");
            }
        }
        public static List<string> SentencesWithBrackets(string text)
        {
            List<string> sentencesWithBrackets = new List<string>();
            string sentence = "";
            bool isInBrackets = false;

            foreach (char c in text)
            {
                if (c == '(')
                {
                    isInBrackets = true;
                }
                else if (c == ')')
                {
                    isInBrackets = false;
                }

                sentence += c;

                if (c == '.' || c == '?' || c == '!' || c == ',')
                {
                    if (isInBrackets)
                    {
                        continue;
                    }

                    if (sentence.Contains("(") && sentence.Contains(")"))
                    {
                        sentencesWithBrackets.Add(sentence);
                    }

                    sentence = "";
                }
            }
            return sentencesWithBrackets;
        }
    }
}
