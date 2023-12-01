namespace Lesson_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("UA", "Ukraine");
            countries.Add("FR", "France");
            countries.Add("USA", "United States");
            countries.Add("PL", "Poland");
            countries.Add("GB", "Great Britain");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            string country = countries["USA"];
            Console.WriteLine(country);
            countries["USA"] = "America";
            countries["IN"] = "India";

            countries.Remove("USA");

            Console.WriteLine();
            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }*/

            Dictionary<char, Person> people = new Dictionary<char, Person>();
            people.Add('B', new Person() { Name = "Bill" });
            people.Add('T', new Person() { Name = "Tom" });
            people.Add('J', new Person() { Name = "Jack" });
            people.Add('R', new Person() { Name = "Rita" });
            people.Add('O', new Person() { Name = "Olga" });

            people['R'].Name = "Roman";
            if (people.ContainsKey('N'))
            {
                people['N'].Name = "Nick";
            }
            else
            {
                Console.WriteLine("Collection doesn't contain this key!");
            }
            foreach (var p in people)
            {
                Console.WriteLine(p.Key + " - " + p.Value.Name);
            }

            foreach (var p in people.Keys)
            {
                Console.WriteLine(p.ToString());
            }
            foreach (var p in people.Values)
            {
                Console.WriteLine(p.Name);
            }
        }

        class Person
        {
            public string Name { get; set; }
        }
    }
}