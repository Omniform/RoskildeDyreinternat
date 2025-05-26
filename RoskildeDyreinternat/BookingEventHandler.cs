using LibDyreInternat;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoskildeDyreinternat
{
    public class BookingEventHandler : IEventHandler
    {
        public static bool eventSuccess = false;
        /// <summary>
        /// Prints a list of all bookings to the console
        /// </summary>
        public static void Show()
        {
            Console.WriteLine(BookingRepo.AllToString());
        }
        /// <summary>
        /// Askes user to input the information the booking should contain, asks BookingRepo to create it
        /// </summary>
        public static void Add()
        {
            bool validId = false;
            int selectedId = 0;
            while (!validId)
            {
                selectedId = ConsoleInputHelper.ReadIntFromConsole("Hvilket dye vil du besøge?\n" + AnimalRepo.AllToString() + "\nIndtast dyrets ID");
                if (AnimalRepo.GetById(selectedId) == null)
                {
                    Console.WriteLine("Et dyr med dette ID findes ikke");
                    continue;
                }
                else
                {
                    validId = true;
                }
            }
            DateOnly date = ConsoleInputHelper.ReadDateFromConsole("Hvilken dato kommer du? (dd - MM - ÅÅÅÅ)");
            TimeOnly timeBegin = ConsoleInputHelper.ReadTimeFromConsole("Hvornår kommer du? (HH:mm)");
            int selectedId2 = ConsoleInputHelper.ReadIntFromConsole("Hvem kommer?\n" + PersonRepo.AllToString() + "Indtast dit ID");
            
            BookingRepo.Add(date, timeBegin, AnimalRepo.GetById(selectedId), PersonRepo.GetById(selectedId2));
        }
        /// <summary>
        /// Handles user inputs for removing bookings. Repo removes them
        /// </summary>
        public static void Remove()
        {
            eventSuccess = false;
            Booking booking = null;
            Console.WriteLine(BookingRepo.AllToString());
            Console.WriteLine("Hvilken booking vil du fjerne? (Indtast ID)");
            while (!eventSuccess)
            {
                string input = Console.ReadLine();
                if (input == "fortryd")
                {
                    break;
                }
                //Try to find booking with given ID otherwise starts over
                try
                {
                    booking = BookingRepo.GetById(int.Parse(input));
                    //Makes sure user wants to remove the booking
                    bool inputConfirm = ConsoleInputHelper.ReadBoolFromConsole("\nEr du sikker på at du vil slette denne booking? (ja/nej)\n" + booking);
                    if (inputConfirm)
                    {
                        BookingRepo.Remove(booking);
                        Console.WriteLine("Bookingen er fjernet");
                        eventSuccess = true;
                    }

                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
                
            }
        }
        /// <summary>
        /// Takes inputs for changes user wants to make to booking and passes them the the BookingRepo
        /// </summary>
        public static void Update()
        {
            eventSuccess = false;
            Booking booking = null;
            string infoToChange;
            string inputChange;
            Console.WriteLine(BookingRepo.AllToString() + "Hvilken booking vil du ændre? (Indtast ID)");
            
            while (!eventSuccess)
            {
                string inputID = Console.ReadLine();
                
                if (inputID == "fortryd")
                {
                    break;
                }
                try
                {
                    booking = BookingRepo.GetById(int.Parse(inputID));
                    Console.WriteLine("\n" + booking);
                    //runs until user is done updating info on object
                    while (!eventSuccess)
                    {
                        Console.WriteLine("\nHvad vil du gerne ændre? (dyr, tid, dato, person)");
                        infoToChange = Console.ReadLine();
                        switch (infoToChange)
                        {
                            case "tid":
                                Console.WriteLine("Hvad vil du ændre tiden til? (HH:mm)");
                                break;
                            case "dyr":
                                Console.WriteLine(AnimalRepo.AllToString() +
                                    "\nHvilket dyr vil du besøge i stedet for? (Indtast ID)");
                                Console.WriteLine();
                                break;
                            case "dato":
                                Console.WriteLine("Hvad vil du ændre datoen til? (dd - MM - ÅÅÅÅ)");
                                break;
                            case "person":
                                Console.WriteLine(PersonRepo.AllToString() + 
                                    "\nHvem kommer i stedet for? (Indtast ID)");
                                Console.WriteLine();
                                break;
                            case "id":
                                Console.WriteLine("Du kan ikke ændre et ID");
                                continue;
                            default:
                                Console.WriteLine("Det var ikke en af mulighederne. Prov igen");
                                continue;
                        }
                        inputChange = Console.ReadLine();
                        if (inputChange == "fortryd")
                        {
                            break;
                        }
                        BookingRepo.Update(booking, infoToChange, inputChange);
                        bool inputConfirm = ConsoleInputHelper.ReadBoolFromConsole("Vil du ændre andet? (ja/nej)");
                        if (!inputConfirm)
                        {
                            eventSuccess = true;
                        }
                    }
                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
                
            }
        }
    }
}
