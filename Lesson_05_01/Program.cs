namespace Lesson_05_01
{
    struct NSL
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
    }
    class Worker
    {
        private NSL nsl;
        private int age;

        public int Age
        {
            get { return age; }
            set 
            { 
                if(value < 18 || value > 65)
                {
                    throw new ArgumentException("The age is less than 18 or more than 65");
                }
                age = value;
            }
        }
        private float salary;

        public float Salary
        {
            get { return salary; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The salary is equal or less than 0, you must pay your worker");
                }
                salary = value;
            }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set 
            {
                if(value > date)
                {
                    throw new ArgumentException("The date is greater than today, you're not from the future");
                }
                date = value;
            }
        }

        public Worker()
        {
            nsl.Name = "";
            nsl.Surname = "";
            nsl.Lastname = "";
            age = 0;
            salary = 0.0f;
            date = DateTime.Now;
        }

        public void SetNSL(string name, string surname, string lastname)
        {
            nsl.Name = name;
            nsl.Surname = surname;
            nsl.Lastname = lastname;
        }
        public void YearsEmployed(int y)
        {
            DateTime currentDate = DateTime.Now;
            int yearsWorked = currentDate.Year - date.Year;

            if (yearsWorked >= y)
            {
                Print();
            }
        }
        public void Print()
        {
            Console.WriteLine($"{nsl.Name} {nsl.Surname} {nsl.Lastname}, {age}, {salary} UAH, " + date.ToShortDateString() + " employment date");
        }
        public override string ToString()
        {
            return $"{nsl.Name} {nsl.Surname} {nsl.Lastname}, {age}, {salary} UAH, {date} employment date";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[2];
            try
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i] = new Worker();
                    Console.Write("Enter name of the worker: ");
                    string n = Console.ReadLine();
                    Console.Write("Enter surname of the worker: ");
                    string s = Console.ReadLine();
                    Console.Write("Enter lastname of the worker: ");
                    string l = Console.ReadLine();
                    workers[i].SetNSL(n, s, l);
                    Console.Write("Enter age of the worker: ");
                    string str = Console.ReadLine();
                    int a = int.Parse(str);
                    workers[i].Age = a;
                    Console.Write("Enter salary of the worker: ");
                    str = Console.ReadLine();
                    float sal = float.Parse(str);
                    workers[i].Salary = sal;
                    Console.Write("Enter day of the worker's employment: ");
                    str = Console.ReadLine();
                    int d = int.Parse(str);
                    Console.Write("Enter month of the worker's employment: ");
                    str = Console.ReadLine();
                    int m = int.Parse(str);
                    Console.Write("Enter year of the worker's employment: ");
                    str = Console.ReadLine();
                    int y = int.Parse(str);
                    workers[i].Date = new DateTime(y, m, d);

                    Console.Clear();
                }

                for (int i = 0; i < workers.Length; i++)
                {
                    workers[i].Print();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Enter work experience: ");
            string str1 = Console.ReadLine();
            int num = int.Parse(str1);
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].YearsEmployed(num);
            }
        }
    }
}