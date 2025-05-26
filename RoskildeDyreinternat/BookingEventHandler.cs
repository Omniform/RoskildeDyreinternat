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
        public static void Show()
        {
            Console.WriteLine(BookingRepo.AllToString());
        }

        public static void Add()
        {
            int selectedId = ConsoleInputHelper.ReadIntFromConsole("Hvilket dye vil du besøge?\n" + AnimalRepo.AllToString() + "\nIndtast dyrets ID");
            DateOnly date = ConsoleInputHelper.ReadDateFromConsole("Hvilken dato kommer du? (dd - MM - ÅÅÅÅ)");
            TimeOnly timeBegin = ConsoleInputHelper.ReadTimeFromConsole("Hvornår kommer du? (HH:mm)");
            int selectedId2 = ConsoleInputHelper.ReadIntFromConsole("Hvem kommer?\n" + PersonRepo.AllToString() + "Indtast dit ID");

            
            BookingRepo.Add(date, timeBegin, AnimalRepo.GetById(selectedId), PersonRepo.GetById(selectedId2));
        }

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
                try
                {
                    booking = BookingRepo.GetById(int.Parse(input));
                    eventSuccess = true;
                    Console.WriteLine("\nEr du sikker på at du vil slette denne booking? (ja/nej) ");
                    Console.WriteLine("\n" + booking);
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "ja":
                            BookingRepo.Remove(booking);
                            Console.WriteLine("Bookingen er fjernet");
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
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
            }
        }
        public static void Update()
        {
            eventSuccess = false;
            Booking booking = null;
            Console.WriteLine(BookingRepo.AllToString());
            Console.WriteLine("Hvilken booking vil du ændre? (Indtast ID)");
            string input = Console.ReadLine();
            while (!eventSuccess)
            {

                if (input == "fortryd")
                {
                    break;
                }
                try
                {
                    booking = BookingRepo.GetById(int.Parse(input));


                    Console.WriteLine("\n" + booking);
                    while (!eventSuccess)
                    {
                        Console.WriteLine("\nHvad vil du gerne ændre?");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "starttid":
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
                        }

                        string inputChange = Console.ReadLine();
                        try
                        {
                            BookingRepo.Update(booking, input, inputChange);

                            Console.WriteLine("Vil du ændre andet?");
                            string inputConfirm = Console.ReadLine();
                            if (inputConfirm.ToLower() == "nej")
                            {
                                eventSuccess = true;
                            }
                            else if (input.ToLower() == "ja")
                            {
                                break;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("prov igen, eller skriv fortryd");
                        }


                    }
                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
            }
        }
    }
}
