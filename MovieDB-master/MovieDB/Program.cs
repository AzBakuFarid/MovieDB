using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bu defe daxil edilen melumatlarin dolgun oldugunu hesab edirem..." +
                       "ona gore de daxil edilen melumatlarin dogrulugunu yoxlamiram....." +
                       "xahis edirem nezere alasiniz");
            while (true)
            {
                
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Xahis edirik seciminizi edin");
                Console.WriteLine("1. Add author \t 5. get author list");
                Console.WriteLine("2. Add movie \t 6. get movie list");
                Console.WriteLine("3. Add seans \t 7. get seans list");
                Console.WriteLine("4. Add cinema \t 8. get cinema list");

                Console.WriteLine(" \t 9. get report");
                try
                {
                    var choise = Console.ReadLine();
                    switch (choise)
                    {
                        case "1": Methods.AddAuthor(); break;
                        case "2": Methods.AddMovie(); break;
                        case "3": Methods.AddSeans(); break;
                        case "4": Methods.AddCinema(); break;
                        case "6":
                            {
                                List<Movie> list = Methods.GetFromLogFile<Movie>("movies.json");
                                if (list.Count == 0) { Console.WriteLine("You dont have any movie in your DB"); break; }
                                foreach (var movie in list)
                                {
                                    Console.WriteLine("{0} {1} {2}", movie.Title, movie.Author.Name, movie.Year);
                                }
                            }; break;
                        case "8":
                            {
                                List<Cinema> list = Methods.GetFromLogFile<Cinema>("cinemas.json");
                                if (list.Count == 0) { Console.WriteLine("You dont have any cinema in your DB"); break; }
                                foreach (var cinema in list)
                                {
                                    Console.WriteLine("{0} {1} {2}", cinema.Title, cinema.Location.Lat, cinema.Location.Long);
                                }
                            }; break;
                        case "7":
                            {
                                List<Seans> list = Methods.GetFromLogFile<Seans>("seanses.json");
                                if (list.Count == 0) { Console.WriteLine("You dont have any seans in your DB"); break; }
                                foreach (var seans in list)
                                {
                                    Console.WriteLine("{0} {1} {2}", seans.Movie.Title, seans.Cinema.Title, seans.Day);
                                }
                            }; break;
                        case "5":
                            {
                                List<Author> list = Methods.GetFromLogFile<Author>("authors.json");
                                if (list.Count == 0) { Console.WriteLine("You dont have any author in your DB"); break; }
                                foreach (var author in list)
                                {
                                    Console.WriteLine("{0} {1} ", author.Name, author.Birthday);
                                }
                            }; break;
                        case "9":
                            {
                                Console.WriteLine("butun hereketler diger reqemler altinda icra olundugundan burda ne edeceyimi bilmedim....... ona gore de bu mesaji cixartdim ");
                            }; break;
                        default: throw new Exception("incorrect selection");
                    }
                }
                catch (Exception ex)
                {

                    // Console.WriteLine("someThing gone wrong");
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                        Console.WriteLine(ex.InnerException.Message);
                    continue;
                }
                finally {
                    Thread.Sleep(2000);   
                }
            }

        }
    }
}
