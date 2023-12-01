using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _Exam
{
    partial class MyDictionary
    {
        public void SortDict()
        {
            var query = from i in dict
                        orderby i.Key ascending
                        select i;

            Console.Clear();
            Console.WriteLine($"\n\t===============Sorted {DictionaryName} Dictionary===============\n");
            foreach (var item in query)
            {
                Console.Write("\t\t" + item.Key + " - ");
                string result = "";
                string[] translations = item.Value;
                for (int i = 0; i < translations.Length; i++)
                {
                    result += translations[i];
                    if (i < translations.Length - 1)
                    {
                        result += ", ";
                    }
                    else
                    {
                        result += ".\n";
                    }
                }
                Console.Write(result);
            }
        }
        public void ShowWordsWithMoreTrans()
        {
            Console.Clear();
            Console.Write("\tEnter the number of translations: ");
            int num = int.Parse(Console.ReadLine());
            if (num > 0)
            {
                var query = from i in dict
                            where i.Value.Length > num
                            select i;

                Console.Clear();
                if (query.Any())
                {
                    Console.WriteLine($"\n\t==============={DictionaryName} Dictionary===============\n");
                    Console.WriteLine($"\tWords with more than {num} translations: ");
                    foreach (var item in query)
                    {
                        Console.Write("\t\t" + item.Key + " - ");
                        string result = "";
                        string[] translations = item.Value;
                        for (int i = 0; i < translations.Length; i++)
                        {
                            result += translations[i];
                            if (i < translations.Length - 1)
                            {
                                result += ", ";
                            }
                            else
                            {
                                result += ".\n";
                            }
                        }
                        Console.Write(result);
                    }
                }
                else
                {
                    Console.WriteLine($"\tThere is no words with more than {num} translations.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\tYou've entered number that less than 0");
            }
        }
        public void ShowWordsWhichStartsWithLetter()
        {
            Console.Clear();
            Console.Write("\tEnter the letter to show the words which starts with it (1 character): ");
            string str = Console.ReadLine();

            if (str.Length == 1)
            {
                char letter = char.Parse(str);

                Regex regex = new Regex($"^{letter}.*$");

                Console.Clear();
                bool found = false;
                foreach (var word in dict.Keys)
                {
                    if (regex.IsMatch(word))
                    {
                        Console.Write("\t\t" + word + " - ");
                        string result = "";
                        string[] translations = dict[word];
                        for (int i = 0; i < translations.Length; i++)
                        {
                            result += translations[i];
                            if (i < translations.Length - 1)
                            {
                                result += ", ";
                            }
                            else
                            {
                                result += ".\n";
                            }
                        }
                        Console.Write(result);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"\tNo words start with the letter '{letter}'.");
                }
            }
            else
            {
                Console.WriteLine("\tYou've entered more than 1 character.");
            }
        }
    }
}
