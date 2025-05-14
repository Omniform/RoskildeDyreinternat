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
        // public Author person {get; set;}
        // public Person person {get; set;}

        public Blog(string title, int id, DateTime date, Activity activity, string description, //Author person, Person person) 
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
            Activity = activity;
            // Author = person;
            // Person person;

            idNext++;
        }
        public override string ToString()
        {
            return $"ID: {Id}\nTitle: {Title}\nDescription";
        }
    }
}
