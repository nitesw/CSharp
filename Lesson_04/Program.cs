namespace Lesson_04
{
    public class MyClass
    {
        /*
        - private (default for fields in class)
        - public 
        - protected
        - internal (can only be seen in this project (class))
        - protected internal (can only be seen in this project (variables))
        - partial (classes only (realization can be made in other file))
         */
        private int number;
        private string name;
        private const float PI = 3.14f;
        private readonly int id;

        public MyClass()
        {
            this.id = 10;
        }
        public void Print()
        {
            Console.WriteLine($"Name: {name}. Id - {id}");
        }
        public override string ToString()
        {
            return $"Name: {name}. Id - {id}";
        }
    }

    /*class DerivedClass : MyClass
    {

    }*/

    struct _2DPoint
    {
        int x;
        int y;

        public void Print()
        {
            Console.WriteLine($"x: {x}, y: {y}");
        }
    }


    partial class Point
    {
        /*private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }*/
        //prop + TAB
        public string Name { get; set; }
        public string Type { get; }
        public string Color { get; private set; } = "Green";
        //propfull + TAB
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int xCoord;
        public int XCoord
        {
            get
            {
                return xCoord;
            }
            set
            {
                if (value >= 0)
                    xCoord = value;
                else
                    xCoord = 0;
            }
        }
        private int yCoord;
        public int YCoord
        {
            get
            {
                return yCoord;
            }
            set
            {
                if (value >= 0)
                    yCoord = value;
                else
                    yCoord = 0;
            }
        }

        static int count;
        static Point()
        {
            count = 0;
        }

        public Point(int value) : this(value, value) { count++; }

        public Point(int x, int y)
        {
            SetX(x);
            SetY(y);
            count++;
        }   

        public void SetX(int x)
        {
            if (x >= 0)
                xCoord = x;
            else
                xCoord = 0;
        }
        public void SetY(int y)
        {
            if (y >= 0)
                yCoord = y;
            else
                yCoord = 0;
        }
    }

    partial class Point
    {
        public int getX()
        {
            return xCoord;
        }
        public int getY()
        {
            return yCoord;
        }

        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"X: {xCoord}. Y: {yCoord}");
            Console.ResetColor();
        }
        public override string ToString()
        {
            return $"Name: {Name}. X: {xCoord}. Y: {yCoord}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            /*MyClass myClass = new MyClass();

            myClass.Print();
            Console.WriteLine(myClass);*/

            Console.SetCursorPosition(5, 5);
            Point point = new Point(-10, 2);
            point.Print();
            Console.WriteLine(point);

            point.SetX(25);
            point.SetY(-250);
            Console.WriteLine(point);

            Console.WriteLine(point.getX());
            Console.WriteLine(point.getY());

            point.XCoord = 100;
            Console.WriteLine(point.XCoord);
            Console.WriteLine(point);

            point.Name = "2D point";
            Console.WriteLine(point.Name);
            Console.WriteLine(point);

            Point point1 = new Point(9);
            Console.WriteLine(point1);
        }
    }
}