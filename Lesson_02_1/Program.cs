using System;

namespace Lesson_02_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Enter the size of array: ");
            string str = Console.ReadLine();
            int size = int.Parse(str);
            int[] arr = new int[size];

            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(20);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            int pairNum = 0, oddNum = 0, uniqueNum = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    pairNum++;
                }
                else if (arr[i] % 2 != 0)
                {
                    oddNum++;
                }
                bool isUnique = true;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && arr[i] == arr[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    uniqueNum++;
                }
            }
            Console.WriteLine($"Pair nums = {pairNum}, Odd nums = {oddNum}, Unique nums = {uniqueNum}");
            Console.WriteLine();

            Console.Write("Enter the number to show all less nums: ");
            str = Console.ReadLine();
            int num = int.Parse(str);
            for (int i = 0; i < size; i++)
            {
                if (arr[i] < num)
                {
                    Console.WriteLine($"Number that are less than {num}: " + arr[i]);
                }
            }
            Console.WriteLine();*/

            /*int[] A = new int[5];
            float[,] B = new float[3, 4];
            Random rnd = new Random();
            float sum = 0.0f, prod = 1.0f;

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the {i + 1} number: ");
                string str = Console.ReadLine();
                int num = int.Parse(str);
                A[i] = num;
                sum += (float)num;
                prod *= (float)num; 
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = (float)(rnd.NextDouble() * 5.0);
                    B[i, j] = (float)Math.Round(B[i, j], 1);
                    sum += B[i, j];
                    prod *= B[i, j];
                }
            }

            float maxNum = 0.0f, minNum = B[0, 0], oddColSum = 0.0f; 
            int sumOfPair = 0;
            Console.Write("\nArray A: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(A[i] + " ");
            }

            Console.WriteLine("\nArray B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
            {
                if (A[i] % 2 == 0)
                {
                    sumOfPair += A[i];
                }
                if (A[i] > maxNum)
                {
                    maxNum = (float)A[i];
                }
                else if (A[i] < minNum)
                {
                    minNum = (float)A[i];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(j == 0 || j == 2)
                    {
                        oddColSum += B[i, j];
                    }
                    if (B[i, j] > maxNum)
                    {
                        maxNum = B[i, j];
                    }
                    else if(B[i, j] < minNum)
                    {
                        minNum = B[i, j];
                    }
                }
            }
            Console.WriteLine($"\nMax num = {maxNum}; Min num = {minNum}");

            Console.WriteLine($"\nSum of all elems = {sum}; Product of all elems = {prod}");
            Console.WriteLine($"Sum of pair nums (array A) = {sumOfPair}; Sum of odd cols array B) = " +
                $"{Math.Round(oddColSum, 1)}");*/

            int[,] arr = new int[5, 5];
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = rnd.Next(-100, 100);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int[] tmp = new int[25];
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tmp[index] = arr[i, j];
                    index++;
                }
            }
            Console.WriteLine();
            int maxNum = 0, minNum = tmp[0], maxNumIndex = 0, minNumIndex = 0, sum = 0, count = 0; 
            for (int i = 0; i < 25; i++)
            {
                if (tmp[i] > maxNum)
                {
                    maxNum = tmp[i];
                    maxNumIndex = i;
                }
                else if (tmp[i] < minNum)
                {
                    minNum = tmp[i];
                    minNumIndex = i;
                }
                //Console.Write(tmp[i] + " ");
            }
            if(minNumIndex > maxNumIndex)
            {
                int temp = minNumIndex;
                minNumIndex = maxNumIndex;
                maxNumIndex = temp;
            }
            for (int i = minNumIndex; i <= maxNumIndex; i++)
            {
                sum += tmp[i];
            }
            for (int i = 0; i < 25; i++)
            {
                if (minNum - tmp[i] <= 5 && minNum - tmp[i] >= -5)
                {
                    count++;
                }
            }
            Console.WriteLine($"Max num = {maxNum}; Min num = {minNum}");
            Console.WriteLine($"Sum between of {minNum} and {maxNum} = {sum}");
            Console.WriteLine($"Count of all numbers that different by 5 from {minNum} = {count - 1}");
        }
    }
}