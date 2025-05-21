using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class BookingRepo
    {
        public static List<Booking> bookings = new List<Booking>();
        public static void Add(DateOnly date, TimeOnly timeBegin, Animal animal, Person person)
        {
            bookings.Add(new(date, timeBegin, animal, person));
        }
        public static void Remove(Booking booking)
        {
            bookings.Remove(booking);
        }
        public static Booking? GetById(int id)
        {
            Booking? booking = null;
            foreach (Booking b in bookings)
            {
                if (b.ID == id) booking = b;
            }
            if (booking == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen booking med det angivne ID";
                throw new NoSearchResultException(msg);
            }
            return booking;
        }
        public static void Update(Booking booking, string infoToChange, string change)
        {
            switch (infoToChange.ToLower())
            {
                case "starttid":
                    booking.TimeBegin = TimeOnly.Parse(change);
                    break;
                case "dyr":
                    booking.Animal = AnimalRepo.GetById(int.Parse(change));
                    break;
                case "dato":
                    booking.Date = DateOnly.Parse(change);
                    break;
                case "person":
                    booking.Person = PersonRepo.GetById(int.Parse(change));
                    break;
                default:
                    break;
            }
        }
        public static string AllToString()
        {
            string s = "";
            foreach (Booking booking in bookings) { s += booking.ToString() + "\n"; }
            return s + "\n";
        }
    }
}
