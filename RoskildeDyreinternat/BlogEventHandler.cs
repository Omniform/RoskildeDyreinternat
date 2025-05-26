using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class BlogEventHandler
    {
        private static bool m_eventSuccess = false;

        public static void CreateNewBlog()
        {
            Console.WriteLine("Title");
            string title = Console.ReadLine();

            Console.WriteLine("Beskrivelse");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;
            Console.WriteLine("Dato er sat til " + date.ToString());

            Console.WriteLine("Activity");
            Event activity = EventRepo.FilterEventsByName(Console.ReadLine()).ElementAt(0);

            Console.WriteLine("Forfatter");
            string author = Console.ReadLine();


            BlogRepo.AddBlog(new(title, date, activity, description, author));
        }

        public static void DeleteBlog()
        {
            Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
            Console.WriteLine("Hvilken blog vil du slette? Intast blog ID");
            m_eventSuccess = false;
            Blog blog = null;
            while (!m_eventSuccess)
            {
                string input = Console.ReadLine();
                if (input == "fortryd")
                {
                    break;
                }
                try
                {
                    blog = BlogRepo.GetById(Int32.Parse(input));
                    m_eventSuccess = true;
                    Console.WriteLine("\nEr du sikker på at du vil slette denne blog? (ja/nej) ");
                    Console.WriteLine("\n" + blog);
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "ja":
                            BlogRepo.Delete(blog.Id);
                            Console.WriteLine("Blog er fjernet");
                            break;

                        case "nej":
                            break;
                    }
                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
            }
        }

        public static void UpdateBlog()
        {
            Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
            Console.WriteLine("Hvilken blog vil du ændre? Indtast blog ID");
            m_eventSuccess = false;
            Blog blog = null;

            while (!m_eventSuccess)
            {
                string input = Console.ReadLine();
                if (input == "fortryd")
                {
                    m_eventSuccess = true;
                    break;
                }
                try
                {
                    blog = BlogRepo.GetById(Int32.Parse(input));
                    m_eventSuccess = true;
                    Console.WriteLine("\nEr du sikker på at du vil ændre denne blog? (ja/nej)");
                    Console.WriteLine("\n" + blog);
                    input = Console.ReadLine();

                    if (input == "ja")
                    {
                        Console.WriteLine("Hvilken egenskab vil du ændre?");
                        Console.WriteLine("1 - Title\n2 - Description\n3 - Date\n4 - Author\n5 - Activity");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Ny Title:");
                                blog.Title = Console.ReadLine();
                                break;

                            case "2":
                                Console.WriteLine("Ny Description:");
                                blog.Description = Console.ReadLine();
                                break;

                            case "3":
                                Console.WriteLine("Indtast en dato og tidspunkt (dd-MM-yyyy HH:mm):");
                                string inputDateTime = Console.ReadLine();

                                if (DateTime.TryParseExact(inputDateTime, "dd-MM-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    Console.WriteLine("Gemmer dato og tid: " + parsedDateTime.ToString("dd-MM-yyyy HH:mm"));
                                }
                                else
                                {
                                    Console.WriteLine("Ugyldigt format. Prøv igen.");
                                }
                                break;

                            case "4":
                                Console.WriteLine("Ny Author:");
                                blog.Author = Console.ReadLine();
                                break;

                            case "5":
                                Console.WriteLine("Ny Activity:");
                                blog.Activity = EventRepo.GetById(Int32.Parse(input));
                                break;

                            default:
                                Console.WriteLine("Ugyldigt valg, prøv igen.");
                                break;
                        }

                        Console.WriteLine("Blog er ændret!");
                    }

                    else
                    {
                        Console.WriteLine("Intet er ændret.");
                    }

                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Prøv igen, eller skriv fortryd");
                }
            }
        }
    }
}
