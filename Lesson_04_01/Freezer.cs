using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson_04_01
{
    partial class Freezer
    {
        public void Print()
        {
            Console.WriteLine($"Freezer brand: {brand}\nName of the model: {model}\nMade in {year}" +
                $"\nHeight and width: {height}, {width}\nAmount of fridges: {count}");
        }
        public override string ToString()
        {
            return $"Freezer brand: {brand}\nName of the model: {model}\nMade in {year}" +
                $"\nHeight and width: {height}, {width}\nAmount of fridges: {count}";
        }
    }
}
