using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibDyreInternat.Person;

namespace LibDyreInternat
{
    public static class BlogRepo
    {
        public static List<Blog> AllBlogs { get; private set; } = new List<Blog>()
        {
            new Blog("Tokes blog", new DateTime(), new Event("Tokes aktivitet", new DateOnly (2002, 11, 20), new TimeOnly(14,00), new TimeOnly(15,00), PersonRepo.GetById(2)),"Tokes Blog", "Bob"),
            new Blog("Esti's blog", new DateTime(), new Event("Esti's aktivitet", new DateOnly (2018, 05, 18), new TimeOnly(18,00), new TimeOnly(19,00), PersonRepo.GetById(1)),"Esti's Blog", "Rover")
        };

        private static List<Blog> filteredBlog = new List<Blog>();

        public static void AddBlog(Blog blog) {AllBlogs.Add(blog); }

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

        public static List<Blog> FilterBlogByTitel(string Title)
        {
            filteredBlog.Clear();
            foreach (Blog b in AllBlogs)
            {
                if (b.Title.ToLower().Equals(Title.ToLower()))
                {
                    filteredBlog.Add(b);
                }
            }
            if (filteredBlog == null || filteredBlog.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen med det angivne title";
                //throw new NoSearhResultException(msg);
            }
            return filteredBlog;
        }

        public static Blog? GetById(int Id)
        {
            Blog? blog = null;
            foreach (Blog b in AllBlogs)
            {
                if (b.Id.Equals(Id))
                {
                    return blog = b;
                }
            }
            if (blog == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen med det angivne ID";
                //throw new NoSearhResultException(msg);
            }
            return blog;
        }

        public static string ReturnListAsString(List<Blog> blog)
        {
            string s = "";
            foreach (Blog b in blog)
            {
                s += b.ToString() + "\n";
            }
            return s;
        }

        public static bool UpdateBlog(int Id, string newTitle, string newDescription, DateTime newDate, string newAuthor, Event newActivity)
        {
            foreach (Blog blog in AllBlogs)
            {
                if (blog.Id.Equals(Id))
                {
                    blog.Title = newTitle;
                    blog.Description = newDescription;
                    blog.Date = newDate;
                    blog.Author = newAuthor;
                    blog.Activity = newActivity;
                    return true;
                }
            }
            return false;
        }
    }
}
