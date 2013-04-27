using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PigLatin
{
    class Program
    {
        private static string vowels = "AEIOUaeiuo";
        private static string specialCharacters = " ~`!@#$%^&*()'\";:/?.>,<";

        static void Main(string[] args)
        {
            string text = "hello there my little friend.";
            
            string[] words = text.Split(specialCharacters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {

                string newWord = ConvertToPigLatin(word);

                sb.Append(newWord + " ");
            }

            Console.WriteLine(sb.ToString());
            Console.Read();
        }

        private static string ConvertToPigLatin(string word)
        {
            int vowelIndex = GetIndexOfFirstVowel(word);

            string newWord = word.Substring(vowelIndex) + word.Substring(0, vowelIndex) + "ay";

            return newWord;
        }

        private static int GetIndexOfFirstVowel(string word)
        {
            int index = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (vowels.Contains(word[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
