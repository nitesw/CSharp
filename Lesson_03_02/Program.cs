using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Lesson_03_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            /*string str = "Ener";
            str = str.Insert(2, "ter the numb");
            Console.WriteLine(str);*/

            /*Console.Write("Enter the word: ");
            string word = Console.ReadLine();
            bool isPalindrome = true;

            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("The word is a palindrome.");
            }
            else
            {
                Console.WriteLine("The word is not a palindrome.");
            }*/

            /*string text = "Визначте відсоткове відношення малих і великих літер до загальної кількості символів в ньому.";
            int lowerCase = 0;
            int upperCase = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                
                if(char.IsLower(letter))
                {
                    lowerCase++;
                }
                else if(char.IsUpper(letter))
                {
                    upperCase++;
                }
            }

            double lwPrecentage = ((double)lowerCase / text.Length) * 100;
            double upPrecentage = ((double)upperCase / text.Length) * 100;

            Console.WriteLine("Precentage of lowercase letters: {0:f2}%", lwPrecentage);
            Console.WriteLine("Precentage of uppercase letters: {0:f2}%", upPrecentage);*/

            /*string[] strarr = new string[] { "cook", "you", "are", "appointment", "apple", "candy", "peak" };

            for (int i = 0; i < strarr.Length; i++)
            {
                Console.Write(strarr[i] + " ");
            }

            Console.Write("\nEnter the length of the word: ");
            string str = Console.ReadLine();
            int num = int.Parse(str);
            for (int i = 0; i < strarr.Length; i++)
            {
                if(num == strarr[i].Length)
                {
                    strarr[i] = strarr[i].Substring(0, strarr[i].Length - 3) + "$$$";
                }
            }
            for (int i = 0; i < strarr.Length; i++)
            {
                Console.Write(strarr[i] + " ");
            }

            Console.Write("\nEnter the number to search for a word: ");
            str = Console.ReadLine();
            num = int.Parse(str);

            if (num >= 0 && num < strarr.Length)
            {
                string firstLetter = strarr[num - 1].Substring(0, 1);
                Console.WriteLine("First letter of word at index " + num + ": " + firstLetter);
            }
            else
            {
                Console.WriteLine("Invalid index. Index out of range.");
            }*/

            /*string str = "      Між словами може бути кілька пробілів, на початку і вкінці рядка також можуть бути пробіли.     ";
            Console.WriteLine(str);

            str = str.Trim();
            Console.WriteLine(str);
            string[] words = str.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string joinWords = string.Join('*', words);
            Console.WriteLine(joinWords);*/

            string word, lastWord;
            string[] words = new string[100];
            int index = 0;

            while (true)
            {
                Console.Write("Enter the word: ");
                word = Console.ReadLine();

                if (!word.EndsWith('.'))
                {
                    words[index] = word;
                    index++;
                }
                else
                {
                    lastWord = word;
                    words[index] = lastWord;
                    break;
                }
            }

            StringBuilder sentenceBuilder = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                sentenceBuilder.Append(words[i]);
                sentenceBuilder.Append(", ");
            }
            sentenceBuilder.Append(lastWord);

            string sentence = sentenceBuilder.ToString();
            Console.WriteLine("Resulting sentence: " + sentence);
        }
    }
}