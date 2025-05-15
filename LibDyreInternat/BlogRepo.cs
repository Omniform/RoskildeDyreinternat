using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public static class BlogRepo
    {
        public static List<Blog> AllBlogs { get; private set; } = new List<Blog>()
        {
            new Blog("Tokes blog", 1, new DateTime(), new Activity("Tokes aktivitet", new DateOnly (2002, 11, 20), new TimeOnly(14,00), new TimeOnly(15,00), new Person("Toke", "201102","Æblemadevej 1", "24613612", "Tokedit11@gmail.com", Person.Acceslevel.admin)),"Tokes Blog", "Bob")
        };

        public static void AddBlog(Blog blog) { AllBlogs.Add(blog); }

        public static bool Delete(int id)
        {
            foreach (Blog b in AllBlogs)
            {
                if (b.Id.Equals(id))
                {
                    return AllBlogs.Remove(b);
                }
            }
            return false;
        }
    }
}
