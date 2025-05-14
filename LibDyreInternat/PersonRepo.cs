using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public static class PersonRepo
    {
        public static List<Person> AllPersons { get; private set; } = new List<Person>()
            {
                new Person("Toke", 01-01-01, "Holte", "12345678", "Toke@toke.toke", Person.Acceslevel.admin),
                new Person("Esti",  18-05-97, "Jyllinge", "93801615", "estibrusse18@gmail.com", Person.Acceslevel.kunde),
                new Person("Lars", 01-01-01,  "Husum", "45678912", "LarsLars@larslars.lars", Person.Acceslevel.admin),
                new Person("Stefan", 01-01-01, "Denmark", "65465456", "stefan@stefan.dk", Person.Acceslevel.medlem)
            };

        private static List<Person> filteredPerson = new List<Person>();

        public static void AddPerson(Person person) { AllPersons.Add(person); }

        public static bool Delete(int id)
        {
            foreach (Person p in AllPersons)
            {
                if (p.Id.Equals(id))
                {
                    return AllPersons.Remove(p);
                }
            }
            return false;
        }

        public static List<Person> FilterPersonByName(string Name)
        {
            filteredPerson.Clear();
            foreach (Person p in AllPersons)
            {
                if (p.Name.ToLower().Equals(Name.ToLower()))
                {
                    filteredPerson.Add(p);

                }
            }
            if (filteredPerson == null || filteredPerson.Count <= 0)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen med det angivne navn";
                throw new NoSearhResultException(msg);
            }
            return filteredPerson;
        }

        public static Person? GetById(int Id)
        {
            Person? person = null;
            foreach (Person p in AllPersons)
            {
                if (p.Id.Equals(Id))
                {
                    return person = p;
                }
            }
            if (person == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return person;
        }

        public static string ReturnListAsString(List<Person> person)
        {
            string s = "";
            foreach (Person p in person)
            {
                s += p.ToString() + "\n";
            }
            return s;
        }
    }
}
