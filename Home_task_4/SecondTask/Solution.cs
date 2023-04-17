using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace task2
{
    public static class Solution
    {
        public static void InvokeSolution()
        {
            Console.WriteLine("enter some text here:");

            var text = Console.ReadLine();

            var list = FindEmailsAndAtWords(text);

            Console.WriteLine($"the number of all valid email addresses, as well as tokens" +
                $" that are not valid email addresses but contain the @ symbol in their entry: {list.Count}\n\n" +
                $"list of these tokens\n");

            int i = 0;
            foreach(var l in list)
            {
                i++;
                Console.WriteLine($"{i}). {l};\n");
            }
        }

        public static List<string> FindEmailsAndAtWords(string text)
        {
            List<string> results = new List<string>();

            // Регулярний вираз для визначення електронних адрес
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z]{2,}\b";
            Regex emailRegex = new Regex(emailPattern);

            // Регулярний вираз для визначення слів з символом @, які не є електронними адресами
            string atWordPattern = @"\b\w+@\w+\b";
            Regex atWordRegex = new Regex(atWordPattern);

            // Знаходимо всі електронні адреси в тексті і додаємо їх до списку результатів
            MatchCollection emailMatches = emailRegex.Matches(text);
            foreach (Match match in emailMatches)
            {
                results.Add(match.Value);
            }

            // Знаходимо всі слова з символом @, які не є електронними адресами, і додаємо їх до списку результатів
            MatchCollection atWordMatches = atWordRegex.Matches(text);
            foreach (Match match in atWordMatches)
            {
                // Якщо слово з символом @ вже було додане до списку результатів як електронна адреса,
                // не додаємо його повторно
                if (!results.Contains(match.Value))
                {
                    results.Add(match.Value);
                }
            }

            return results;
        }
    }
}
