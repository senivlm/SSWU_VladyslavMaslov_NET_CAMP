using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings
{
    public class Task3
    {
        public string Text { get; private set; }

        public Task3(string text)
        {
            Text = text;
        }
        public Task3()
        {
            Text = "";

        }
        public void SetText(string text)=>Text = text;
        public string ReplaceWordsWithDoubleLetters(string replacement)
        {
            string[] words = Text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (HasDoubleLetter(words[i]))
                {
                    words[i] = replacement;
                }
            }

            return string.Join(" ", words);
        }

        static bool HasDoubleLetter(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
