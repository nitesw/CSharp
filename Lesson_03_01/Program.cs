using System.Text;

namespace Lesson_03_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";
            Console.WriteLine(str.Length);

            str += ", world. Goodbye my friend!!!";
            Console.WriteLine(str.Length);

            StringBuilder builder = new StringBuilder();
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");

            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.AppendLine("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine($"Lenght: {builder.Length}");
            Console.WriteLine($"Capicity: {builder.Capacity}");

            Console.WriteLine(builder);
        }
    }
}