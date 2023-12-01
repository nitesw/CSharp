namespace Lesson_05
{
    using _2D_Objects;
    using System;

    partial struct MyStruct
    {
        public int MyProperty { get; set; }
    }

    partial struct MyStruct
    {
        public int MyProperty1 { get; set; }
    }

    struct Point
    {
        public int X { get; set; }//private int x 
        public int Y { get; set; }//private int y

        public void Print()
        {
            Console.WriteLine($"Lesson_05. x: {X}, y: {Y}");
        }
    }

    class Rectangle
    {
        private int height;

        public int Height
        {
            get { return height; }
            set
            { 
                if(value < 0)
                {
                    throw new ArgumentException("Invalid height");
                }
                height = value;
            }
        }

        public int Width { get; set; }

        public Rectangle(int h, int w)
        {
            Height = h;
            Width = w;
        }
        public void Print()
        {
            Console.WriteLine($"Width: {Width}, Height: {Height}");
        }
    }

    internal class Program
    {
        //params - set many parameters
        static void MethodWithParams(string name, params int[] marks)
        {
            Console.WriteLine("------------" + name + "------------");
            foreach (var item in marks)
            {
                Console.WriteLine(item + " ");
                Console.WriteLine();
            }
        }

        static void Modify(ref int num, ref string str, ref Point point)
        {
            num += 1;
            str += "!";

            point.X++;
            point.Y++;
        }

        /*static void GetCurrentTime(ref int hours, ref int minutes, ref int sec)
        {
            hours = DateTime.Now.Hour;
            minutes = DateTime.Now.Minute;
            sec = DateTime.Now.Second;
        }*/
        static void GetCurrentTime(out int hours, out int minutes, out int sec)
        {
            hours = DateTime.Now.Hour;
            minutes = DateTime.Now.Minute;
            sec = DateTime.Now.Second;
        }

        static void Main(string[] args)
        {
            /*Point point = new Point();
            point.Print();

            _2D_Objects.Point point1 = new _2D_Objects.Point();
            point1.Print();

            _3D_Objects.Point point2 = new _3D_Objects.Point();
            point2.Print();*/

            /*string name = "Andrii";
            int[] marks = { 11, 12, 10, 8, 9, 7 };
            MethodWithParams(name, marks);
            MethodWithParams("Bob", 12, 4, 12, 11, 5, 6, 8, 1);*/

            /*int num = 10;
            string str = "Hello academy";
            Point point = new Point { X = 5, Y = 5 };
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            point.Print();
            Modify(ref num, ref str, ref point);
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            point.Print();*/

            /*//int h = 0, m = 0, s = 0;
            //Console.WriteLine($"Time {h}:{m}:{s}");
            //GetCurrentTime(ref h, ref m, ref s);
            //Console.WriteLine($"Time {h}:{m}:{s}");

            int h, m, s;
            //Console.WriteLine($"Time {h}:{m}:{s}");
            GetCurrentTime(out h, out m, out s);
            Console.WriteLine($"Time {h}:{m}:{s}");*/

            Point point = new Point();
            point.Print();

            try
            {
                Rectangle rectangle = new Rectangle(-10, 15);
                rectangle.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument exception");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

namespace _2D_Objects
{
    struct Point
    {
        public int X { get; set; }//private int x 
        public int Y { get; set; }//private int y

        public void Print()
        {
            Console.WriteLine($"_2D_Objects. x: {X}, y: {Y}");
        }
    }
}
namespace _3D_Objects
{
    struct Point
    {
        public int X { get; set; }//private int x 
        public int Y { get; set; }//private int y

        public void Print()
        {
            Console.WriteLine($"_3D_Objects. x: {X}, y: {Y}");
        }
    }
}