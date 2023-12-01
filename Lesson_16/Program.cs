using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson_16
{
    [Serializable]
    public class Passport
    {
        public int Number { get; set; }
        public Passport()
        {
            Number = 999999;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }

    [Serializable]
    public class Person
    {
        public Passport Passport { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        int _identNumber;
        [NonSerialized]
        const string Planet = "Earth";

        public Person(int number)
        {
            _identNumber = number;
            Passport = new Passport();
        }
        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nIdentification number: {_identNumber}\nPlanet: {Planet}\nPassport: {Passport}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*Person person = new Person(123456)
            {
                Name = "Jack",
                Age = 15
            };

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using(Stream fstream = File.Create("Person.bin"))
                {
                    formatter.Serialize(fstream, person);
                }
                Console.WriteLine("BinaryFormatter is OK!!!");


                Person p = null;
                using (Stream fstream = File.OpenRead("Person.bin"))
                {
                    p = (Person)formatter.Deserialize(fstream);
                }
                Console.WriteLine(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            List<Person> persons = new List<Person>()
            {
                new Person(123456) { Name = "Jack", Age = 15 },
                new Person(123456) { Name = "Tom", Age = 12 },
                new Person(123456) { Name = "Bill", Age = 35 },
                new Person(123456) { Name = "John", Age = 47 }
            };

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream fstream = File.Create("Persons.bin"))
                {
                    formatter.Serialize(fstream, persons);
                }
                Console.WriteLine("BinaryFormatter is OK!!!");


                List<Person> newPersons = null;
                using (Stream fstream = File.OpenRead("Persons.bin"))
                {
                    newPersons = (List<Person>)formatter.Deserialize(fstream);
                }
                foreach (Person item in newPersons)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("=================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}