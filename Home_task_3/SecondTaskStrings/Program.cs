using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings
{// Ми домовлялись, що клас Program у нас не розв'язує задачі, а делегує розв'язування в інші класи(((.
    internal class Program
    {
        static void SecondSub(string text, string sub)
        {
            int firstIndex = text.IndexOf(sub);
            if (firstIndex == -1)
            {
                Console.WriteLine("Substring not found");
            }
            else
            {
                int secondIndex = text.IndexOf(sub, firstIndex + 1);
                if (secondIndex == -1)
                {
                    Console.WriteLine("Second substring not found");
                }
                else
                {
                    Console.WriteLine("Second substring index: " + secondIndex);
                }
            }
        }
        static int CountWordsStartingWithUpperCase(string text)
        {//У загальному випадку слово має ширший сенс. Це набір непробільних символів між пробільними.  
            int wordCount = 0;
            // Це вважається поганим тоном іменувати ідентифікатор, починаючи з new.
            bool newWord = true; // flag indicating the start of a new word
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                { // if the character is a letter
                    if (newWord && Char.IsUpper(c))
                    { // if it's the start of a new word and the letter is uppercase
                        wordCount++;
                    }
                    newWord = false;
                }
                else
                { // if the character is not a letter
                    newWord = true;
                }
            }
            return wordCount;
        }

        
        static void Main(string[] args)
        {
            //1 task
            Console.WriteLine("================Task One================");
            Console.Write("Enter text here: ");
            string text1 = Console.ReadLine();
            Console.Write("Enter substring: ");
            string substring = Console.ReadLine();

            SecondSub(text1, substring);

            //2 task
            Console.WriteLine("================Task Two================");
            Console.Write("Enter the text: ");
            string text2 = Console.ReadLine();

            int wordCount = CountWordsStartingWithUpperCase(text2);
            Console.WriteLine("Number of words starting with an uppercase letter: " + wordCount);

            Console.ReadLine();

            //3 task
            Console.WriteLine("================Task Three================");
            Console.Write("Enter the text: ");
            string text3 = Console.ReadLine();

            Console.Write("Enter the replacement string for words with double letters: ");
            string replacement = Console.ReadLine();

            Task3 task3 = new Task3(text3);

            string result = task3.ReplaceWordsWithDoubleLetters(replacement);
            Console.WriteLine("Result of replacement: " + result);
            Console.ReadLine();
        }
    }
}
