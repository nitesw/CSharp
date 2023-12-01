namespace Lesson_09_01
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }
    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
    class Array : IOutput, IMath, ISort
    {
        private int[] arr;
        public Array(int size)
        {
            if(size > 0)
            {
                arr = new int[size];
                FillArr();
            }
            else
            {
                throw new ArgumentException("Size is less than 0");
            }
        }

        private void FillArr()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1 + i * 2;
            }
        }

        public void Show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public void Show(string info)
        {
            Console.Write(info + " ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public int Max()
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        public int Min()
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        public float Avg()
        {
            float avg = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                avg += arr[i];
            }
            return avg / arr.Length;
        }
        public bool Search(int valueToSearch)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (valueToSearch == arr[i])
                    return true;
            }
            return false;
        }

        public void SortAsc()
        {
            if (arr == null)
                return;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void SortDesc()
        {
            if (arr == null)
                return;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Array arr = new Array(5);
                arr.Show("This is our first array:");
                //arr.Show();
                Console.WriteLine();

                Console.WriteLine("Max num: " + arr.Max());
                Console.WriteLine("Min num: " + arr.Min());
                Console.WriteLine("Avg: " + arr.Avg());
                Console.WriteLine("Search for number: " + arr.Search(1));
                Console.WriteLine();

                arr.SortDesc();
                arr.Show("Sorted array by desc:");
                arr.SortAsc();
                arr.Show("Sorted array by asc:");
                arr.SortByParam(false);
                arr.Show("Sorted array:");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}