using LibDyreInternat;
using Library;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Channels;
using System.Xml.Linq;




public static class ValueEventHandler
{

    private static bool m_eventSuccess = false; 
    

    public static void KeyList(string value)
    {
        switch (value)
        {
            case "dyr":
                //Console.WriteLine(AnimalRepo.AllToString());
                break;
            case "person":
                //Console.WriteLine(PersonRepo.AllToString());
                break;
            case "blog":
                //Console.WriteLine(BlogRepo.AllToString());
                break;
            case "aktivitet":
                //Console.WriteLine(ActivityRepo.AllToString());
                break;
            case "booking":
                //Console.WriteLine(BookingRepo.AllToString());
                break;
        }
    }

    public static void KeyEdit(string value)
    {
        switch (value.ToLower())
        {
            case "dyr":
                while (!m_eventSuccess)
                {
                    try
                    {
                        //AnimalRepo.Edit();
                    }
                    catch (TargetException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
                m_eventSuccess = false;
                break;
            case "person":
                break;
            case "blog":
                break;
            case "aktivitet":
                break;
            case "booking":
                break;
        }
    }

    public static void KeyNew(string value)
    {
        switch (value.ToLower())
        {
            case "dyr":
                CreateNewBoat();
                break;
            case "person":
                //CreateNewPerson();
                break;
            case "blog":
                CreateNewBlog();
                break;
            case "aktivitet":
                //CreateNewActivity();
                break;
            case "booking":
                CreateNewBooking();
                break;
        }
    }

    // Takes the boats and changes one value, input is taken from the console
    

    private static void CreateNewBoat()
    {
        
    }
    private static void CreateNewMember()
    {
        
    }
    private static void CreateNewEvent()
    {
        

    }
    private static void CreateNewBlog()
    {
        
    }
    private static void CreateNewBooking()
    {
        
    }

    public static void KeyDelete(string value)
    {
        switch (value.ToLower())
        {
            case "dyr":
                
                break;

            case "person":
                
                break;

            case "aktivitet":
               
                break;

            case "blog":
                
                break;
            case "booking":
                
                break;
        }
    }
    private static void RemoveBlog()
    {
        Console.WriteLine(BlogRepo.AllToString(BlogRepo.AllBlogs) + "\n");
        Console.WriteLine("Hvilken blog vil du slette? Intast bloggens ID");
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
                blog = BlogRepo.GetBlogById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne blog? (ja/nej) ");
                Console.WriteLine("\n" + blog);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        BlogRepo.DeleteBlog(blog.Id);
                        Console.WriteLine("Bloggen er fjernet");
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