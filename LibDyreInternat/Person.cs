using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class Person
    {
        private static int idNext = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Birthday { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public Acceslevel PersonAccesLevel { get; set; }

        public enum Acceslevel
        {
            admin = 1,
            medlem
        }

        public Person(string name, int birthday, string address, string telephoneNumber, string email, Acceslevel personAccesLevel)
        {
            Id = idNext++;
            Name = name;
            Birthday = birthday;
            Address = address;
            TelephoneNumber = telephoneNumber;
            Email = email;
            PersonAccesLevel = personAccesLevel;
        }

        public override string ToString()
        {
            string personAcceslevel = "";
            switch (PersonAccesLevel)
            {
                case Acceslevel.admin:
                    personAcceslevel = "Admin";
                    break;
                case Acceslevel.medlem:
                    personAcceslevel = "Medlem";
                    break;
            }


            return $"ID: {Id}\nName: {Name}\nPerson Id: {Id}\nAdresse: {Address}\nTelephone number: {TelephoneNumber}\nEmail: {Email}\nPerson niveau: {personAcceslevel}\n";
        }
    }
}
