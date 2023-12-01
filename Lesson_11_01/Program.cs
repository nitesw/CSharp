namespace Lesson_11_01
{
    public delegate int CalculateDelegate(params int[] arr);
    public delegate void ChangeDelegate(params int[] arr);

	class ArrayCalculation
	{
		public static int NegativeNums(params int[] arr)
		{
			int negativeNums = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] < 0)
				{
					negativeNums++;
				}
			}
			return negativeNums;
		}
        public static int SumOfNums(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
				sum += arr[i];
            }
            return sum;
        }
        public static int SimpleNums(params int[] arr)
        {
            int count = 0;

            foreach (var num in arr)
            {
                if (IsPrime(num))
                {
                    count++;
                }
            }

            return count;
        }
        private static bool IsPrime(int num)
        {
            if (num < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
    class ArrayChanging
    {
        public static void ChangeNegativeNums(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
        }
        public static void SortArr(params int[] arr)
        {
            Array.Sort(arr);
        }
        public static void MoveNums(params int[] arr)
        {
            int sizeCouple = 0, sizeOdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    sizeCouple++;
                }
                else
                    sizeOdd++;
            }

            int[] tmpCouple = new int[sizeCouple];
            int[] tmpOdd = new int[sizeOdd];
            for (int i = 0, couple = 0, odd = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    tmpCouple[couple++] = arr[i];
                }
                else
                    tmpOdd[odd++] = arr[i];
            }

            for (int i = 0; i < sizeCouple; i++)
            {
                arr[i] = tmpCouple[i];
            }
            for (int i = 0; i < sizeOdd; i++)
            {
                arr[sizeCouple++] = tmpOdd[i];
            }
        }
    }

    internal class Program
    {
        public static void CalculationMenu(params int[] arr)
        {
            CalculateDelegate[] calculateDelegates = new CalculateDelegate[]
            {
                ArrayCalculation.NegativeNums,
                ArrayCalculation.SumOfNums,
                ArrayCalculation.SimpleNums
            };

            Console.WriteLine("1. Count negative nums\n2. Sum of all nums\n3. Count simple nums");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"{choice}. {calculateDelegates[choice - 1](arr)}");
        }
        public static void ChangeMenu(params int[] arr)
        {
            ChangeDelegate[] changeDelegates = new ChangeDelegate[]
            {
                ArrayChanging.ChangeNegativeNums,
                ArrayChanging.SortArr,
                ArrayChanging.MoveNums
            };

            Console.WriteLine("1. Change negative nums in arr\n2. Sort arr\n3. Move numbers in arr");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            changeDelegates[choice - 1](arr);
        }
        public delegate void MenuDelegate(params int[] arr);

        static void Main(string[] args)
        {
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(-10, 11);
            }
            while (true)
            {
                Console.Write("Array: ");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                MenuDelegate[] menuDelegates = new MenuDelegate[] { CalculationMenu, ChangeMenu };
                Console.WriteLine("\n1. Calculation opertaions with arr\n2. Change opertaions with arr");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                menuDelegates[choice - 1](arr);
            }
        }
    }
}