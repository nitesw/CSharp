using System.Transactions;

namespace Lesson_11
{
    public delegate int IntDelegate(double b);
    public delegate double DoubleDelegate();
    public delegate void VoidDelegate();
    public delegate void SetStringDelegate(string s);

    public class SuperClass
    {
        public void Print(string str)
        {
            Console.WriteLine("String: " + str);
        }
        public static double GetKoef()
        {
            double res = new Random().NextDouble();
            return res;
        }
        public double GetNumber()
        {
            return new Random().Next();
        }
        public void DoWork()
        {
            Console.WriteLine("Doing work...");
        }
        public void Test()
        {
            Console.WriteLine("Testing...");
        }
    }

    public delegate double CalcDelegate(double a, double b);
    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public double Multi(double a, double b)
        {
            return a * b;
        }
        public double Div(double a, double b)
        {
            if(b != 0)
                return a / b;
            throw new DivideByZeroException();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SuperClass super = new SuperClass();
            //super.DoWork();
            //DoubleDelegate method = new DoubleDelegate(SuperClass.GetKoef);
            DoubleDelegate method = SuperClass.GetKoef;
            Console.WriteLine(SuperClass.GetKoef());
            Console.WriteLine(method());
            Console.WriteLine(method.Invoke());
            Console.WriteLine(method?.Invoke());

            /*if (method != null)
                method();
            method?.Invoke();*/

            DoubleDelegate[] delArr = new DoubleDelegate[]
            {
                SuperClass.GetKoef,
                new DoubleDelegate(super.GetNumber)
            };
            Console.WriteLine(delArr[0].Invoke());
            Console.WriteLine(delArr[1].Invoke());

            Console.WriteLine();
            DoubleDelegate dbDel = new DoubleDelegate(SuperClass.GetKoef);
            SetStringDelegate strDel = new SetStringDelegate(super.Print);
            VoidDelegate voidDel = new VoidDelegate(super.DoWork);

            Console.WriteLine(dbDel.Invoke());
            strDel.Invoke("Yeahhhhhhhhhh");
            voidDel();

            Console.WriteLine();
            //Delegate.Combine(dbDel, new DoubleDelegate(super.GetNumber));
            //dbDel += new DoubleDelegate(super.GetNumber);
            dbDel += super.GetNumber;
            foreach (var item in dbDel.GetInvocationList())
            {
                Console.WriteLine(((DoubleDelegate)item).Invoke());
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine(dbDel.Invoke());
        }
    }
}