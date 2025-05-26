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
        /// <summary>
        /// Prints a list of all medical logs to the console
        /// </summary>
        public static void Show()
        {
            Console.WriteLine(MedicalLogRepo.AllToString());
        }
        /// <summary>
        /// Askes user to input the information the MedLog should contain, asks MedLogRepo to create it
        /// </summary>
        public static void Add()
        {
            bool validId = false;

            int selectedId = 0;
            
            //makes sure an animal with the given ID exists
            while (!validId)
            {
                selectedId = ConsoleInputHelper.ReadIntFromConsole("Hvilket dyr vil du tilføje en log til?" + AnimalRepo.AllToString() + "Indtast dyrets ID");
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
            string description = ConsoleInputHelper.ReadStringFromConsole("Hvad er blevet undersøgt og/eller løst?");
            DateTime dateTime = ConsoleInputHelper.ReadDateTimeFromConsole("Hvornår er undersøgelsen el.lign foretaget? (dd-MM-ÅÅÅÅ HH:mm)");
            string nameOfDoctor = ConsoleInputHelper.ReadStringFromConsole("Hvem har foretaget undersogelsen?");

            MedicalLogRepo.Add(description, dateTime, AnimalRepo.GetById(selectedId), nameOfDoctor);
        }
        /// <summary>
        /// Handles user inputs for removing MedLog. Repo removes them
        /// </summary>
        public static void Remove()
        {
            eventSuccess = false;
            MedicalLog medicalLog = null;
            int id = ConsoleInputHelper.ReadIntFromConsole(MedicalLogRepo.AllToString() + "Hvilken log vil du fjerne? (Indtast ID)");
            //Try to find MedLog with given ID otherwise starts over
            try
            {
                medicalLog = MedicalLogRepo.GetById(id);
                //Makes sure user wants to remove the booking
                bool input = ConsoleInputHelper.ReadBoolFromConsole("\nEr du sikker på at du vil slette denne log? (ja/nej)\n" + medicalLog);
                if (input)
                {
                    MedicalLogRepo.Remove(medicalLog);
                    Console.WriteLine("Loggen er fjernet");
                    eventSuccess = true;
                }
            }
            catch (NoSearchResultException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("prov igen");
            }
            
        }
        /// <summary>
        /// Takes inputs for changes user wants to make to MedLog and passes them the the MedLogRepo
        /// </summary>
        public static void Update()
        {
            eventSuccess = false;
            MedicalLog medicalLog = null;
            string infoToChange;
            Console.WriteLine(MedicalLogRepo.AllToString());
            Console.WriteLine("Hvilken log vil du ændre? (Indtast ID)");
            while (!eventSuccess)
            {
                string inputID = Console.ReadLine();
                if (inputID == "fortryd")
                {
                    break;
                }
                try
                {
                    medicalLog = MedicalLogRepo.GetById(int.Parse(inputID));
                }
                catch (NoSearchResultException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("prov igen, eller skriv fortryd");
                }
                Console.WriteLine("\n" + medicalLog);
                //runs until correct change is input or "fortryd" is written
                while (!eventSuccess)
                {
                    //input string will hold what information user wants to change
                    infoToChange = ConsoleInputHelper.ReadStringFromConsole("\nHvad vil du gerne ændre? (muligheder: dyr, dato, læge, beskrivelse, fortyd)");
                    string inputChange = "";
                    if (infoToChange == "fortryd")
                    {
                        break;
                    }
                    switch (infoToChange)
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
                    MedicalLogRepo.Update(medicalLog, infoToChange, inputChange);
                    
                    bool inputConfirm = ConsoleInputHelper.ReadBoolFromConsole("Vil du ændre andet? (ja/nej)");
                    if (!inputConfirm)
                    {
                        eventSuccess = true;
                    }
                }
            }
        }
    }
}
