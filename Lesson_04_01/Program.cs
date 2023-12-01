using System.Reflection;

namespace Lesson_04_01
{
    partial class Freezer
    {
        private float width;

        public float Width
        {
            get { return width; }
            set { width = value > 0 ? value : 0; }
        }

        private float height;

        public float Height
        {
            get { return height; }
            set { height = value > 0 ? value : 0; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value > 0 ? value : 0; }
        }

        static string brand;
        static int count;

        public static int Count
        {
            get { return count; }
        }
        static Freezer()
        {
            count = 0;
            brand = "LG";
        }

        public Freezer()
        {
            width = 0;
            height = 0;
            model = "";
            year = 0;
            count++;
        }
        public Freezer(float w, float h) : this()
        {
            width = w;
            height = h;
        }
        public Freezer(float w, float h, string n) : this(w, h)
        {
            model = n;
        }
        public Freezer(float w, float h, string n, int y) : this(w, h, n)
        {
            year = y;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer[] freezers = new Freezer[5];

            /*freezers[0] = new Freezer(10.0f, 50.0f);
            freezers[0].Name = "LGL673";
            freezers[0].Year = 2015;
            Console.WriteLine(freezers[0]);*/

            float w, h;
            string m;
            int y;
            for (int i = 0; i < freezers.Length; i++)
            {
                Console.Write($"Enter the name of the freezer's model: ");
                string str = Console.ReadLine();
                m = str;
                Console.Write($"Enter the width of the freezer: ");
                str = Console.ReadLine();
                w = float.Parse(str);
                Console.Write($"Enter the height of the freezer: ");
                str = Console.ReadLine();
                h = float.Parse(str);
                Console.Write($"Enter the year of the freezer: ");
                str = Console.ReadLine();
                y = int.Parse(str);
                Console.Clear();

                freezers[i] = new Freezer(w, h, m, y);
            }
            for (int i = 0; i < freezers.Length; i++)
            {
                freezers[i].Print();
                Console.WriteLine();
            }
        }
    }
}