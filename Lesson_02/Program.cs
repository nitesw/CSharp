namespace Lesson_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region OneArray
            /*int size = 5;
            int[] arr = new int[size];
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;
            arr[3] = 40;
            arr[4] = 50;

            Console.Write(arr[0] + " ");
            Console.Write(arr[1] + " ");
            Console.Write(arr[2] + " ");
            Console.Write(arr[3] + " ");
            Console.Write(arr[4] + " ");
            Console.WriteLine();

            int[] arr2 = new int[5];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = i * 2;
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();

            int[] arr3 = new int[5] { 11, 12, 13, 14, 15 };
            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write(arr3[i] + " ");
            }
            Console.WriteLine();

            int[] arr4 = new int[] { 100, 101, 102, 103, 104, 105, 106, 107, 108 };
            for (int i = 0; i < arr4.Length; i++)
            {
                Console.Write(arr4[i] + " ");
            }
            Console.WriteLine();

            int[] arr5 = new int[7];
            for (int i = 0; i < arr5.Length; i++)
            {
                Console.Write(arr5[i] + " ");
            }
            Console.WriteLine();

            arr5[1] = 77;
            arr5.SetValue(777, 2);
            foreach (int element in arr5)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();*/
            #endregion

            #region TwoArray
            /*int[,] arr = new int[3, 3];

            arr[0, 0] = 1;
            arr[0, 1] = 2;
            arr[0, 2] = 3;

            arr[1, 0] = 4;
            arr[1, 1] = 5;
            arr[1, 2] = 6;

            arr[2, 0] = 7;
            arr[2, 1] = 8;
            arr[2, 2] = 9;

            Console.Write(arr[0, 0] + " ");
            Console.Write(arr[0, 1] + " ");
            Console.Write(arr[0, 2] + " ");
            Console.WriteLine();
            
            Console.Write(arr[1, 0] + " ");
            Console.Write(arr[1, 1] + " ");
            Console.Write(arr[1, 2] + " ");
            Console.WriteLine();

            Console.Write(arr[2, 0] + " ");
            Console.Write(arr[2, 1] + " ");
            Console.Write(arr[2, 2] + " ");
            Console.WriteLine();

            int[,] arr2 = new int[3, 4];
            Console.WriteLine($"Length: {arr2.Length}");
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = i * j + 1;
                }
            }

            for (int i = 0; i <= arr2.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr2.GetUpperBound(1); j++)
                {
                    Console.Write($"{arr2[i, j]} ");
                }
                Console.WriteLine();
            }

            int[,] arr3 =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            Console.WriteLine(arr3.Length);
            Console.WriteLine(arr3);
            for (int i = 0; i <= arr3.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr3.GetUpperBound(1); j++)
                {
                    Console.Write($"{arr3[i, j]} ");
                }
                Console.WriteLine();
            }*/
            #endregion

            #region Jagged_array
            /*
            int[][]jagged = new int[3][];
            int[]jagged1 = new int[3];

            jagged[0] = new int[] { 1, 2 };
            jagged[1] = new int[] { 1, 2, 3, 4, 5 };
            jagged[2] = new int[] { 1, 2, 3 };

            Console.WriteLine(jagged.Length);

            for (int i = 0; i < jagged.Length; ++i)//3
            {
                for (int j = 0; j < jagged[i].Length; ++j)
                {
                   // Console.Write($"{i};{j}={     jagged[i][j]     }  ");
                    Console.Write($" {jagged[i][j]}  ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
            Console.ReadKey(); 

            foreach (int[] item in jagged)
            {
                foreach (int i in item)
                {
                    Console.Write(i + "\t");
                }
                Console.WriteLine();
            }
             */
            #endregion

            #region Params
            int[] arr = new int[] { 3, 3, 3, 7, 7, 7 };
            ShowArray(10, arr);
            ShowArray("hello", 10, 15, 14, 47, 2, 3, 6, 9, 8, 45, 78, 99, 100);
            //int a = 5;
            //ShowArray(5, new int[] { 3, 3, 3, 7, 7, 7 });
            //// pause
            //Console.ReadKey();
            #endregion
        }
        static void ShowArray(int num, int[] array)
        {
            Console.WriteLine(num);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
        static void ShowArray(string str, int num, int num1, int num2,
            params int[] array)
        {
            Console.WriteLine(num);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}