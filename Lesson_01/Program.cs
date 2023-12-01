using System.Text;

namespace Lesson_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*//object obj = new object();
            Console.WriteLine("Hello World");

            Console.WriteLine("\tHello, \nWorld!");
            Console.WriteLine("Continue!!!");

            Console.Write("Enter number: ");
            string str = Console.ReadLine()!;
            Console.WriteLine(str + "!!!!");
            int number = int.Parse(str);
            Console.WriteLine(number + 5);
            Console.WriteLine("Your number is: " + number + 5 + "!!!");
            Console.WriteLine("Your number is: " + (number + 5) + "!!!");
            Console.WriteLine($"Your number is: {number + 5} !!!! {number}");

            int a = 0; //not null
            Console.WriteLine(a);
            //int b = null; //error
            //Nullable<int> b = null;
            int? b = null;
            b = 7;

            string address = null;
            string name = "Ivan";
            Console.WriteLine(name);*/

            Console.OutputEncoding = Encoding.UTF8;
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine($"ToShortTimeString: {now.ToShortTimeString()}");
            Console.WriteLine($"ToShortDateString: {now.ToShortDateString()}");
            Console.WriteLine($"ToLongTimeString: {now.ToLongTimeString()}");
            Console.WriteLine($"ToLongDateString: {now.ToLongDateString()}");
            Console.WriteLine($"Custom Date: {now.ToString("yyyy-MM-dd")}");

            int a = 3;
            float f1 = 4.15f;
            int i1 = 44;
            float f2 = f1 + i1;
            double d1 = f2;
            int i2 = (int)f2;

            Console.Write("Enter number: ");
            string str = Console.ReadLine()!;
            int number = int.Parse(str);
            Console.WriteLine(number);

            number = Convert.ToInt32(str);
            Console.WriteLine(number);

            try
            {
                str = Console.ReadLine();
                float number_float = Convert.ToSingle(str);
                Console.WriteLine(number_float);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int? b = null;
            string s = null;
            string s2 = s;

            if (s != null)
                s.ToUpper();
            s?.ToUpper();

            s2 = (s == null ? "Empty" : s);
            if (s == null)
            {
                s2 = "Empty";
            }
            else
            {
                s2 = s;
            }

            s2 = s ?? "Empty";

            Random rnd = new Random();
            Console.WriteLine(rnd.Next());//0...maxInt
            Console.WriteLine(rnd.Next(100));//0...100
            Console.WriteLine(rnd.Next(10, 50));//10...50
            Console.WriteLine(rnd.NextDouble());//0...1
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(-10, 10));
            }
            if(3 < 8)
            {
                Console.WriteLine("true");
            }
            for (int i = 0; i < 100; i++)
            {

            }
            while (true)
            {

            }
            do
            {

            } while (true);
        }
    }
}