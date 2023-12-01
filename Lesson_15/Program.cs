using System.IO;
using System.Linq;

namespace Lesson_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string path = "test.txt";
            //string path = "tess.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Yes");
                sw.WriteLine(1);
                sw.WriteLine(true);
                sw.WriteLine('a');
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                        Console.WriteLine(sr.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            /*FileStream file = File.Create("test1.bin");
            BinaryWriter bw = new BinaryWriter(file);

            Console.Write("Enter size of arr: ");
            int size = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter the {i + 1} number: ");
                int num = int.Parse(Console.ReadLine());
                bw.Write(num);
            }
            bw.Close();

            FileStream fileO = File.Open("test1.bin", FileMode.Open);
            var reader = new System.IO.BinaryReader(fileO);

            while (fileO.Position < fileO.Length)
            {
                int num = reader.ReadInt32();
                Console.WriteLine(num);
            }
            reader.Close();

            fileO.Close();*/

            /*string pathP = "testP3.txt";
            string pathO = "testO3.txt";
            int pairNum = 0, oddNum = 0;
            Random rnd = new Random();
            StreamWriter sP = new StreamWriter(pathP);
            StreamWriter sO = new StreamWriter(pathO);
            for (int i = 0; i < 10000; i++)
            {
                int num = rnd.Next();

                if (num % 2 == 0)
                {
                    pairNum++;
                    sP.WriteLine(num);
                }
                else
                {
                    oddNum++;
                    sO.WriteLine(num);
                }
            }
            sP.Dispose();
            sO.Dispose();
            Console.WriteLine($"Pair nums: {pairNum}\nOdd nums: {oddNum}");*/

            /*string path = "test4.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 3; i++)
                {
                    sw.WriteLine("word");
                }
                sw.WriteLine("something");
                sw.WriteLine("other");
                sw.WriteLine("moon");
            }

            using (var reader = File.OpenText(path))
            {
                int counter = 0;
                Console.Write("Enter the word to search for: ");
                string word = Console.ReadLine();
                string reversedWord = new string(word.ToCharArray().Reverse().ToArray());
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null && line.Contains(word))
                    {
                        counter++;
                        Console.WriteLine($"Word - '{word}' was found!");
                    }
                    else
                    {
                        Console.WriteLine($"Word - '{word}' wasn't found!");
                    }
                }
                Console.WriteLine($"Word - '{word}' was found {counter} times!");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null && line.Contains(reversedWord))
                    {
                        counter++;
                        Console.WriteLine($"Word - '{reversedWord}' was found!");
                    }
                    else
                    {
                        Console.WriteLine($"Word - '{reversedWord}' wasn't found!");
                    }
                }
                Console.WriteLine($"Word - '{reversedWord}' was found {counter} times!");
            }*/

            string path = "test5.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Пошук заданого слова у зворотному порядку. " +
                    "Наприклад, користувач шукає слово «moon»? " +
                    "Це означає, що додаток шукає с2лово «moon» у зворотному напрямку: «noom». " +
                    "За результатами пошуку, додато3к відображає кількість входжень!");
            }

            using (var reader = File.OpenText(path))
            {
                int sentenceCount = 0;
                int uppercaseCount = 0;
                int lowercaseCount = 0;
                int vowelCount = 0;
                int consonantCount = 0;
                int digitCount = 0;

                string text = reader.ReadToEnd();

                foreach (char c in text)
                {
                    if(c == '.' || c == '!' || c == '?')
                    {
                        sentenceCount++;
                    }

                    if (char.IsUpper(c))
                    {
                        uppercaseCount++;
                    }
                    else if (char.IsLower(c))
                    {
                        lowercaseCount++;
                    }

                    if ("АЕЄИІЇОУЮЯаеєиіїоуюя".Contains(c))
                    {
                        vowelCount++;
                    }
                    else if (char.IsLetter(c))
                    {
                        consonantCount++;
                    }

                    if (char.IsDigit(c))
                    {
                        digitCount++;
                    }
                }

                Console.WriteLine($"Sentence count: {sentenceCount}");
                Console.WriteLine($"Uppercase letters count: {uppercaseCount}");
                Console.WriteLine($"Lowercase letters count: {lowercaseCount}");
                Console.WriteLine($"Vowel count: {vowelCount}");
                Console.WriteLine($"Consonant count: {consonantCount}");
                Console.WriteLine($"Digit count: {digitCount}");
            }

        }
    }
}