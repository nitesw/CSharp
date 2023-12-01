using System.Xml.Schema;

namespace Lesson_08
{
    class Laptop
    {
        public string Model { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Model} - {Price} UAH";
        }
    }
    class Shop
    {
        Laptop[] laptops = null;

        public Shop(int size)
        {
            laptops = new Laptop[size];   
        }

        public int Length
        {
            get { return laptops.Length; }
        }
        public void SetLaptop(int index, Laptop value)
        {
            laptops[index] = value;
        }
        public Laptop GetLaptop(int index)
        {
            if (index >= 0 && index < laptops.Length)
                return laptops[index];
            throw new IndexOutOfRangeException();
        }

        public Laptop this[int index]
        {
            get 
            {
                if (index >= 0 && index < laptops.Length)
                    return laptops[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < laptops.Length)
                    laptops[index] = value;
            }
        }
        public Laptop this[string name]
        {
            get
            {
                foreach (var item in laptops)
                {
                    if (item.Model == name)
                        return item;
                }
                return null;
            }
            private set
            {
                for (int i = 0; i < laptops.Length; i++)
                {
                    if (laptops[i].Model == name)
                    {
                        laptops[i] = value;
                        break;
                    }
                }
            }
        }
        public int FindByPrice(double price)
        {
            for (int i = 0; i < laptops.Length; i++)
            {
                if (laptops[i].Price == price)
                    return i;
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get 
            {
                int index = FindByPrice(price);
                if (index != -1) return laptops[index];
                throw new Exception("Incorrect price");
            }
            set
            {
                int index = FindByPrice(price);
                if (index != -1)
                {
                    this[index] = value;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop(3);

            /*shop.SetLaptop(0, new Laptop() { Model = "HP", Price = 45520 });
            var laptop = shop.GetLaptop(0);
            Console.WriteLine(laptop);*/
            shop[0] = new Laptop() { Model = "HP", Price = 45520.10 };
            shop[1] = new Laptop() { Model = "Samsung", Price = 46000.99 };
            shop[2] = new Laptop() { Model = "Asus", Price = 30333.12 };
            var laptop = shop[0];
            Console.WriteLine(laptop);
            Console.WriteLine();

            try
            {
                for (int i = 0; i < shop.Length + 2; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(shop["Asus"]);
            //shop["Asus"] = new Laptop() { Model = "DELL", Price = 54202 };
            Console.WriteLine(shop["Asus"]);
            Console.WriteLine(shop["DELL"]);
            Console.WriteLine();

            Console.WriteLine($"Price 46000.99: {shop[46000.99]}");
            Console.WriteLine($"Price 45520.10: {shop[45520.10]}");
            shop[30333.12] = new Laptop() { Model = "Mac", Price = 150000.33 };
        }
    }
}