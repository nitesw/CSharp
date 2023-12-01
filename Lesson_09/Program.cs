namespace Lesson_09
{
    public interface IWorker
    {
        public bool IsWorking { get; set; }//prop
        public string Work();//method
        public event EventHandler WorkEnded;//event
    }
    interface IWorkAble
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkAble> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager
    {
        public List<IWorkAble> ListOfWorkers { get; set; }

        public void Control()
        {
            Console.WriteLine("Controlling work........");
        }

        public void MakeBudget()
        {
            Console.WriteLine("Count money........");
        }

        public void Organize()
        {
            Console.WriteLine("Organizing work........");
        }
    }
    class Seller : Employee, IWorkAble
    {
        bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }

        public string Work()
        {
            return "Selling products!!!";
        }
    }
    class Cashier : Employee, IWorkAble
    {
        bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }

        public string Work()
        {
            return "Selling products!!!";
        }
    }
    class StoreKeeper : Employee, IWorkAble
    {
        private bool isWorking = true;
        public bool IsWorking => isWorking;
        //public bool IsWorking { get { return isWorking; } }

        public string Work()
        {
            return "Organize product store!!!";
        }
    }
    class Administrator : Employee, IManager, IWorkAble
    {
        public List<IWorkAble> ListOfWorkers { get; set; }

        private bool isWorking = true;
        public bool IsWorking => isWorking;

        public void Control()
        {
            Console.WriteLine("I am the main person in the store!");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I have many money!");
        }

        public void Organize()
        {
            Console.WriteLine("You must obey me!");
        }

        public string Work()
        {
            return "I'm working(((";
        }
    }

    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Birthdate.ToShortDateString()}";
        }
    }
    class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + $". {Position} {Salary}$\n";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Director director = new Director
            IManager director = new Director
            {
                LastName = "Tomphson",
                FirstName = "Jack",
                Birthdate = new DateTime(1995, 5, 7),
                Position = "Boss",
                Salary = 100000
            };
            Console.WriteLine(director);

            IWorkAble seller = new Seller
            {
                LastName = "Alexus",
                FirstName = "Shai",
                Birthdate = new DateTime(2001, 2, 12),
                Position = "Seller",
                Salary = 7500
            };
            Console.WriteLine(seller);
            IWorkAble cashier = new Cashier
            {
                LastName = "Alexus",
                FirstName = "Mark",
                Birthdate = new DateTime(2001, 2, 12),
                Position = "Cashier",
                Salary = 7500
            };
            Console.WriteLine(cashier);

            if(seller is Seller)
                Console.WriteLine($"Sellers salary: {(seller as Seller)?.Salary}");

            director.ListOfWorkers = new List<IWorkAble>
            {
                seller,
                cashier,
                new StoreKeeper
                {
                    LastName = "Brown",
                    FirstName = "Julia",
                    Birthdate = new DateTime(2002, 2, 17),
                    Position = "Store Keeper",
                    Salary = 12000
                }
            };
            foreach (var item in director.ListOfWorkers)
            {
                if(item is Cashier)
                    Console.WriteLine("Cashier");
                Console.WriteLine(item);
                if(item.IsWorking)
                    Console.WriteLine(item.Work());
            }

            Administrator admin = new Administrator();

            IManager manager = admin;
            manager.Organize();

            IWorkAble worker = admin;
            worker.Work();
        }
    }
}