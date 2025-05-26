using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class Booking
    {
        private static int idNext = 1;
        public int ID { get; private set; }
        public DateOnly Date {  get; set; }
        public TimeOnly TimeBegin { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public Animal Animal { get; set; }
        public Person Person { get; set; }

        public Booking(DateOnly date, TimeOnly timeBegin, Animal animal, Person person)
        {
            ID = idNext++;
            Date = date;
            TimeBegin = timeBegin;
            TimeEnd = TimeBegin.AddHours(1);
            Animal = animal;
            Person = person;
        }

        public override string ToString() 
        {
            return $"ID: {ID}\nDyr: {Animal.Name}\nTid: {TimeBegin} til {TimeEnd}\nDato: {Date}\nPerson: {Person.Name}\n";
        }
    }
}
