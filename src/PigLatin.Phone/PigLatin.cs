using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;

namespace PigLatin.Phone
{
    public class PigLatin
    {
        private static string vowels = "AEIOUaeiuo";
        private static string specialCharacters = " ~`!@#$%^&*()'\";:/?.>,<";

        public static string ConvertToPigLatin(string sentence)
        {
            string[] words = sentence.Split(specialCharacters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                string newWord = ConvertWordToPigLatin(word);

                sb.Append(newWord + " ");
            }

            return sb.ToString();
        }

        private static string ConvertWordToPigLatin(string word)
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
                if (vowels.Contains(word[i].ToString()))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
