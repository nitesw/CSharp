using System.Text;

namespace Lesson_13_01
{
    class PhoneBook
    {
        Dictionary<string, long> phoneBook = new Dictionary<string, long>();

        public void AddToPhoneBook(string name, long number)
        {
            phoneBook.Add(name, number);
        }
        public void ChangeNumberByName(string name, long number)
        {
            if(phoneBook.ContainsKey(name))
            {
                phoneBook[name] = number;
            }
            else
            {
                Console.WriteLine("You don't have this name in your phone book!");
            }
        }
        public void SearchNumberByName(string name)
        {
            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine(phoneBook[name]);
            }
            else
            {
                Console.WriteLine("You don't have this name in your phone book!");
            }
        }
        public void DeleteByName(string name)
        {
            if (phoneBook.ContainsKey(name))
            {
                phoneBook.Remove(name);
            }
            else
            {
                Console.WriteLine("You don't have this name in your phone book!");
            }
        }
        public void PrintPhoneBook()
        {
            foreach (var p in phoneBook)
            {
                Console.WriteLine(p.Key + " - " + p.Value);
            }
        }
    }

    class Statistics
    {
        Dictionary<string, int> statistics = new Dictionary<string, int>();

        public void StatistizeMyText(string text)
        {
            string[] splittedText = text.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in splittedText)
            {
                if(statistics.ContainsKey(word))
                {
                    statistics[word]++;
                }
                else
                {
                    statistics.Add(word, 1);
                }
            }
            int i = 0;
            foreach (var word in statistics)
            {
                Console.WriteLine(i++ + 1 + ". " + word.Key + " - " + word.Value);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            /*PhoneBook phoneBook = new PhoneBook();

            phoneBook.AddToPhoneBook("Andrew", 111901234);
            phoneBook.AddToPhoneBook("Nick", 158601234);
            phoneBook.AddToPhoneBook("Bob", 103101234);

            phoneBook.PrintPhoneBook();

            Console.WriteLine("=================================================");
            phoneBook.ChangeNumberByName("Nick", 102101234);
            phoneBook.ChangeNumberByName("Olga", 104101234);

            phoneBook.PrintPhoneBook();

            Console.WriteLine("=================================================");
            phoneBook.SearchNumberByName("Andrew");
            phoneBook.SearchNumberByName("Josh");

            Console.WriteLine("=================================================");
            phoneBook.DeleteByName("Bob");
            phoneBook.DeleteByName("Jonh");

            phoneBook.PrintPhoneBook();*/

            Statistics statistics = new Statistics();
            statistics.StatistizeMyText("Ось будинок, який збудував Джек. А це пшениця, " +
                "яка у темній коморі зберігається у будинку, який збудував Джек. " +
                "А це веселий птах-синиця, який часто краде пшеницю, " +
                "яка в темній коморі зберігається у будинку,який збудував Джек.");
        }
    }
}