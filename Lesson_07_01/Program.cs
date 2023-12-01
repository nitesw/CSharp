using System.Drawing;

namespace Lessson_07_01
{
    class Square
    {
        public int A { get; set; }

        public Square(): this(0) { }
        public Square(int a)
        {
            A = a;
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square &&
                   A == square.A;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(A);
        }
        public override string ToString()
        {
            return $"Length of the side: {A}";
        }

        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }
        public static Square operator --(Square s)
        {
            s.A--;
            return s;
        }

        public static Square operator +(Square s1, Square s2)
        {
            Square s3 = new Square
            {
                A = s1.A + s2.A,
            };
            return s3;
        }
        public static Square operator -(Square s1, Square s2)
        {
            Square s3 = new Square
            {
                A = s1.A - s2.A,
            };
            return s3;
        }
        public static Square operator *(Square s1, Square s2)
        {
            Square s3 = new Square 
            {
                A = s1.A * s2.A,
            };
            return s3;
        }
        public static Square operator /(Square s1, Square s2)
        {
            Square s3 = new Square
            {
                A = s1.A / s2.A,
            };
            return s3;
        }

        public static bool operator ==(Square s1, Square s2)
        {
            return s1.Equals(s2);
        }
        public static bool operator !=(Square s1, Square s2)
        {
            return !(s1 == s2);
        }
        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }
        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }
        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }
        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A<= s2.A;
        }

        public static bool operator true(Square s)
        {
            return s.A != 0;
        }
        public static bool operator false(Square s)
        {
            return s.A == 0;
        }

        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.A, 0);
        }
        public static explicit operator int(Square s)
        {
            return s.A;
        }
    }
    class Rectangle
    {
        public int A { get; set; }
        public int B { get; set; }

        public Rectangle() : this(0, 0) { }
        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public override string ToString()
        {
            return $"Width: {A}. Height: {B}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle &&
                   A == rectangle.A &&
                   B == rectangle.B;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }

        public static Rectangle operator ++(Rectangle r)
        {
            r.A++;
            r.B++;
            return r;
        }
        public static Rectangle operator --(Rectangle r)
        {
            r.A--;
            r.B--;
            return r;
        }

        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            Rectangle r3 = new Rectangle
            {
                A = r1.A + r2.A,
                B = r1.B + r2.B
            };
            return r3;
        }
        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            Rectangle r3 = new Rectangle
            {
                A = r1.A - r2.A,
                B = r1.B - r2.B
            };
            return r3;
        }
        public static Rectangle operator *(Rectangle r1, Rectangle r2)
        {
            Rectangle r3 = new Rectangle
            {
                A = r1.A * r2.A,
                B = r1.B * r2.B
            };
            return r3;
        }
        public static Rectangle operator /(Rectangle r1, Rectangle r2)
        {
            Rectangle r3 = new Rectangle
            {
                A = r1.A / r2.A,
                B = r1.B / r2.B
            };
            return r3;
        }

        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            return r1.Equals(r2);
        }
        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }
        public static bool operator >(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B > r2.A + r2.B;
        }
        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B < r2.A + r2.B;
        }
        public static bool operator >=(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B >= r2.A + r2.B;
        }
        public static bool operator <=(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B <= r2.A + r2.B;
        }

        public static bool operator true(Rectangle r)
        {
            return r.A != 0 || r.B != 0;
        }
        public static bool operator false(Rectangle r)
        {
            return r.A == 0 || r.B == 0;
        }

        /*public static explicit operator Square(Rectangle r)
        {
            return new Square(r.A);
        }
        public static implicit operator int(Rectangle r)
        {
            return r.A + r.B;
        }*/
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Square sq1 = new Square(2);
            Square sq2 = new Square(3);

            Console.WriteLine($"Square 1: " + sq1);
            Console.WriteLine($"Square 2: " + sq2);
            if(sq1)
            {
                Console.WriteLine("Sq1 is true");
            }
            else
            {
                Console.WriteLine("Sq1 is false");
            }
            Console.WriteLine(sq1++);
            Console.WriteLine(sq1--);
            Console.WriteLine("-----------------------------");
            Square res = sq1 + sq2;
            Console.WriteLine(res);
            res = sq1 - sq2;
            Console.WriteLine(res);
            res = sq1 * sq2;
            Console.WriteLine(res);
            res = sq1 / sq2;
            Console.WriteLine(res);

            if(sq1 == sq2)
            {
                Console.WriteLine("Squares are equal");
            }
            else
            {
                Console.WriteLine("Squares are not equal");
            }
            if(sq1 > sq2)
            {
                Console.WriteLine("sq1 > sq2");
            }
            else
            {
                Console.WriteLine("sq1 < sq2");
            }
            /*int sq = (int)sq1;
            Console.WriteLine(sq);
            Rectangle test = sq1;
            Console.WriteLine(test);*/

            Console.WriteLine();
            Console.WriteLine();
            Rectangle rect1 = new Rectangle(1, 1);
            Rectangle rect2 = new Rectangle(2, 2);

            Console.WriteLine($"Rectangle 1: " + rect1);
            Console.WriteLine($"Rectangle 2: " + rect2);

            if (rect1)
            {
                Console.WriteLine("Rect1 is true");
            }
            else
            {
                Console.WriteLine("Rect1 is false");
            }
            Console.WriteLine(rect1++);
            Console.WriteLine(rect1--);
            Console.WriteLine("-----------------------------");
            Rectangle res1 = rect1 + rect2;
            Console.WriteLine(res1);
            res1 = rect1 - rect2;
            Console.WriteLine(res1);
            res1 = rect1 * rect2;
            Console.WriteLine(res1);
            res1 = sq1 / rect2;
            Console.WriteLine(res1);

            if (rect1 == rect2)
            {
                Console.WriteLine("Rectangles are equal");
            }
            else
            {
                Console.WriteLine("Rectangles are not equal");
            }
            if (rect1 > rect2)
            {
                Console.WriteLine("sq1 > sq2");
            }
            else
            {
                Console.WriteLine("sq1 < sq2");
            }
            /*int rect = rect1;
            Console.WriteLine(rect.ToString());
            Rectangle test = rect1;
            Console.WriteLine(test.ToString());*/
        }
    }
}