public enum Status { None, Increase, Decrease }

public class CryptoCurrency
{
    public string Name { get; private set; }
    private double price;
    public double Price
    {
        get { return price; }
        private set
        {
            if (value >= 0)
                price = value;
            else
                price = 0;
        }
    }

    public Status Status { get; private set; }
    public int IncCount { get; private set; }
    public int DecCount { get; private set; }

    public CryptoCurrency(string name, double price)
    {
        Name = name;
        Price = price;
        Status = Status.None;
        IncCount = 0;
        DecCount = 0;
    }

    public void SetNewPrice(double newPrice, CryptoCurrency currency)
    {
        if (currency.Name == "Bitcoin")
        {
            if (newPrice > Price)
            {
                IncCount++;
                DecCount = 0;
                if (IncCount >= 10) Status = Status.Increase;
                else Status = Status.None;
            }
            else if (newPrice < Price)
            {
                DecCount++;
                IncCount = 0;
                if (DecCount >= 3) Status = Status.Decrease;
                else Status = Status.None;
            }
            Price = newPrice;
        }
        else if (currency.Name == "Ethereum")
        {
            if (newPrice > Price)
            {
                IncCount++;
                DecCount = 0;
                if (IncCount >= 5) Status = Status.Increase;
                else Status = Status.None;
            }
            else if (newPrice < Price)
            {
                DecCount++;
                IncCount = 0;
                if (DecCount >= 3) Status = Status.Decrease;
                else Status = Status.None;
            }
            Price = newPrice;
        }
        else if (currency.Name == "USDT")
        {
            if (newPrice > Price)
            {
                IncCount++;
                DecCount = 0;
                if (IncCount >= 3) Status = Status.Increase;
                else Status = Status.None;
            }
            else if (newPrice < Price)
            {
                DecCount++;
                IncCount = 0;
                if (DecCount >= 3) Status = Status.Decrease;
                else Status = Status.None;
            }
            Price = newPrice;
        }
    }
}

public class Trader
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Trader(string name)
    {
        Name = name;
        Price = new Random().Next(10000, 100000);
    }

    public void Update(CryptoCurrency currency, Trader trader)
    {
        switch (currency.Status)
        {
            case Status.None:
                Console.WriteLine($"I am {Name}, balance: {Price}. Do nothing with currency {currency.Name}");
                break;
            case Status.Increase:
                if (Price < currency.Price)
                {
                    Console.WriteLine($"I am {Name}, balance: {Price}. Sell {currency.Name}");
                    Price += currency.Price;
                }
                else
                {
                    Console.WriteLine($"I am {Name}, balance: {Price}. Do nothing with currency {currency.Name}");
                }
                break;
            case Status.Decrease:
                if (Price > currency.Price)
                {
                    Console.WriteLine($"I am {Name}, balance: {Price}. Buy {currency.Name}");
                    Price -= currency.Price;
                }
                else
                {
                    Console.WriteLine($"I am {Name}, balance: {Price}. Do nothing with currency {currency.Name}");
                }
                break;
        }
    }
}

public delegate void CourseGeneratedHandler(CryptoCurrency currency);
public class Exchange
{
    public event CourseGeneratedHandler CourseGenerated;
    private List<CryptoCurrency> cryptos;
    private List<Trader> traders;

    public Exchange()
    {
        cryptos = new List<CryptoCurrency>
        {
            new CryptoCurrency("Bitcoin", 27210.50),
            new CryptoCurrency("Ethereum", 1630.00),
            new CryptoCurrency("USDT", 1.00)
        };
        traders = new List<Trader>();
    }

    public void Subscribe(Trader trader)
    {
        traders.Add(trader);
    }

    public void UnSubscribe(Trader trader)
    {
        traders.RemoveAll(t => t.Name == trader.Name);
    }

    private double RandomPrice(double price)
    {
        Random rand = new Random();
        return price + rand.Next(-10, 11);
    }

    public void GenerateCourse()
    {
        foreach (var c in cryptos)
        {
            Console.WriteLine($"=========================={c.Name}==========================");
            c.SetNewPrice(RandomPrice(c.Price), c);
            Notify(c);
            OnCourseGenerated(c);
            Console.WriteLine();
        }
    }

    private void OnCourseGenerated(CryptoCurrency currency) => CourseGenerated?.Invoke(currency);

    public void Notify(CryptoCurrency currency)
    {
        foreach (var t in traders)
        {
            if (t.Price <= 0)
            {
                Console.WriteLine($"I am {t.Name}, balance is zero or negative. Unsubscribing...");
                UnSubscribe(t);
            }
            t.Update(currency, t);
        }
    }

    public void StartTraders()
    {
        for (int i = 0; i < 100; i++)
        {
            GenerateCourse();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        Exchange exchange = new Exchange();

        Trader td1 = new Trader("Max");
        Trader td2 = new Trader("Andrew");

        exchange.Subscribe(td1);
        exchange.Subscribe(td2);

        exchange.CourseGenerated += Exchange_CourseGenerated;

        exchange.StartTraders();
    }

    private static void Exchange_CourseGenerated(CryptoCurrency currency)
    {
        Console.WriteLine($"Course generated for {currency.Name}. New price: {currency.Price}");
    }
}
