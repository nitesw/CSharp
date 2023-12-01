namespace Lesson_08_02
{
    abstract class GeometricShape
    {
        protected int side1;

        public GeometricShape()
        {
            side1 = 0;
        }
        public GeometricShape(int s)
        {
            side1 = s >= 0 ? s : 0;
        }

        public abstract double GetArea();
        public abstract int GetPerimeter();
        public abstract void Print();
    }

    class Triangle : GeometricShape
    {
        private int side2, side3;

        public Triangle() :base()
        {
            side2 = 0;
            side3 = 0;
        }
        public Triangle(int s1, int s2, int s3) :base(s1)
        {
            side2 = s2 >= 0 ? s2 : 0;
            side3 = s3 >= 0 ? s3 : 0;
        }

        public sealed override int GetPerimeter()
        {
            int perimeter = side1 + side2 + side3;
            return perimeter;
        }
        public sealed override double GetArea()
        {
            double s = (double)(side1 + side2 + side3) / 2;
            double area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Triangle-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Square : GeometricShape
    {
        public Square() :base()
        {

        }
        public Square(int s) :base(s) { }

        public sealed override int GetPerimeter()
        {
            int perimeter = side1 * 4;
            return perimeter;
        }
        public sealed override double GetArea()
        {
            double area = side1 * side1 * side1 * side1;
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Square-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Rectangle : GeometricShape
    {
        private int side2;

        public Rectangle() :base()
        {
            side2 = 0;
        }
        public Rectangle(int s1, int s2) :base(s1)
        {
            side2 = s2 >= 0 ? s2 : 0;
        }

        public sealed override int GetPerimeter()
        {
            int perimeter = (side1 + side2) * 2;
            return perimeter;
        }
        public sealed override double GetArea()
        {
            double area = side1 * side2;
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Rectangle-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Rhombus : GeometricShape
    {
        public Rhombus() :base()
        {

        }
        public Rhombus(int s) : base(s) {}

        public sealed override int GetPerimeter()
        {
            int perimeter = side1 * 4;
            return perimeter;
        }
        public sealed override double GetArea()
        {
            double area = (side1 * side1) / 2.0;
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Rhombus-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Parallelogram : GeometricShape
    {
        private int side2;

        public Parallelogram() : base()
        {
            side2 = 0;
        }
        public Parallelogram(int s1, int s2) : base(s1)
        {
            side2 = s2 >= 0 ? s2 : 0;
        }

        public sealed override int GetPerimeter()
        {
            int perimeter = (side1 + side2) * 2;
            return perimeter;
        }
        public sealed override double GetArea()
        {
            double area = side1 * side2;
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Parallelogram-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Trapeze : GeometricShape
    {
        private int side2, side3, side4;

        private int height;

        public int Height
        {
            get { return height; }
            set 
            { 
                height = value >= 0 ? value : 0; 
            }
        }

        public Trapeze() :base()
        {
            side2 = 0;
            side3 = 0;
            side4 = 0;
        }
        public Trapeze(int s1, int s2, int s3, int s4) :base(s1)
        {
            side2 = s2 >= 0 ? s2 : 0;
            side3 = s3 >= 0 ? s3 : 0;
            side4 = s4 >= 0 ? s4 : 0;
        }

        public sealed override int GetPerimeter()
        {
            int perimeter = side1 + side2 + side3 + side4;
            return perimeter;
        }
        public sealed override double GetArea()
        {
            double area = ((side1 + side2) * height) / 2.0;
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Trapeze-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Circle : GeometricShape
    {
        public Circle() : base()
        {

        }
        public Circle(int s) : base(s) { }

        public sealed override int GetPerimeter()
        {
            double perimeter = 2 * Math.PI * side1;
            return (int)Math.Round(perimeter);
        }
        public sealed override double GetArea()
        {
            double area = Math.PI * side1 * side1;
            return area;
        }
        public sealed override void Print()
        {
            Console.WriteLine($"-----Circle-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }
    class Ellipse : GeometricShape
    {
        private int side2;

        public Ellipse() : base()
        {
            side2 = 0;
        }

        public Ellipse(int s1, int s2) : base(s1)
        {
            side2 = s2 > 0 ? s2 : 0;
        }

        public sealed override int GetPerimeter()
        {
            double h = Math.Pow((side1 - side2) / (side1 + side2), 2);
            double perimeter = Math.PI * (side1 + side2) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
            return (int)Math.Round(perimeter);
        }

        public sealed override double GetArea()
        {
            double area = Math.PI * side1 * side2;
            return area;
        }

        public sealed override void Print()
        {
            Console.WriteLine($"-----Ellipse-----\nPerimeter: {GetPerimeter()}\nArea: {GetArea()}");
        }
    }

    class CompositeShape : GeometricShape
    {
        private GeometricShape[] shapes;

        public CompositeShape(params GeometricShape[] shapes)
        {
            this.shapes = shapes;
        }

        public override int GetPerimeter()
        {
            int perimeter = 0;
            foreach (var shape in shapes)
            {
                perimeter += shape.GetPerimeter();
            }
            return perimeter;
        }

        public override double GetArea()
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.GetArea();
            }
            return area;
        }

        public override void Print()
        {
            Console.WriteLine("-----Composite Shape-----");
            Console.WriteLine("Perimeter: " + GetPerimeter());
            Console.WriteLine("Area: " + GetArea());
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Square square = new Square();
            Rectangle rectangle = new Rectangle(7, 8);
            Rhombus rhombus = new Rhombus(9);
            Parallelogram parallelogram = new Parallelogram(10, 5);
            Trapeze trapeze = new Trapeze(10, 7, 5, 12);
            Circle circle = new Circle(6);
            Ellipse ellipse = new Ellipse(10, 8);

            CompositeShape compositeShape = new CompositeShape(triangle, square, rectangle, rhombus, parallelogram, trapeze, circle, ellipse);

            Console.WriteLine("Details for individual shapes:");
            triangle.Print();
            square.Print();
            rectangle.Print();
            rhombus.Print();
            parallelogram.Print();
            trapeze.Print();
            circle.Print();
            ellipse.Print();

            Console.WriteLine("\nDetails for the composite shape:");
            compositeShape.Print();
        }
    }
}