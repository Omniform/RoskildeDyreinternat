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
        public Event? Activity {get; set;} = null;
        public string Author {get; set;}

        public Blog(string title, DateTime date, Event activity, string description, string author) 
        {
            Id = idNext++;
            Title = title;
            Description = description;
            Date = date;
            Activity = activity;
            Author = author;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nTitle: {Title}\nDescription: {Description}\nDate: {Date}\nActivity: {Activity}\nAuthor: {Author}";
        }
    }
}
