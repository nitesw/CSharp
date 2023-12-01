using System.Collections;

namespace Lesson_10
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Student Card: {Number} - {Series}";
        }
    }
    class Student : IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public StudentCard StudentCard { get; set; }

        public object Clone()
        {
            Student clone = (Student)this.MemberwiseClone();
            clone.StudentCard = new StudentCard() { Number = this.StudentCard.Number, Series = this.StudentCard.Series };
            return clone;
        }

        public int CompareTo(Student? other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        /*public int CompareTo(object? obj)
        {
            if(obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }*/

        public override string ToString()
        {
            return $"{FirstName} {LastName}. Birthdate: {Birthdate.ToShortDateString()}" +
                $"\n{StudentCard}\n";
        }
    }
    class Auditory : IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                FirstName = "Bill",
                LastName = "Thompson",
                Birthdate = new DateTime(2005, 4, 7),
                StudentCard = new StudentCard(){Number = 123456, Series = "AA"}
            },
            new Student
            {
                FirstName = "Olga",
                LastName = "Ivanchuk",
                Birthdate = new DateTime(2003, 10, 17),
                StudentCard = new StudentCard(){Number = 321456, Series = "BA"}
            },
            new Student
            {
                FirstName = "Candince",
                LastName = "Leman",
                Birthdate = new DateTime(2006, 3, 12),
                StudentCard = new StudentCard(){Number = 34321456, Series = "AA"}
            },
            new Student
            {
                FirstName = "Nicol",
                LastName = "Taylor",
                Birthdate = new DateTime(2004, 7, 13),
                StudentCard = new StudentCard(){Number = 963258, Series = "BK"}
            }
        };

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students, comparer);
        }
    }
    class FirstNameComparer : IComparer<Student>
    {
        /*public int Compare(object? x, object? y)
        {
            if(x is Student && y is Student)
            {
                return (x as Student).FirstName.CompareTo((y as Student).FirstName);
            }
            throw new NotImplementedException();
        }*/
        public int Compare(Student? x, Student? y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
    class BirthdayComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Birthdate.CompareTo(y.Birthdate);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                FirstName = "Bill",
                LastName = "Thompson",
                Birthdate = new DateTime(2005, 4, 7),
                StudentCard = new StudentCard() { Number = 123456, Series = "AA" }
            };
            Console.WriteLine("----------Student----------");
            Console.WriteLine(student);
            Console.WriteLine("-------Copied Student------");
            Student copy = (Student)student.Clone();
            Console.WriteLine(copy);

            copy.StudentCard.Number = 111;
            Console.WriteLine("-------Number Change------");
            Console.WriteLine(student);
            Console.WriteLine(copy);

            Auditory auditory = new Auditory();
            Console.WriteLine("----------List of students----------");
            foreach (var st in auditory)
            {
                Console.WriteLine(st);
            }

            Console.WriteLine("-------Sorted list of students------");
            auditory.Sort();
            foreach (var st in auditory)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("-------Sorted list of students------");
            auditory.Sort(new FirstNameComparer()); 
            foreach (var st in auditory)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("-------Sorted list of students------");
            auditory.Sort(new BirthdayComparer());
            foreach (var st in auditory)
            {
                Console.WriteLine(st);
            }
        }
    }
}