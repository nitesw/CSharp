using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace Lesson_16_02
{
    [Serializable]
    public class User
    {
        [Required(ErrorMessage = "ID not defined")]
        [Range(1000, 9999, ErrorMessage = "ID number out of range")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name not set")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age not set")]
        [Range(1, 100, ErrorMessage = "Age error")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [RegularExpression(@"^\+38-0\d{2}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Invalid Ukrainian phone format")]
        public string Phone { get; set; }

        [RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid credit card number")]
        public string CreditCard { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Login must contain only letters")]
        public string Login { get; set; }

        [RegularExpression(@"^[^\s]{8,}$", ErrorMessage = "Password must be at least 8 characters without spaces")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
    [Serializable]
    public class Users
    {
        Dictionary<int, User> userDict;

        public Users()
        {
            userDict = new Dictionary<int, User>();
        }

        public void AddUser(User user)
        {
            if (!userDict.ContainsKey(user.Id))
            {
                userDict[user.Id] = user;
            }
            else
            {
                Console.WriteLine("You've already had same id in users");
            }
        }
        public void Show()
        {
            foreach (var user in userDict.Values)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Age: {user.Age}");
            }
        }

        public void SaveToFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream fstream = File.Create($"{fileName}.bin"))
                {
                    formatter.Serialize(fstream, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoadFromFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Users loadedUsers = null;
                using (Stream fstream = File.OpenRead($"{fileName}.bin"))
                {
                    loadedUsers = (Users)formatter.Deserialize(fstream);
                }
                if (loadedUsers != null)
                {
                    this.userDict = loadedUsers.userDict;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Users users = new Users();

            User user1 = new User { Id = 1001, Name = "John", Age = 25 };
            User user2 = new User { Id = 1002, Name = "Alice", Age = 30 };

            users.AddUser(user1);
            users.AddUser(user2);
            
            users.Show();
            
            users.SaveToFile("userData");

            /*users.LoadFromFile("userData");
            users.Show();*/
        }
    }
}