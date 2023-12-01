namespace Lesson_12_01
{
    static class ExampleExtansion
    {
        public static int NumbersWord(this string data)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            return data.Split(new char[] { ' ', '.', ',', '!', ':' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static int NumberSymbol(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            int c = 0;
            foreach (char item in data)
            {
                if (item == s) ++c;
            }
            return c;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();
            Console.WriteLine($"Number of words in the string {str.NumbersWord()}");
            Console.WriteLine($"Number of symbol 'a' in the string {str.NumberSymbol('a')}");
        }
    }
}