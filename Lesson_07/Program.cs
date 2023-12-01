using System.Reflection.Metadata.Ecma335;

namespace Lesson_07
{
    class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() : this(0, 0, 0) { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point: x = {X}, y = {Y}, z = {Z}";
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() : this(0, 0) { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"Point: x = {X}, y = {Y}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        #region Uno Operators
        public static Point operator -(Point p)
        {
            Point pNew = new Point
            {
                X = p.X * -1,
                Y = p.Y * -1
            };
            return pNew;
        }

        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }

        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }
        #endregion

        #region Binary operators
        public static Point operator +(Point p1, Point p2)
        { 
            Point p3 = new Point
            { 
                X = p1.X + p2.X, 
                Y = p1.Y + p2.X
            };
            return p3;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.X
            };
            return p3;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.X
            };
            return p3;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.X
            };
            return p3;
        }
        #endregion

        #region Operator Equals
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            //return !p1.Equals(p2);
            return !(p1 == p2);
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X + p1.Y > p2.X + p2.Y;
        }
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X + p1.Y < p2.X + p2.Y;
        }
        public static bool operator >=(Point p1, Point p2)
        {
            return p1.X + p1.Y >= p2.X + p2.Y;
        }
        public static bool operator <=(Point p1, Point p2)
        {
            return p1.X + p1.Y <= p2.X + p2.Y;
        }
        #endregion
        #region true/false operators
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0;
            //return p != null;
        }
        public static bool operator false(Point p)
        {
            return p.X == 0 || p.Y == 0;
            //return p != null;
        }
        #endregion
        #region Type cast
        /*public static explicit operator int(Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator double(Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator Point3D(Point p)
        {
            return new Point3D(p.X, p.Y, 0);
        }*/
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*Point test = new Point(1, 2);
            Console.WriteLine(test);
            int a = (int)test;
            Console.WriteLine(a);
            double b = test;
            Console.WriteLine(b);
            Point3D point = test;
            Console.WriteLine(point);*/

            Point p1 = new Point(0, 0);
            Point p2 = new Point(1, 1);
            Console.WriteLine(p1);

            if (p1)
            {
                Console.WriteLine("Point p1 is true");
            }
            else
            {
                Console.WriteLine("Point p1 is false");
            }

            Console.WriteLine(-p1);
            Point res = -p1;
            Console.WriteLine(res);

            Console.WriteLine(p1++);
            Console.WriteLine(++p1);
            Console.WriteLine(p1--);
            Console.WriteLine(--p1);

            Console.WriteLine($"Point 1: {p1}");
            Console.WriteLine($"Point 2: {p2}");
            res = p1 + p2;
            Console.WriteLine(res);
            res = p1 - p2;
            Console.WriteLine(res);
            res = p1 * p2;
            Console.WriteLine(res);
            res = p1 / p2;
            Console.WriteLine(res);

            if(p1 == p2)
                Console.WriteLine("Point is equal");
            else
                Console.WriteLine("Point is not equal");

            if (p1 > p2)
                Console.WriteLine("Point p1 > p2");
            else
                Console.WriteLine("Point p1 < p2");
        }
    }
}