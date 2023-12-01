using System.Collections;

namespace Lesson_10_01
{
    enum Genre { Comedy, Horror, Adventure, Drama, Action, Fantasy };

    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public object Clone()
        {
            Director clone = (Director)this.MemberwiseClone();
            clone = new Director() { FirstName = this.FirstName, LastName = this.LastName, Birthdate = this.Birthdate };
            return clone;
        }

        public override string ToString()
        {
            return $"Film director: {FirstName} {LastName}, {Birthdate.ToShortDateString()} birthdate";
        }
    }

    class Movie : ICloneable, IComparable<Movie>
    {
        public string Title { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }

        private Genre genre;
        public Genre Genre
        {
            get { return genre; }
            set { genre = value > 0 ? value : Genre.Comedy; }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set { year = value > 0 ? value : 1; }
        }

        private short rating;
        public short Rating
        {
            get { return rating; }
            set { rating = value >= 0 ? value : (short)0; }
        }


        public override string ToString()
        {
            return $"==============={Title}===============\n{Director}\nGenre: {genre}\n" +
                $"Made in {Country}, in {Year}\nRating {rating}";
        }

        public object Clone()
        {
            Movie clone = (Movie)this.MemberwiseClone();
            clone = new Movie()
            {
                Title = this.Title,
                Director = this.Director,
                Country = this.Country,
                genre = this.genre,
                year = this.year,
                rating = this.rating
            };
            return clone;
        }

        public int CompareTo(Movie? other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
    class Cinema : IEnumerable
    {
        Movie[] movies =
        {
            new Movie
            {
                Title = "IT",
                Director = new Director
                {
                    FirstName = "Stephen",
                    LastName = "King",
                    Birthdate = new DateTime(1947, 9, 21)
                },
                Country = "USA",
                Genre = Genre.Horror,
                Rating = 8,
                Year = 1990
            },
            new Movie
            {
                Title = "The Shining",
                Director = new Director
                {
                    FirstName = "Stephen",
                    LastName = "King",
                    Birthdate = new DateTime(1947, 9, 21)
                },
                Country = "USA",
                Genre = Genre.Horror,
                Rating = 7,
                Year = 1980
            },
            new Movie
            {
                Title = "Pet Semetary",
                Director = new Director
                {
                    FirstName = "Stephen",
                    LastName = "King",
                    Birthdate = new DateTime(1947, 9, 21)
                },
                Country = "USA",
                Genre = Genre.Horror,
                Rating = 6,
                Year = 1989
            },
            new Movie
            {
                Title = "Harry Potter",
                Director = new Director
                {
                    FirstName = "Joan",
                    LastName = "Rouling",
                    Birthdate = new DateTime(1965, 7, 31)
                },
                Country = "UK",
                Genre = Genre.Fantasy,
                Rating = 9,
                Year = 1997
            },
            new Movie
            {
                Title = "Funny Moments",
                Director = new Director
                {
                    FirstName = "Kyle",
                    LastName = "Bol",
                    Birthdate = new DateTime(2000, 1, 2)
                },
                Country = "GE",
                Genre = Genre.Comedy,
                Rating = 3,
                Year = 2020
            }
        };
        public string Address { get; set; }

        public IEnumerator GetEnumerator()
        {
            return movies.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(movies);
        }
        public void Sort(IComparer<Movie> comparer)
        {
            Array.Sort(movies, comparer);
        }
    }
    class YearComparer : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
    class RatingComparer : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();
            cinema.Address = "Soborna str.";
            Console.WriteLine("----------Cinema----------");
            Console.WriteLine("Address: " + cinema.Address);
            foreach (var mv in cinema)
            {
                Console.WriteLine(mv);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("----------Sorted movies by name----------");
            cinema.Sort();
            foreach (var mv in cinema)
            {
                Console.WriteLine(mv);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("----------Sorted movies by year----------");
            cinema.Sort(new YearComparer());
            foreach (var mv in cinema)
            {
                Console.WriteLine(mv);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("----------Sorted movies by rating----------");
            cinema.Sort(new RatingComparer());
            foreach (var mv in cinema)
            {
                Console.WriteLine(mv);
            }
        }
    }
}