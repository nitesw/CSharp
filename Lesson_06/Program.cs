using System;

namespace Lesson_06
{
    struct NSL
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
    }
    class CardHolder
    {
        private NSL nsl;
        private int cardNum;

        public int CardNum
        {
            get { return cardNum; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The card number is invalid");
                }
                cardNum = value;
            }
        }
        private short cvv;

        public short Cvv
        {
            get { return Cvv; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("The cvv is invalid");
                }
                cvv = value;
            }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value < date)
                {
                    throw new ArgumentException("The date is less than today's date, update your card");
                }
                date = value;
            }
        }

        public CardHolder()
        {
            nsl.Name = "";
            nsl.Surname = "";
            nsl.Lastname = "";
            cardNum = 0;
            cvv = 0;
            date = DateTime.Now;
        }

        public void SetNSL(string name, string surname, string lastname)
        {
            nsl.Name = name;
            nsl.Surname = surname;
            nsl.Lastname = lastname;
        }
        public void Print()
        {
            Console.WriteLine($"Full name: {nsl.Name} {nsl.Surname} {nsl.Lastname}\nCard number: {cardNum}\nCVV: " +
                $"{cvv}\nCard exapration date: {date.ToShortDateString()}");
        }
        public override string ToString()
        {
            return $"Full name: {nsl.Name} {nsl.Surname} {nsl.Lastname}\nCard number: {cardNum}\nCVV: " +
                $"{cvv}\nCard exapration date: {date.ToShortDateString()}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Enter the number: ");
            string str = Console.ReadLine();
            try
            {
                checked
                {
                    int num = int.Parse(str);
                }
            }
            catch(OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            /*try
            {
                CardHolder cardHolder = new CardHolder();

                Console.Write("Enter the card number: ");
                string str = Console.ReadLine();
                int cNum = int.Parse(str);
                cardHolder.CardNum = cNum;

                Console.Write("Enter the cvv from card number: ");
                str = Console.ReadLine();
                short cvv = short.Parse(str);
                cardHolder.Cvv = cvv;

                Console.Write("Enter the cardholder's name: ");
                string n = Console.ReadLine();
                Console.Write("Enter the cardholder's surname: ");
                string s = Console.ReadLine();
                Console.Write("Enter the cardholder's lastname: ");
                string l = Console.ReadLine();
                cardHolder.SetNSL(n, s, l);

                //Console.Write("Enter card expiration day: ");
                //str = Console.ReadLine();
                //int d = int.Parse(str);
                //Console.Write("Enter card expiration month: ");
                //str = Console.ReadLine();
                //int m = int.Parse(str);
                //Console.Write("Enter card expiration year: ");
                //str = Console.ReadLine();
                //int y = int.Parse(str);
                //cardHolder.Date = new DateTime(y, m, d);

                Console.Write("Enter card expiration date (use dd-mm-yyyy example): ");
                str = Console.ReadLine();
                DateTime date = DateTime.Parse(str);
                cardHolder.Date = date;

                Console.Clear();
                cardHolder.Print();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            try
            {
                Console.Write("Enter numbers and * as the operator, separated by *: ");
                string str = Console.ReadLine();

                int prod = 1;
                string[] numbers = str.Split('*');
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!int.TryParse(numbers[i], out int parsedNum))
                    {
                        throw new FormatException("Invalid input. Please enter only integers separated by *.");
                    }

                    prod *= parsedNum;
                }
                Console.WriteLine("Result: " + prod);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}