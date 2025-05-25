using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class PersonEventHandler : IEventHandler
    {
        private static bool m_eventSuccess = false;

        public static void Show()
        {
            Console.WriteLine(PersonRepo.AllToString());
        }
        public static void Add()
        {
            Console.WriteLine("Navn");
            string name = Console.ReadLine();

            Console.WriteLine("Birthday");
            string birthday = Console.ReadLine();

            Console.WriteLine("Address");
            string address = Console.ReadLine();

            Console.WriteLine("TelephoneNumber");
            string telephoneNumber = Console.ReadLine();

            Console.WriteLine("Email");
            string email = Console.ReadLine();

            Console.WriteLine("Adgangs niveau\nAdmin = 1\nMedlem = 2\nKunde = 3");
            Acceslevel personAccesLevel = (Acceslevel)int.Parse(Console.ReadLine());


            PersonRepo.Add(new(name, birthday, address, telephoneNumber, email, personAccesLevel));
        }

        public static void Remove()
        {
            Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons) + "\n");
            Console.WriteLine("Hvilken person vil du slette? Intast persons ID");
            m_eventSuccess = false;
            Person person = null;
            while (!m_eventSuccess)
            {
                string input = Console.ReadLine();
                if (input == "fortryd")
                {
                    break;
                }
                try
                {
                    person = PersonRepo.GetById(Int32.Parse(input));
                    m_eventSuccess = true;
                    Console.WriteLine("\nEr du sikker på at du vil slette denne person? (ja/nej) ");
                    Console.WriteLine("\n" + person);
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "ja":
                            PersonRepo.Delete(person.Id);
                            Console.WriteLine("Person er fjernet");
                            break;

                        case "nej":
                            break;
                    }
                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
            }
        }

        public static void Update()
        {
            Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons) + "\n");
            Console.WriteLine("Hvilken person vil du ændre? Indtast persons ID");
            m_eventSuccess = false;
            Person person = null;

            while (!m_eventSuccess)
            {
                string input = Console.ReadLine();
                if (input == "fortryd")
                {
                    break;
                }
                try
                {
                    person = PersonRepo.GetById(Int32.Parse(input));
                    m_eventSuccess = true;
                    Console.WriteLine("\nEr du sikker på at du vil ændre denne person? (ja/nej)");
                    Console.WriteLine("\n" + person);
                    input = Console.ReadLine();

                    if (input == "ja")
                    {
                        Console.WriteLine("Hvilken egenskab vil du ændre?");
                        Console.WriteLine("1 - Navn\n2 - Fødselsdag\n3 - Adresse\n4 - Telefonnummer\n5 - E-mail");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Nyt Navn:");
                                person.Name = Console.ReadLine();
                                break;

                            case "2":
                                Console.WriteLine("Ny Fødselsdag (DD-MM-YYYY):");
                                person.Birthday = Console.ReadLine();
                                break;

                            case "3":
                                Console.WriteLine("Ny Adresse:");
                                person.Address = Console.ReadLine();
                                break;

                            case "4":
                                Console.WriteLine("Nyt Telefonnummer:");
                                person.TelephoneNumber = Console.ReadLine();
                                break;

                            case "5":
                                Console.WriteLine("Ny E-mail:");
                                person.Email = Console.ReadLine();
                                break;

                            default:
                                Console.WriteLine("Ugyldigt valg, prøv igen.");
                                break;
                        }

                        Console.WriteLine("Person er ændret!");
                    }
                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Prøv igen, eller skriv fortryd");
                }
            }
        }
    }
}
