using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Exam
{
    partial class MyDictionary
    {
        public void AddWord(string word, params string[] translations)
        {
            if (!dict.ContainsKey(word))
            {
                dict.Add(word, translations);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tYou have already had word '{word}' in {DictionaryName} dictionary");
            }
        }
        public void ChangeWord(string word, string newWord)
        {
            if (dict.ContainsKey(word))
            {
                if (!dict.ContainsKey(newWord))
                {
                    string[] translations = dict[word];
                    dict.Remove(word);
                    dict[newWord] = translations;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\tYou have already had word '{word}' in {DictionaryName} dictionary");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tThere is no word '{word}' in {DictionaryName} dictionary");
            }
        }
        public void ChangeTranslations(string word, params string[] newTranslations)
        {
            if (dict.ContainsKey(word))
            {
                dict[word] = newTranslations;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tThere is no word '{word}' in {DictionaryName} dictionary");
            }
        }
        public void DeleteTranslation(string word, string translation)
        {
            if (dict.ContainsKey(word))
            {
                string[] translations = dict[word];
                List<string> updatedTranslations = new List<string>(translations);
                if (updatedTranslations.Contains(translation))
                {
                    if (updatedTranslations.Count > 1)
                    {
                        Console.Clear();
                        updatedTranslations.Remove(translation);
                        dict[word] = updatedTranslations.ToArray();
                        Console.WriteLine($"\tTranslation '{translation}' removed from the word '{word}'.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"\tCannot delete the last translation for the word '{word}'.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\tTranslation '{translation}' not found for the word '{word}'.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tThere is no word '{word}' in {DictionaryName} dictionary");
            }
        }
        public void DeleteWord(string word)
        {
            if (dict.Count >= 1)
            {
                if (dict.ContainsKey(word))
                {
                    dict.Remove(word);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\tThere is no word '{word}' in {DictionaryName} dictionary");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tYou don't have any words in {DictionaryName} dictionary");
            }
        }
        public void SearchForWord(string word)
        {
            if (dict.ContainsKey(word))
            {
                Console.Write($"\t\t{word} - ");
                string[] translations = dict[word];
                for (int i = 0; i < translations.Length; i++)
                {
                    Console.Write(translations[i]);
                    if (i < translations.Length - 1)
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write(".\n");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\tWord '{word}' not found in {DictionaryName} dictionary.");
            }
        }

        public void WordsToEngDict()
        {
            AddWord("apple", "яблуко", "яблука");
            AddWord("cat", "кіт", "коти");
            AddWord("house", "будинок", "дім");
            AddWord("car", "автомобіль");
            AddWord("book", "книга", "книжка");
            AddWord("computer", "комп'ютер");
            AddWord("table", "стіл", "таблиця", "настільний");
            AddWord("chair", "стілець", "крісло");
            AddWord("flower", "квітка");
            AddWord("pen", "ручка", "перо");
            AddWord("phone", "телефон", "апарат");
            AddWord("shoes", "взуття", "черевики", "підкрадулі");
            AddWord("friend", "друг", "приятель");
            AddWord("water", "вода");
            AddWord("tree", "дерево");
            AddWord("sun", "сонце");
            AddWord("moon", "місяць");
        }
        public void WordsToUkrDict()
        {
            AddWord("яблуко", "apple");
            AddWord("кіт", "cat");
            AddWord("будинок", "house", "home");
            AddWord("автомобіль", "car", "vehicle");
            AddWord("книга", "book");
            AddWord("комп'ютер", "computer");
            AddWord("стіл", "table", "desk");
            AddWord("стілець", "chair");
            AddWord("квітка", "flower", "blossom");
            AddWord("ручка", "pen");
            AddWord("телефон", "phone", "telephone", "mobile phone");
            AddWord("взуття", "shoes");
            AddWord("друг", "friend", "buddy", "broski");
            AddWord("вода", "water", "aqua");
            AddWord("дерево", "tree", "wood");
            AddWord("сонце", "sun");
            AddWord("місяць", "moon");
        }

        public override string ToString()
        {
            string result = $"\n\t==============={DictionaryName} Dictionary===============\n\n";
            foreach (var item in dict)
            {
                result += "\t\t" + item.Key + " - ";
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
            }
            return result;
        }
    }
}
