using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Exam
{
    partial class MyDictionary
    {
        public static void UkrDictMenu(MyDictionary myDictionary)
        {
            int choice;
            do
            {
                Console.WriteLine($"\n\t==============={myDictionary.DictionaryName} Dictionary===============");
                Console.WriteLine($"\n\t1. Print the {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t2. Add word to {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t3. Change word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t4. Change translitions in word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t5. Delete translation or word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t6. Search for word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t7. Functs that don't affect {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t8. Save or Load word from {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t9. Save or Load dictionary from {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t0. Return to dictionary selection");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(myDictionary);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("\tEnter the word to add: ");
                        string str = Console.ReadLine();

                        Console.Write("\tEnter the number of translations: ");
                        int numTranslations = int.Parse(Console.ReadLine());

                        string[] translations = new string[numTranslations];

                        for (int i = 0; i < numTranslations; i++)
                        {
                            Console.Write($"\tEnter translation {i + 1}: ");
                            translations[i] = Console.ReadLine();
                        }

                        myDictionary.AddWord(str, translations);
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("\tEnter the word to change: ");
                        str = Console.ReadLine();

                        Console.Write("\tEnter new word: ");
                        string newWord = Console.ReadLine();

                        myDictionary.ChangeWord(str, newWord);
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("\tEnter the word to change translations in: ");
                        str = Console.ReadLine();

                        Console.Write("\tEnter the number of translations (more that 0 and less than 5): ");
                        numTranslations = int.Parse(Console.ReadLine());

                        if (numTranslations < 0 || numTranslations > 6)
                        {
                            Console.Clear();
                            Console.WriteLine("\tNumber of translations is less than 0 or more than 5");
                            break;
                        }
                        else
                        {
                            translations = new string[numTranslations];
                            for (int i = 0; i < numTranslations; i++)
                            {
                                Console.Write($"\tEnter translation {i + 1}: ");
                                translations[i] = Console.ReadLine();
                            }

                            myDictionary.ChangeTranslations(str, translations);
                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("\t1. Delete translation in a word");
                        Console.WriteLine("\t2. Delete a word");
                        Console.Write("\tEnter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("\tEnter the word to delete translation in: ");
                                str = Console.ReadLine();

                                Console.Write($"\tEnter translation: ");
                                string translation = Console.ReadLine();

                                myDictionary.DeleteTranslation(str, translation);
                                break;

                            case 2:
                                Console.Clear();
                                Console.Write("\tEnter the word to delete: ");
                                str = Console.ReadLine();

                                myDictionary.DeleteWord(str);
                                break;

                            default:
                                Console.Clear();
                                break;
                        }
                        
                        break;

                    case 6:
                        Console.Clear();
                        Console.Write("\tEnter the word to search for: ");
                        str = Console.ReadLine();

                        myDictionary.SearchForWord(str);
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine($"\t1. Sort {myDictionary.DictionaryName} dictionary");
                        Console.WriteLine($"\t2. Show words with more translations than entered in " +
                            $"{myDictionary.DictionaryName} dictionary");
                        Console.WriteLine($"\t3. Show words which starts with entered letter in " +
                            $"{myDictionary.DictionaryName} dictionary");
                        Console.Write("\tEnter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                myDictionary.SortDict();
                                break;

                            case 2:
                                myDictionary.ShowWordsWithMoreTrans();
                                break;

                            case 3:
                                myDictionary.ShowWordsWhichStartsWithLetter();
                                break;

                            default:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("\t1. Save word to file");
                        Console.WriteLine("\t2. Load word from file");

                        Console.Write("Enter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("\tEnter the word to save to file: ");
                                str = Console.ReadLine();

                                myDictionary.SaveWordToFile(str);
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("\tEnter the word to load from file: ");
                                str = Console.ReadLine();

                                myDictionary.LoadWordFromFile(str);
                                break;

                            default:
                                break;
                        }

                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("\t1. Save dictionary");
                        Console.WriteLine("\t2. Load dictionary");

                        Console.Write("Enter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();

                                myDictionary.SaveDictionary("New");
                                break;
                            case 2:
                                Console.Clear();

                                myDictionary.LoadDictionary("New");
                                break;

                            default:
                                break;
                        }

                        break;

                    case 0:
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (choice != 0);
        }
        public static void EngDictMenu(MyDictionary myDictionary)
        {
            int choice;
            do
            {
                Console.WriteLine($"\n\t==============={myDictionary.DictionaryName} Dictionary===============");
                Console.WriteLine($"\n\t1. Print the {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t2. Add word to {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t3. Change word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t4. Change translitions in word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t5. Delete translation or word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t6. Search for word in {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t7. Functs that don't affect {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t8. Save or Load word from {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t9. Save or Load dictionary from {myDictionary.DictionaryName} dictionary");
                Console.WriteLine($"\t0. Return to dictionary selection");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(myDictionary);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("\tEnter the word to add: ");
                        string str = Console.ReadLine();

                        Console.Write("\tEnter the number of translations: ");
                        int numTranslations = int.Parse(Console.ReadLine());

                        string[] translations = new string[numTranslations];

                        for (int i = 0; i < numTranslations; i++)
                        {
                            Console.Write($"\tEnter translation {i + 1}: ");
                            translations[i] = Console.ReadLine();
                        }

                        myDictionary.AddWord(str, translations);
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("\tEnter the word to change: ");
                        str = Console.ReadLine();

                        Console.Write("\tEnter new word: ");
                        string newWord = Console.ReadLine();

                        myDictionary.ChangeWord(str, newWord);
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("\tEnter the word to change translations in: ");
                        str = Console.ReadLine();

                        Console.Write("\tEnter the number of translations (more that 0 and less than 5): ");
                        numTranslations = int.Parse(Console.ReadLine());

                        if (numTranslations < 0 || numTranslations > 6)
                        {
                            Console.Clear();
                            Console.WriteLine("\tNumber of translations is less than 0 or more than 5");
                            break;
                        }
                        else
                        {
                            translations = new string[numTranslations];
                            for (int i = 0; i < numTranslations; i++)
                            {
                                Console.Write($"\tEnter translation {i + 1}: ");
                                translations[i] = Console.ReadLine();
                            }

                            myDictionary.ChangeTranslations(str, translations);
                        }
                        break;

                    case 5:

                        Console.Clear();
                        Console.WriteLine("\t1. Delete translation in a word");
                        Console.WriteLine("\t2. Delete a word");
                        Console.Write("\tEnter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("\tEnter the word to delete translation in: ");
                                str = Console.ReadLine();

                                Console.Write($"\tEnter translation: ");
                                string translation = Console.ReadLine();

                                myDictionary.DeleteTranslation(str, translation);
                                break;

                            case 2:
                                Console.Clear();
                                Console.Write("\tEnter the word to delete: ");
                                str = Console.ReadLine();

                                myDictionary.DeleteWord(str);
                                break;

                            default:
                                Console.Clear();
                                break;
                        }

                        break;

                    case 6:
                        Console.Clear();
                        Console.Write("\tEnter the word to search for: ");
                        str = Console.ReadLine();

                        myDictionary.SearchForWord(str);
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine($"\t1. Sort {myDictionary.DictionaryName} dictionary");
                        Console.WriteLine($"\t2. Show words with more translations than entered in " +
                            $"{myDictionary.DictionaryName} dictionary");
                        Console.WriteLine($"\t3. Show words which starts with entered letter in " +
                            $"{myDictionary.DictionaryName} dictionary");
                        Console.Write("\tEnter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                myDictionary.SortDict();
                                break;

                            case 2:
                                myDictionary.ShowWordsWithMoreTrans();
                                break;

                            case 3:
                                myDictionary.ShowWordsWhichStartsWithLetter();
                                break;

                            default:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("\t1. Save word to file");
                        Console.WriteLine("\t2. Load word from file");

                        Console.Write("Enter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("\tEnter the word to save to file: ");
                                str = Console.ReadLine();

                                myDictionary.SaveWordToFile(str);
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("\tEnter the word to load from file: ");
                                str = Console.ReadLine();

                                myDictionary.LoadWordFromFile(str);
                                break;

                            default:
                                break;
                        }

                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("\t1. Save dictionary");
                        Console.WriteLine("\t2. Load dictionary");

                        Console.Write("Enter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();

                                myDictionary.SaveDictionary("New");
                                break;
                            case 2:
                                Console.Clear();

                                myDictionary.LoadDictionary("New");
                                break;

                            default:
                                break;
                        }

                        break;

                    case 0:
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (choice != 0);
        }
    }
}
