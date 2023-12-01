using System.Text.Json;
using System.Xml.Serialization;

namespace Lesson_16_01
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _identNumber;
        const string Planet = "Earth";

        public Person()
        {
            
        }
        public Person(int number)
        {
            _identNumber = number;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nIdentification number: {_identNumber}\nPlanet: {Planet}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*List<Person> persons = new List<Person>()
            {
                new Person(123456) { Name = "Jack", Age = 15 },
                new Person(123456) { Name = "Tom", Age = 12 },
                new Person(123456) { Name = "Bill", Age = 35 },
                new Person(123456) { Name = "John", Age = 47 }
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            try
            {
                using (Stream stream = File.Create("Person.xml"))
                {
                    xmlSerializer.Serialize(stream, persons);
                }
                Console.WriteLine("XmlSerializer is OK!!!");

                List<Person> newList = null;
                using (Stream stream = File.OpenRead("Person.xml"))
                {
                    newList = (List<Person>)xmlSerializer.Deserialize(stream);
                }
                foreach (var item in newList)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("=================");
                }
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

            try
            {
                string filename = "Person.json";
                string jsonString = JsonSerializer.Serialize(persons);
                File.WriteAllText(filename, jsonString);

                jsonString = File.ReadAllText(filename);
                List<Person> list = JsonSerializer.Deserialize<List<Person>>(jsonString);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}