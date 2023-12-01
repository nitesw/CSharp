using System.Text.RegularExpressions;

namespace Lesson_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\d";
            Regex regex = new Regex(pattern);
            bool flag = true;
            /*while (flag)
            {
                string str = Console.ReadKey().KeyChar.ToString();
                if (str == " ") flag = false;

                bool success = regex.IsMatch(str);
                Console.WriteLine(success ? $" match found \"{pattern}\"" : $" match not found \"{pattern}\"");
            }*/

            //pattern = @"\d+";
            //pattern = @"\D+";
            //pattern = @"^\d+";
            //pattern = @"\d+$";
            pattern = @"^\d+$";
            regex = new Regex(pattern);
            var arr = new[] { "test", "123", "test123test", "123test", "test123" };

            foreach (var item in arr)
            {
                Console.WriteLine(regex.IsMatch(item) ? $"String \"{pattern}\" matched" : $"String \"{pattern}\" not matched");
            }

            pattern = @"^[A-Z]+[a-z]*$";
            regex = new Regex(pattern);

            while (true)
            {
                Console.Write("Enter string: ");
                string input = Console.ReadLine();

                if (input == "exit") break;
                Console.WriteLine(input != null && regex.IsMatch(input) ? $"String \"{pattern}\" matched" : $"String \"{pattern}\" not matched");
            }

            string value = "4 - 5 AND 5 y 789";
            Match match = Regex.Match(value, @"\d");

            /*if(match.Success)
            {
                Console.WriteLine(match.Value);
            }
            match = match.NextMatch();*/

            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }

            Match m = Regex.Match("123 Axx-1\n-xxy \n Axyx-2xyyxy", @"A.*y");
            if(m.Success)
            {
                Console.WriteLine(m.Value);
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Length);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Value);
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Length);
            }

            string value1 = "saidsaid said shed shed see sprear spread super";
            MatchCollection matches = Regex.Matches(value1, @"s\w+d");
            Console.WriteLine("\n=====================================");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Index: {item.Index}, Value: {item.Value}");
            }

            string inputString = "Don't replace Dot Net replaced Net Net dots";
            string output = Regex.Replace(inputString, "N.t", "NET");
            Console.WriteLine(inputString);
            Console.WriteLine(output);
        }
    }
}