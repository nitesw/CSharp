using System;

namespace Lesson_01_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("\tIt's easy to win forgiveness for being wrong;\n\t" + 
                "being right is what gets you into real trouble." + 
                "\n\tBjarne Stroustrup");*/

            /*int num, sum = 0, prod = 1, min = 0, max = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter the number: ");
                string str = Console.ReadLine();
                num = int.Parse(str);
                if(num > min && num > max)
                {
                    max = num;
                }
                else if(num < max)
                {
                    min = num;
                }
                sum += num;
                prod *= num;
            }
            Console.WriteLine($"Max num = {max}; Min num = {min}; Sum = {sum}; Product = {prod}");*/

            /*int a, num;
            Console.Write("Enter the 6-digits number: ");
            string str1 = Console.ReadLine();
            num = int.Parse(str1);
            if(num > 99999 && num < 1000000)
            {
                Console.Write("Reversed number: ");
                for (int i = 0; i < 6; i++)
                {
                    a = num % 10;
                    num /= 10;
                    Console.Write(a);
                }
            }
            else 
            {
                Console.WriteLine("You've entered wrong number!");
            }*/

            /*int num1 = 0, num2 = 1;
            Console.Write("Enter the maximum number of range: ");
            string str = Console.ReadLine();
            int maxNum = int.Parse(str);

            Console.WriteLine("Fibonacci range from 0 to " + maxNum + ":");

            if(num1 > num2)
            {
                int tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            while (num1 <= maxNum)
            {
                Console.WriteLine(num1);
                int tmp = num1;
                num1 = num2;
                num2 = tmp + num2;
            }*/

            /*int num1, num2;
            Console.Write("Enter the first number: ");
            string str = Console.ReadLine();
            num1 = int.Parse(str);
            Console.Write("Enter the second number: ");
            str = Console.ReadLine();
            num2 = int.Parse(str);
            if (num1 > num2)
            {
                int tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            for (int i = num1 - 1; i < num2; i++)
            {
                for (int j = 0; j < num1; j++)
                {
                    Console.Write(num1);
                }
                num1++;
                Console.WriteLine();
            }*/

            int choice;
            char symbol;
            Console.WriteLine("1. Horizontal printing");
            Console.WriteLine("2. Vertical printing");
            Console.Write("Enter your choice: ");
            string str = Console.ReadLine();
            choice = int.Parse(str);
            Console.Write("Enter the symbol to print: ");
            str = Console.ReadLine();
            symbol = char.Parse(str);
            switch (choice)
            {
                case 1:
                    int num;
                    Console.Write("Enter length of line: ");
                    str = Console.ReadLine();
                    num = int.Parse(str);
                    for (int i = 0; i < num; i++)
                    {
                        Console.Write(symbol);
                    }
                    break;
                case 2:
                    Console.Write("Enter length of line: ");
                    str = Console.ReadLine();
                    num = int.Parse(str);
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine(symbol);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}