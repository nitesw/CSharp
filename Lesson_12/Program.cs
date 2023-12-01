namespace Lesson_12
{
    public delegate void FinishActionDelegate();
    //public event FinishActionDelegate ActionEvent;
    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public void PassExam(string task)
        {
            Console.WriteLine($"Student {FirstName} {LastName} passed the exam {task}");
        }
    }
    class Teacher
    {
        //public ExamDelegate ExamDelegate;

        private event ExamDelegate examDelegate;

        public event ExamDelegate ExamDelegate
        {
            add
            {
                examDelegate += value;
                Console.WriteLine(value.Method.Name + " is added to event");
            }
            remove
            {
                examDelegate -= value;
                Console.WriteLine(value.Method.Name + " is removed to event");
            }
        }
        public event Action TestEvent;

        public void CreateExam(string task)
        {
            //ExamDelegate?.Invoke(task);
            examDelegate?.Invoke(task);
        }
        public void StartAction()
        {
            TestEvent();
        }
    }

    internal class Program
    {
        static void HardWork(FinishActionDelegate action)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i + 1} working...");
                Thread.Sleep(random.Next(500));
                Console.WriteLine($"Operation {i + 1} finished...");
            }
            action?.Invoke();
        }
        static void Action1()
        {
            Console.WriteLine("Bye bye");
        }
        static void Action2()
        {
            Console.WriteLine("Go to home. You are a good worker");
        }

        static void Main(string[] args)
        {
            /*HardWork(Action1);
            HardWork(Action2);
            HardWork(null);
            HardWork(delegate () { Console.WriteLine("I'm finished my work!"); });*/

            List<Student> students = new List<Student>
            {
                new Student
                {
                    FirstName = "Bill",
                    LastName = "Thompson",
                    Birthday = new DateTime(2005, 4, 7),
                },
                new Student
                {
                    FirstName = "Olga",
                    LastName = "Ivanchuk",
                    Birthday = new DateTime(2003, 10, 17),
                },
                new Student
                {
                    FirstName = "Candince",
                    LastName = "Leman",
                    Birthday = new DateTime(2006, 3, 12),
                },
                new Student
                {
                    FirstName = "Nicol",
                    LastName = "Taylor",
                    Birthday = new DateTime(2004, 7, 13),
                }
            };

            Teacher teacher = new Teacher();
            foreach (Student st in students)
            {
                teacher.ExamDelegate += new ExamDelegate(st.PassExam);
            }

            teacher.ExamDelegate -= students[0].PassExam;
            //teacher.ExamDelegate = null;
            teacher.CreateExam("C# Exam in Microsoft Teams at 18:00 15 October");

            /*teacher.TestEvent += Console.Clear;
            teacher.TestEvent += delegate () { Console.ForegroundColor = ConsoleColor.Green; };
            teacher.TestEvent += () => Console.Beep(300, 500);
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent -= Teacher_TestEvent;

            teacher.StartAction();*/
        }

        private static void Teacher_TestEvent()
        {
            Console.WriteLine("Auto-created method by pressing TAB!");
        }
    }
}