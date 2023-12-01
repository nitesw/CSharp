using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace _Exam
{
    delegate void Functs(MyDictionary myDictionary);

    [Serializable]
    partial class MyDictionary
    {
        public string DictionaryName { get; set; }
        Dictionary<string, string[]> dict;

        public MyDictionary(string n)
        {
            dict = new Dictionary<string, string[]>();
            DictionaryName = n;
        }
    }

    internal class Program
    {
        public static void AddingWordsToDicts(List<MyDictionary> myDictionaries, string text)
        {
            foreach (var dictionary in myDictionaries)
            {
                string fileName = $"{text}{dictionary.DictionaryName}.bin";
                if (File.Exists(fileName))
                {
                    dictionary.LoadDictionary(text);
                }
                else
                {
                    if (dictionary.DictionaryName == "English-Ukrainian")
                    {
                        dictionary.WordsToEngDict();
                    }
                    else if (dictionary.DictionaryName == "Ukrainian-English")
                    {
                        dictionary.WordsToUkrDict();
                    }
                    dictionary.SaveDictionary(text);
                }
            }
        }
        public static void Menu(int choice, List<MyDictionary> myDictionaries)
        {
            Functs[] menus = new Functs[]
            {
                MyDictionary.EngDictMenu,
                MyDictionary.UkrDictMenu
            };

            menus[choice - 1]?.Invoke(myDictionaries[choice - 1]);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<MyDictionary> myDictionaries = new List<MyDictionary>()
            {
                new MyDictionary("English-Ukrainian"),
                new MyDictionary("Ukrainian-English")
            };
            AddingWordsToDicts(myDictionaries, "Main");

            try
            {
                int outerChoice;
                while (true)
                {
                    Console.WriteLine("\tWith which dictionary would you like to work?");
                    for (int i = 0; i < myDictionaries.Count; i++)
                    {
                        Console.WriteLine($"\t{i + 1}. {myDictionaries[i].DictionaryName}");
                    }
                    Console.WriteLine("\t0. Exit program");
                    Console.Write("Enter your choice: ");
                    outerChoice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (outerChoice > 0 && outerChoice < 3)
                        Menu(outerChoice, myDictionaries);
                    else if (outerChoice == 0)
                    {
                        Console.WriteLine("\tExiting program...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\tError! Exiting program...");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n\tError: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}