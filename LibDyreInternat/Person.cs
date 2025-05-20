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
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        private string m_email;
        public string Email { get { return m_email; } 
            set
            {
                if (value.Last() == ' ')
                {
                    for (int i = value.Count() - 1; i > 0; i--)
                    {
                        if (value.ElementAt(i) != ' ')
                        {
                            value = value.Remove(i + 1);
                            break;
                        }
                    }
                }
                if (!EmailValidFormat(value))
                {
                    Console.WriteLine(value);
                    throw new FormatException("Email er ikke valid");
                }
                m_email = value;
            }
        }

        public Acceslevel PersonAccesLevel { get; set; }

        public enum Acceslevel
        {
            admin = 1,
            medlem,
            kunde
        }

        public Person(in string name, in string birthday, in string address, in string telephoneNumber, in string email, Acceslevel personAccesLevel)
        {
            Id = idNext++;
            Name = name;
            Birthday = birthday;
            Address = address;
            TelephoneNumber = telephoneNumber;
            Email = email;
            PersonAccesLevel = personAccesLevel;
        }

        private bool EmailValidFormat(in string email)
        {
            // TLD (Top-Level Domain)
            bool TLDAccept = false;
            int atSign = email.IndexOf('@');
            int dotSign = email.IndexOf('.', atSign);
            string TLD = email.Substring(dotSign + 1);

            switch (TLD)
            {
                case "com":
                    TLDAccept = true;
                    break;

                case "dk":
                    TLDAccept = true;
                    break;

                case "edu":
                    TLDAccept = true;
                    break;

                case "org":
                    TLDAccept = true;
                    break;

                case "gov":
                    TLDAccept = true;
                    break;
            }

            if (atSign == -1 || dotSign == -1 || TLDAccept == false)
            {
                return false;
            }
            return true;
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

                case Acceslevel.kunde:
                    personAcceslevel = "Kunde";
                    break;
            }

            return $"ID: {Id}\nPerson Id: {Id}\nNavn: {Name}\nFødselsdag: {Birthday}\nAdresse: {Address}\nTelefonnummer: {TelephoneNumber}\nE-mail: {Email}\nBrugerens adgangsniveau: {personAcceslevel}\n";
        }
    }
}
