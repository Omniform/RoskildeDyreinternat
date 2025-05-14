using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class Blog
    {
        private static int idNext = 1;
        public int Id {get; private set;}
        public string Title { get; set;}
        public string Description {get; set;}
        public DateTime Date {get; set;}
        public Activity Activity {get; set;}
        public string Author {get; set;}

        public Blog(string title, int id, DateTime date, Activity activity, string description, string author) 
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Activity = activity;
            Author = author;

            idNext++;
        }
        public override string ToString()
        {
            return $"ID: {Id}\nTitle: {Title}\nDescription: {Description}\nDate: {Date}\nActivity: {Activity}\nAuthor: {Author}";
        }
    }
}
