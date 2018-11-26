using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB
{
    public static class Methods
    {
        public static void LogToFile<T>(string fileName, T obj) {
            var list = GetFromLogFile<T>(fileName);
            Task task = Task.Run(() => {
                using (StreamWriter sw = new StreamWriter(fileName)) {;
                    JsonSerializer js = new JsonSerializer();
                    list.Add(obj);
                    js.Serialize(sw, list);
                }
            });
            
            Console.WriteLine(fileName.Substring(0, fileName.LastIndexOf('.')).TrimEnd('s')+ " has succesfully added");
        }
        public static List<T> GetFromLogFile<T>(string fileName) {
            JsonSerializer js = new JsonSerializer();
            if (!File.Exists(fileName))
            {
                StreamWriter sw = new StreamWriter(fileName);
                sw.Close();
            }
            StreamReader sr = new StreamReader(fileName);
            var list = (List<T>)js.Deserialize(sr, typeof(List<T>));
            if (list == null) list = new List<T>();
            sr.Close();
            return list;
        }

        public static void AddMovie()
        {
            Console.Write("Enter movie's title: ");
            string title = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter movie's release year: ");
            string year = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Select author id:");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0}  {1}", "ID","Author");
            Console.ResetColor();
            int i = 0;
            var list = GetFromLogFile<Author>("authors.json");
            foreach (var author in list)
            {
                Console.WriteLine("{0}  {1}",i++, author.Name);
            }
            var authorIndex = int.Parse(Console.ReadLine());
            LogToFile<Movie>("movies.json", new Movie() { Year = year, Title = title, Author = list[authorIndex] });
        }
        public static void AddAuthor()
        {
            Console.Write("Enter the author's name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter birthday: ");
            string birthday = Console.ReadLine();
            Console.WriteLine();
            LogToFile<Author>("authors.json", new Author() { Name = name, Birthday = birthday });
        }
        public static void AddSeans()
        {
            Seans seans = new Seans();
            Console.WriteLine("Select Movie id: ");
            int i = 0;
            var movies = GetFromLogFile<Movie>("movies.json");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0}  {1}", "ID", "Movie");
            Console.ResetColor();

            foreach (var movie in movies )
            {
                Console.WriteLine("{0}  {1}",i++, movie.Title);
            }
            var index = int.Parse(Console.ReadLine());
            seans.Movie = movies[index];
            i = 0;
            var cinemas = GetFromLogFile<Cinema>("cinemas.json");
            Console.WriteLine("Select cinema id: ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0}  {1}", "ID", "Cinema");
            Console.ResetColor();

            foreach (var cinema in cinemas)
            {
                Console.WriteLine("{0}  {1}", i++, cinema.Title);
            }
            index = int.Parse(Console.ReadLine());
            seans.Cinema = cinemas[index];
            Console.Write("Select seans day: ");
            Console.WriteLine();
            seans.Day = Console.ReadLine();
            LogToFile<Seans>("seanses.json", seans);
        }
        public static void AddCinema() {
            Console.Write("Enter the cinema name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter cinema's longitute: ");
            double longitute = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter cinema's latitude: ");
            double latitude = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Cinema cinema = new Cinema() {Title=name, Location=new Location() {Lat=latitude, Long=longitute } };
            LogToFile<Cinema>("cinemas.json", cinema);


        }

    }
}
