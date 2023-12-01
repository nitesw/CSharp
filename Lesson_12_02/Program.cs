namespace Lesson_12_02
{
    static class Extensions
    {
        public static bool IsPalindrome(this string data)
        {
            bool isPalindrome = true;

            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] != data[data.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }
        public static string CodeWords(this string data, int key)
        {
            char[] result = new char[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                char originalChar = data[i];
                char encodedChar = (char)(originalChar + key);
                result[i] = encodedChar;
            }

            return new string(result);
        }
        public static int FindSameNums(this int[] data)
        {
            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[i] == data[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            return count + 1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "dad";
            Console.WriteLine(str.IsPalindrome());
            string newStr = str.CodeWords(2);
            Console.WriteLine(newStr);

            int[] arr = new int[] { 1, 1, 1, 4, 5, 2, 1, 6, 7, 9 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Same nums: " + arr.FindSameNums());
        }
    }
}