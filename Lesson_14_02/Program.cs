using System;
using System.Collections;

namespace Lesson_14_02
{
    interface IIndexer<T>
    {
        T this[int index] { get; set; }
    }

    class MyStack<Type> where Type : IComparable<Type>
    {
        private Type[] arr;

        public MyStack()
        {
            arr = new Type[0];
        }

        public Type this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();
                arr[index] = value;
            }
        }

        public int Count()
        {
            return arr.Length;
        }
        public Type Peek()
        {
            if (arr.Length > 0)
            {
                return arr[arr.Length - 1];
            }
            else
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }

        public void Push(Type elem)
        {
            Type[] tmpArr = new Type[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                tmpArr[i] = arr[i];
            }
            tmpArr[arr.Length] = elem;
            arr = tmpArr;
        }
        public void Pop()
        {
            if (arr.Length > 0)
            {
                Type[] newArr = new Type[arr.Length - 1];
                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = arr[i];
                }
                arr = newArr;
            }
            else
            {
                throw new InvalidOperationException("The stack is empty. Cannot pop an element.");
            }
        }
    }
    class MyQueue<Type> where Type : IComparable<Type>
    {
        private Type[] arr;

        public MyQueue()
        {
            arr = new Type[0];
        }

        public Type this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException();
                arr[index] = value;
            }
        }

        public int Count()
        {
            return arr.Length;
        }
        public Type Peek()
        {
            if (arr.Length > 0)
            {
                return arr[arr.Length - 1];
            }
            else
            {
                throw new InvalidOperationException("The queue is empty.");
            }
        }

        public void Enqueue(Type elem)
        {
            Type[] tmpArr = new Type[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                tmpArr[i] = arr[i];
            }
            tmpArr[arr.Length] = elem;
            arr = tmpArr;
        }
        public void Dequeue()
        {
            if (arr.Length > 0)
            {
                Type[] newArr = new Type[arr.Length - 1];
                for (int i = 1; i < arr.Length; i++)
                {
                    newArr[i - 1] = arr[i];
                }
                arr = newArr;
            }
            else
            {
                throw new InvalidOperationException("The queue is empty. Cannot dequeue an element.");
            }
        }
    }

    internal class Program
    {
        public static Type FindMax<Type>(Type n1, Type n2, Type n3) where Type : IComparable<Type>
        {
            if (n1.CompareTo(n2) > 0 && n1.CompareTo(n3) > 0)
            {
                return n1;
            }
            else if (n2.CompareTo(n3) > 0)
            {
                return n2;
            }
            else
            {
                return n3;
            }
        }
        public static Type FindMin<Type>(Type n1, Type n2, Type n3) where Type : IComparable<Type>
        {
            if (n1.CompareTo(n2) < 0 && n1.CompareTo(n3) < 0)
            {
                return n1;
            }
            else if (n2.CompareTo(n3) < 0)
            {
                return n2;
            }
            else
            {
                return n3;
            }
        }
        public static Type FindSum<Type>(params Type[] arr)
        {
            Type sum = default;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += (dynamic)arr[i];
            }
            return sum;
        }

        static void Main(string[] args)
        {
            /*int num1 = 1, num2 = 8, num3 = 0;
            double dNum1 = 10.2, dNum2 = 10.1, dNum3 = 4.2;
            string sNum1 = "A", sNum2 = "B", sNum3 = "C";
            Console.WriteLine("Max Int num: " + FindMax(num1, num2, num3));
            Console.WriteLine("Max Double num: " + FindMax(dNum1, dNum2, dNum3));
            Console.WriteLine("Max String num: " + FindMax(sNum1, sNum2, sNum3));

            Console.WriteLine();
            Console.WriteLine("Min Int num: " + FindMin(num1, num2, num3));
            Console.WriteLine("Min Double num: " + FindMin(dNum1, dNum2, dNum3));
            Console.WriteLine("Min String num: " + FindMin(sNum1, sNum2, sNum3));

            int[] arrI = new int[] { 1, 2, 3, 4, 5 };
            double[] arrD = new double[] { 0.2, 0.1, 0.3, 0.4 };
            string[] arrS = new string[] { "Helllo", "it's", "me" };
            Console.WriteLine();
            Console.WriteLine("Sum of Int arr: " + FindSum(arrI));
            Console.WriteLine("Sum of Double arr: " + FindSum(arrD));
            Console.WriteLine("Sum of String arr: " + FindSum(arrS));*/

            /*#region Int Stack
            MyStack<int> myStackInt = new MyStack<int>();
            myStackInt.Push(5);
            myStackInt.Push(1);
            myStackInt.Push(3);
            myStackInt.Push(4);

            Console.WriteLine("===============Int stack===============");
            Console.Write("myStackInt elems: ");
            for (int i = 0; i < myStackInt.Count(); i++)
            {
                Console.Write(myStackInt[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myStackInt: " + myStackInt.Count());
            Console.WriteLine("Peek elem in myStackInt: " + myStackInt.Peek());
            myStackInt.Pop();

            Console.WriteLine();
            Console.Write("myStackInt elems: ");
            for (int i = 0; i < myStackInt.Count(); i++)
            {
                Console.Write(myStackInt[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myStackInt: " + myStackInt.Count());
            #endregion

            #region String Stack
            MyStack<string> myStackStr = new MyStack<string>();
            myStackStr.Push("Me");
            myStackStr.Push("And");
            myStackStr.Push("You");
            myStackStr.Push("Yeah");

            Console.WriteLine("\n===============String stack===============");
            Console.Write("myStackStr elems: ");
            for (int i = 0; i < myStackStr.Count(); i++)
            {
                Console.Write(myStackStr[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myStackStr: " + myStackStr.Count());
            Console.WriteLine("Peek elem in myStackStr: " + myStackStr.Peek());
            myStackStr.Pop();

            Console.WriteLine();
            Console.Write("myStackStr elems: ");
            for (int i = 0; i < myStackStr.Count(); i++)
            {
                Console.Write(myStackStr[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myStackStr: " + myStackStr.Count());
            #endregion*/

            #region Int Queue
            MyQueue<int> myQueueInt = new MyQueue<int>();
            myQueueInt.Enqueue(5);
            myQueueInt.Enqueue(1);
            myQueueInt.Enqueue(3);
            myQueueInt.Enqueue(4);

            Console.WriteLine("===============Int queue===============");
            Console.Write("myQueueInt elems: ");
            for (int i = 0; i < myQueueInt.Count(); i++)
            {
                Console.Write(myQueueInt[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myQueueInt: " + myQueueInt.Count());
            Console.WriteLine("Peek elem in myQueueInt: " + myQueueInt.Peek());
            myQueueInt.Dequeue();

            Console.WriteLine();
            Console.Write("myQueueInt elems: ");
            for (int i = 0; i < myQueueInt.Count(); i++)
            {
                Console.Write(myQueueInt[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myQueueInt: " + myQueueInt.Count());
            #endregion

            #region String Queue
            MyQueue<string> myQueueStr = new MyQueue<string>();
            myQueueStr.Enqueue("Me");
            myQueueStr.Enqueue("And");
            myQueueStr.Enqueue("You");
            myQueueStr.Enqueue("Yeah");

            Console.WriteLine("\n===============String queue===============");
            Console.Write("myQueueStr elems: ");
            for (int i = 0; i < myQueueStr.Count(); i++)
            {
                Console.Write(myQueueStr[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myStackStr: " + myQueueStr.Count());
            Console.WriteLine("Peek elem in myStackStr: " + myQueueStr.Peek());
            myQueueStr.Dequeue();

            Console.WriteLine();
            Console.Write("myQueueStr elems: ");
            for (int i = 0; i < myQueueStr.Count(); i++)
            {
                Console.Write(myQueueStr[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Elems in myQueueStr: " + myQueueStr.Count());
            #endregion
        }
    }
}