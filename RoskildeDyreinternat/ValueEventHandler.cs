using LibDyreInternat;
using Library;
using System;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Threading.Channels;
using System.Xml.Linq;
using static LibDyreInternat.Person;

public static class ValueEventHandler
{

    private static bool m_eventSuccess = false;


    public static void ValueAnimal(string key)
    {
        switch (key)
        {
            case "se":
                break;
            case "tilføj":
                break;
            case "fjern":
                break;
            case "ændr":
                break;

        }
    }

    public static void ValueMedicalLog(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(MedicalLogRepo.AllToString()); 
                break;
            case "tilføj":
                break;
            case "fjern":
                break;
            case "ændr":
                break;
        }
    }

    public static void ValuePerson(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons));
                break;

            case "tilføj":
                CreateNewPerson();
                break;

            case "fjern":
                DeletePerson();
                break;

            case "ændr":
                ChangePerson();
                break;
        }
    }

    private static void CreateNewPerson()
    {
        Console.WriteLine("Navn");
        string Name = Console.ReadLine();

        Console.WriteLine("Birthday");
        string Birthday = Console.ReadLine();

        Console.WriteLine("Address");
        string Address = Console.ReadLine();

        Console.WriteLine("TelephoneNumber");
        string TelephoneNumber = Console.ReadLine();

        Console.WriteLine("Email");
        string Email = Console.ReadLine();

        Console.WriteLine("Adgangs niveau\nAdmin = 1\nMedlem = 2\nKunde = 3");
        Person.Acceslevel PersonAccesLevel = (Person.Acceslevel)int.Parse(Console.ReadLine());
    }

    private static void DeletePerson()
    {
        Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons) + "\n");
        Console.WriteLine("Hvilken person vil du slette? Intast persons ID");
        m_eventSuccess = false;
        Person person = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                person = PersonRepo.GetById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne person? (ja/nej) ");
                Console.WriteLine("\n" + person);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        PersonRepo.Delete(person.Id);
                        Console.WriteLine("Person er fjernet");
                        break;

                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    private static void ChangePerson()
    {
        Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons) + "\n");
        Console.WriteLine("Hvilken person vil du ændr? Intast persons ID");
        m_eventSuccess = false;
        Person person = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                person = PersonRepo.GetById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil ændr denne person? (ja/nej)");
                Console.WriteLine("\n" + person);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        Console.WriteLine("Navn");
                        string newName = Console.ReadLine();

                        Console.WriteLine("Fødselsdag");
                        string newBirthday = Console.ReadLine();

                        Console.WriteLine("Adresse");
                        string newAddress = Console.ReadLine();

                        Console.WriteLine("Telefonnummer");
                        string newTelephoneNumber = Console.ReadLine();

                        Console.WriteLine("E-mail");
                        string newEmail = Console.ReadLine();

                        //Console.WriteLine("Brugerens adgangsniveau");
                        //string Acceslevel = Console.ReadLine();

                        Console.WriteLine("Person er ændret");
                        break;

                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    public static void ValueActivity(string key)
    {
        switch (key)
        {
            case "se":
                break;
            case "tilføj":
                break;
            case "fjern":
                break;
            case "ændr":
                break;

        }
    }
    public static void ValueBlog(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs));
                break;

            case "tilføj":
                CreateNewBlog();
                break;

            case "fjern":
                DeleteBlog();
                break;

            case "ændr":
                ChangeBlog();
                break;
        }
    }

    private static void CreateNewBlog()
    {
        Console.WriteLine("Title");
        string Title = Console.ReadLine();

        Console.WriteLine("Beskrivelse");
        string Description = Console.ReadLine();

        DateTime Date = DateTime.Now;
        Console.WriteLine("Dato er sat til "+ Date.ToString());

        //Console.WriteLine("Activity");
        //Activity Activity = ActivityRepo.FilterActivityByName(Console.Readline()).ElementAt(0);
        //Activity Activity = 

        Console.WriteLine("Forfatter");
        string Author = Console.ReadLine();
    }

    private static void DeleteBlog()
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
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    private static void ChangeBlog()
    {
        Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
        Console.WriteLine("Hvilken blog vil du ændr? Intast blog ID");
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
                Console.WriteLine("\nEr du sikker på at du vil ændr denne blog? (ja/nej)");
                Console.WriteLine("\n" + blog);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        Console.WriteLine("Title");
                        string newTitle = Console.ReadLine();

                        Console.WriteLine("Description");
                        string newDescription = Console.ReadLine();

                        Console.WriteLine("Date");
                        DateTime newDate = DateTime.Now;

                        //Console.WriteLine("Activity");
                        //Activity newActivity = 

                        Console.WriteLine("Author");
                        string newAuthor = Console.ReadLine();

                        Console.WriteLine("Blog er ændret");
                        break;

                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }
}
 