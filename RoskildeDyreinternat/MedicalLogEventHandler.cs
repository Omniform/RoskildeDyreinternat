using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class MedicalLogEventHandler : IEventHandler
    {
        public static bool eventSuccess = false;

        public static void Show()
        {
            Console.WriteLine(MedicalLogRepo.AllToString());
        }
        public static void Add()
        {
            bool validId = false;

            int selectedId = 0;
            
            while (!validId)
            {
                selectedId = ConsoleInputHelper.ReadIntFromConsole("Hvilket dyr vil du tilføje en log til?" + AnimalRepo.AllToString() + "Indtast dyrets ID");
                if (AnimalRepo.GetById(selectedId) == null)
                {
                    Console.WriteLine("Et dyr med dette ID findes ikke");
                    continue;
                }
            }
            
            Console.WriteLine("Hvad er blevet undersøgt og/eller løst?");
            string description = Console.ReadLine();
            Console.WriteLine("Hvornår er undersøgelsen el.lign foretaget? (dd-MM-ÅÅÅÅ HH:mm)");
            DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm", null);
            Console.WriteLine("Hvem har foretaget undersogelsen?");
            string nameOfDoctor = Console.ReadLine();


            MedicalLogRepo.Add(description, dateTime, AnimalRepo.GetById(selectedId), nameOfDoctor);
        }

        public static void Remove()
        {
            eventSuccess = false;
            MedicalLog medicalLog = null;
            Console.WriteLine(MedicalLogRepo.AllToString());
            int id = ConsoleInputHelper.ReadIntFromConsole("Hvilken log vil du fjerne? (Indtast ID)");
            
            medicalLog = MedicalLogRepo.GetById(id);
            Console.WriteLine("\nEr du sikker på at du vil slette denne log? (ja/nej) ");
            Console.WriteLine("\n" + medicalLog);
            string input = Console.ReadLine();
            switch (input)
            {
                case "ja":
                    MedicalLogRepo.Remove(medicalLog);
                    Console.WriteLine("Loggen er fjernet");
                    break;
                case "nej":
                    break;
            }
                
        }
        public static void Update()
        {
            eventSuccess = false;
            MedicalLog medicalLog = null;
            Console.WriteLine(MedicalLogRepo.AllToString());
            Console.WriteLine("Hvilken log vil du ændre? (Indtast ID)");
            string input = Console.ReadLine();
            while (!eventSuccess)
            {

                if (input == "fortryd")
                {
                    break;
                }
                try
                {
                    medicalLog = MedicalLogRepo.GetById(int.Parse(input));


                    Console.WriteLine("\n" + medicalLog);
                    while (!eventSuccess)
                    {
                        Console.WriteLine("\nHvad vil du gerne ændre?");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "dyr":
                                Console.WriteLine(AnimalRepo.AllToString() +
                                    "\nHvilket er det nye dyr du vil tilknytte loggen? (Indtast ID)");
                                Console.WriteLine();
                                break;
                            case "dato":
                                Console.WriteLine("Hvad vil du ændre datoen og tiden til? (dd-MM-ÅÅÅÅ HH:mm)");
                                break;
                            case "læge":
                                Console.WriteLine("Hvad er navnet på den nye dyrlæge du vil tilknytte?");
                                break;
                            case "beskrivelse":
                                Console.WriteLine("Indtast ned nye beskrivelse");
                                break;
                        }

                        string inputChange = Console.ReadLine();
                        try
                        {
                            MedicalLogRepo.Update(medicalLog, input, inputChange);

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
