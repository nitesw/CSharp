using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _Exam
{
    partial class MyDictionary
    {
        public void SaveWordToFile(string word)
        {
            if (dict.ContainsKey(word))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    using (Stream fstream = File.Create($"{word}.bin"))
                    {
                        formatter.Serialize(fstream, dict[word]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tWord '{word}' not found in {DictionaryName} dictionary.");
            }
        }
        public void LoadWordFromFile(string word)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                if (File.Exists($"{word}.bin"))
                {
                    if (!dict.ContainsKey(word))
                    {
                        using (Stream fstream = File.OpenRead($"{word}.bin"))
                        {
                            string[] translations = (string[])formatter.Deserialize(fstream);
                            Console.Clear();
                            Console.Write($"\tWord '{word}' - ");
                            for (int i = 0; i < translations.Length; i++)
                            {
                                Console.Write(translations[i]);
                                if (i < translations.Length - 1)
                                {
                                    Console.Write(", ");
                                }
                                else
                                {
                                    Console.WriteLine($" loaded from {DictionaryName} dictionary.");
                                }
                            }
                            dict.Add(word, translations);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"\tSorry, you've already had word - '{word}' in {DictionaryName} dictionary.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\tWord '{word}' file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n\tError: " + ex.Message);
                Console.ResetColor();
            }
        }
        public void SaveDictionary(string text)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream fstream = File.Create($"{text}{DictionaryName}.bin"))
                {
                    formatter.Serialize(fstream, this);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n\tError: " + ex.Message);
                Console.ResetColor();
            }
        }
        public void LoadDictionary(string text)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                MyDictionary loadedDictionary = null;
                using (Stream fstream = File.OpenRead($"{text}{DictionaryName}.bin"))
                {
                    loadedDictionary = (MyDictionary)formatter.Deserialize(fstream);
                }
                if (loadedDictionary != null)
                {
                    this.dict = loadedDictionary.dict;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n\tError: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
