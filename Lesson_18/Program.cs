namespace Lesson_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 11, 2, 32, 4, 65, 6, 1, 236, 3, 63, 7, 25, 2364, 4 };

            /*var query = from i in arr
                        where i > 0
                        orderby i ascending
                        select i;*/
            /*var query = arr.Where(i => i > 0).OrderBy(i => i); 

            Console.WriteLine("Arr ordered by ascending: ");*/

            /*var query = from i in arr
                        where i > 9 && i < 100
                        select i;
            double res = (from i in arr
                         where i > 9 && i < 100
                         select i).Average();*/
            var query = arr.Where(i => i > 9 && i < 100);
            double res = arr.Where(i => i > 9 && i < 100).Average();

            Console.WriteLine("Double digits numbers: ");
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine($"\nDouble digits numbers avarage: {res}");
        }
    }
}