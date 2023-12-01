using System.Text.RegularExpressions;

namespace Lesson_17_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string task1 = "asflksj3.14 as';ljfoids4,12's;ald o[po[prw-0.1 a's;ld'sa;ld3,33aasdl'; as'dl';asd1.11";
            MatchCollection matches = Regex.Matches(task1, @"\d+\.\d+|\d+\,\d+");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Index: {item.Index}, Value: {item.Value}");
            }

            string task2 = "asdk;alsdk1 aspd[o342 ;l'aksjdj23 aslkdj 57 ;'laskd123k;lfkl;sdf 80;lk ;aslkd69;lk;l'kds";
            matches = Regex.Matches(task2, @"\d");
            List<int> numbers = new List<int>();

            foreach (Match item in matches)
            {
                if (int.TryParse(item.Value, out int number))
                {
                    numbers.Add(number);
                }
            }
            Console.Write("\nList of nums: ");
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}