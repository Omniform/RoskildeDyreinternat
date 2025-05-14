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

        public Person(string name, int birthday, string address, string telephoneNumber, string email)
        {
            Id = idNext++;
            Name = name;
            Birthday = birthday;
            Address = address;
            TelephoneNumber = telephoneNumber;
            Email = email;
        }

        public override string ToString() 
        {
            return $"ID: {Id}\nName: {Name}\nMember Id: {Id}\nBirthday: {Birthday} \nAdresse: {Address}\nTelephone number: {TelephoneNumber}\nEmail: {Email}";
        }
    }
}
