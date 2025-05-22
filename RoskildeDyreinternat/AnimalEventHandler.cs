using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class AnimalEventHandler :IEventHandler
    {
        public static void Add()
        {
            while (true)
            {
                Console.WriteLine("Hvilket dyr vil du tilføje\nHund, Kat, Fisk\n");
                string animal = ConsoleInputHelper.ReadStringFromConsole("\nIndtast dyr");

                switch (animal.ToLower())
                {
                    case "hund":
                        AddDog();
                        break;
                    case "kat":
                        AddCat();
                        break;
                    case "fisk":
                        AddFish();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt indput. Prøv igen\n");
                        continue;
                }
                break;
            }
        }
        public static void Show()
        {
            while (true)
            {

                Console.WriteLine("Hvilke dyr vil de se\nMuligheder: Hunde, Katte, Fisk, Alle dyr\n");
                string command = ConsoleInputHelper.ReadStringFromConsole("Indtast Hunde, Katte, Fisk eller Alle dyr");

                switch (command.ToLower())
                {
                    case "hunde":
                        Console.WriteLine(AnimalRepo.DogsToString());
                        break;
                    case "katte":
                        Console.WriteLine(AnimalRepo.CatsToString());
                        break;
                    case "fisk":
                        Console.WriteLine(AnimalRepo.FishToString());
                        break;
                    case "alle dyr":
                        AnimalRepo.AnimalsSortedByType();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt indput. Prøv igen");
                        continue;
                }
                break;
            }
        }
        
        public static void Update()
        {
            while (true)
            {
                Console.WriteLine("Hvilket dyr vil du ændre\nHund, Kat, Fisk");
                string animal = Console.ReadLine();

                switch (animal.ToLower())
                {
                    case "hund":
                        UpdateDog();
                        break;
                    case "kat":
                        UpdateCat();
                        break;
                    case "fisk":
                        UpdateFish();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt indput. Prøv igen");
                        continue;
                }
                break;
            }
        }
        public static void Remove()
        {
            while (true)
            {
                Console.WriteLine("Hvilket dyr vil du fjerne\nHund, Kat, Fisk");
                string animal = ConsoleInputHelper.ReadStringFromConsole("\nIndtast Hund, Kat, Fisk");

                switch (animal.ToLower())
                {
                    case "hund":
                        RemoveDog();
                        break;
                    case "kat":
                        RemoveCat();
                        break;
                    case "fisk":
                        RemoveFish();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt indput.Prøv igen");
                        continue;
                }
                break;
                
            }
        }
        

        #region Animal AddMethods
        private static void AddDog()
        {
            
            string name = ConsoleInputHelper.ReadStringFromConsole("\nIndtast navn:");

            int birthYear = ConsoleInputHelper.ReadIntFromConsole("\nIndtast Fødselsår");

            int weight = ConsoleInputHelper.ReadIntFromConsole("\nIndtast vægt:");

            Sex s = ConsoleInputHelper.ReadSexFromConsole();
           
            string race = ConsoleInputHelper.ReadStringFromConsole("\nIndtast race");

            string foodPrefrences = ConsoleInputHelper.ReadStringFromConsole("\nIndtast foder præferencer");

            int chipNumber = ConsoleInputHelper.ReadIntFromConsole("\nChipnummer");

            bool isChildFriendly = ConsoleInputHelper.ReadBoolFromConsole("\nBørnevenlig Ja/Nej");

            bool adoptionStatus = ConsoleInputHelper.ReadBoolFromConsole("\nMulighed for adoption");

            AnimalRepo.AddDog(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, s, adoptionStatus);

        }

        private static void AddCat()
        {
            
            string name = ConsoleInputHelper.ReadStringFromConsole("\nIndtast Navn");

            int birthYear = ConsoleInputHelper.ReadIntFromConsole("\nIndtast fødselsår:");

            int weight = ConsoleInputHelper.ReadIntFromConsole("\nIndtast vægt:");

            Sex s = ConsoleInputHelper.ReadSexFromConsole();
           
            string race = ConsoleInputHelper.ReadStringFromConsole("\nIndtast race");

            string foodPrefrences = ConsoleInputHelper.ReadStringFromConsole("\nIndtast foder præferencer");

            int chipNumber = ConsoleInputHelper.ReadIntFromConsole("\nChipnummer");

            bool isChildFriendly = ConsoleInputHelper.ReadBoolFromConsole("\nBørnevenlig Ja/Nej");

            bool adoptionStatus = ConsoleInputHelper.ReadBoolFromConsole("\nMulighed for adoption");

            AnimalRepo.AddCat(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, s, adoptionStatus);

        }


        private static void AddFish()
        {
            string name = ConsoleInputHelper.ReadStringFromConsole("\nNavn");

            string species = ConsoleInputHelper.ReadStringFromConsole("\nArt");

            int birthYear = ConsoleInputHelper.ReadIntFromConsole("\nIndtast fødselsår:");

            string maintainence = ConsoleInputHelper.ReadStringFromConsole("\nVedligeholdelse");

            int weight = ConsoleInputHelper.ReadIntFromConsole("\nIndtast vægt:");

            Sex s = ConsoleInputHelper.ReadSexFromConsole();

            bool adoptionStatus = ConsoleInputHelper.ReadBoolFromConsole("\nMulighed for adoption");
            

            AnimalRepo.AddFish(name, species, maintainence, birthYear, weight, s, adoptionStatus);

        }
        #endregion
        #region Animal RemoveMethods
        private static void RemoveDog()
        {
            Console.WriteLine("Hvilken hund vil du fjerne?");
            Console.WriteLine();
            Console.WriteLine(AnimalRepo.DogsToString());

            int id = ConsoleInputHelper.ReadIntFromConsole("Indtast Id");

            if (AnimalRepo.GetById(id) is Dog tempDog)
            {
                AnimalRepo.Remove(tempDog);
                Console.WriteLine("Hunden blev fjernet");
            }
            else
            {
                Console.WriteLine("Ingen hund med det id blev fundet");
            }
        }


        private static void RemoveCat()
        {
            Console.WriteLine("Hvilken kat vil du fjerne?");
            Console.WriteLine();
            Console.WriteLine(AnimalRepo.CatsToString());

            int id = ConsoleInputHelper.ReadIntFromConsole("Indtast Id");

            if (AnimalRepo.GetById(id) is Cat tempCat)
            {
                AnimalRepo.Remove(tempCat);
                Console.WriteLine("Katten blev fjernet");
            }
            else
            {
                Console.WriteLine("Ingen kat med det id blev fundet");
            }
        }

        private static void RemoveFish()
        {
            Console.WriteLine("Hvilken fisk vil du fjerne?");
            Console.WriteLine();
            Console.WriteLine(AnimalRepo.FishToString());

            int id = ConsoleInputHelper.ReadIntFromConsole("Indtast Id");

            if (AnimalRepo.GetById(id) is Fish tempFish)
            {
                AnimalRepo.Remove(tempFish);
                Console.WriteLine("Fisken blev fjernet");
            }
            else
            {
                Console.WriteLine("Ingen fisk med dette id blev fundet");
            }
        }
        #endregion
        #region Animal UpdateMethods
        private static void UpdateDog()
        {
            int hId = ConsoleInputHelper.ReadIntFromConsole("Hvilken hund vil du ændre indtast (Id)\n" + AnimalRepo.DogsToString());

            if (AnimalRepo.GetById(hId) is Dog)
            {
                Dog tempDog = (Dog)AnimalRepo.GetById(hId);
                
                string prop = ConsoleInputHelper.ReadStringFromConsole("\nHvad du vil ændre?\nNavn\npræference\nChipnummer\nFødselsår\nBørnevenlig\nAdoptions status\n");
                switch (prop.ToLower())
                {
                    case "navn":
                        tempDog.Name = ConsoleInputHelper.ReadStringFromConsole($"\nNuværende Navn: {tempDog.Name}\nIndtast nyt navn");
                        break;

                    case "foder præference":
                        tempDog.FoodPrefrences = ConsoleInputHelper.ReadStringFromConsole($"\nNuværende Foder: {tempDog.FoodPrefrences}\nIndtast ny foder Infomation");
                        break;

                    case "chipnummer":
                        tempDog.ChipNumber = ConsoleInputHelper.ReadIntFromConsole($"\nNuværende chip nummer: {tempDog.ChipNumber}\nIndtast nyt chip nummer");
                        break;

                    case "fødselsår":
                        tempDog.BirthYear = ConsoleInputHelper.ReadIntFromConsole($"\nNuværende Fødselsår: {tempDog.BirthYear}\nIndtast nyt fødselsår");
                        break;

                    case "vægt":
                        tempDog.Weight = ConsoleInputHelper.ReadIntFromConsole($"\nGamle vægt {tempDog.Weight}\nIndtast nuværende vægt");
                        break;

                    case "børnevenlig":
                        tempDog.IsChildFriendly = ConsoleInputHelper.ReadBoolFromConsole($"\nBørnevenlig: {(tempDog.IsChildFriendly? "Ja" : "Nej")}\nBørnevenlig Ja/Nej");
                        break;

                    case "adoptions status":
                        tempDog.IsUpForAdoption = ConsoleInputHelper.ReadBoolFromConsole($"\nAdoptions status: {(tempDog.IsUpForAdoption? "Ja" : "Nej")}\nMulighed for adoption Ja/Nej");
                        break;
                }
                Console.WriteLine("\nOpdateret");
                Console.WriteLine(tempDog);
            }
            else Console.WriteLine("Ingen hund med dette id eksistere");
        }


        private static void UpdateCat()
        {
            int cId = ConsoleInputHelper.ReadIntFromConsole("Hvilken kat vil du ændre indtast (Id)\n" + AnimalRepo.CatsToString());

            if (AnimalRepo.GetById(cId) is Cat)
            {
                Cat tempCat = (Cat)AnimalRepo.GetById(cId);

                string prop = ConsoleInputHelper.ReadStringFromConsole("\nHvad du vil ændre?\nNavn\npræference\nChipnummer\nFødselsår\nBørnevenlig\nAdoptions status\n");
                switch (prop.ToLower())
                {
                    case "navn":
                        tempCat.Name = ConsoleInputHelper.ReadStringFromConsole($"\nNuværende Navn: {tempCat.Name}\nIndtast nyt navn");
                        break;

                    case "foder præference":
                        tempCat.FoodPrefrences = ConsoleInputHelper.ReadStringFromConsole($"\nNuværende Foder: {tempCat.FoodPrefrences}\nIndtast ny foder Infomation");
                        break;

                    case "chipnummer":
                        tempCat.ChipNumber = ConsoleInputHelper.ReadIntFromConsole($"\nNuværende chip nummer: {tempCat.ChipNumber}\nIndtast nyt chip nummer");
                        break;

                    case "fødselsår":
                        tempCat.BirthYear = ConsoleInputHelper.ReadIntFromConsole($"\nNuværende Fødselsår: {tempCat.BirthYear}\nIndtast nyt fødselsår");
                        break;

                    case "vægt":
                        tempCat.Weight = ConsoleInputHelper.ReadIntFromConsole($"\nGamle vægt {tempCat.Weight}\nIndtast nuværende vægt");
                        break;

                    case "børnevenlig":
                        tempCat.IsChildFriendly = ConsoleInputHelper.ReadBoolFromConsole($"\nBørnevenlig: {(tempCat.IsChildFriendly ? "Ja" : "Nej")}\nBørnevenlig Ja/Nej");
                        break;

                    case "adoptions status":
                        tempCat.IsUpForAdoption = ConsoleInputHelper.ReadBoolFromConsole($"\nAdoptions status: {(tempCat.IsUpForAdoption ? "Ja" : "Nej")}\nMulighed for adoption Ja/Nej");
                        break;
                }
                Console.WriteLine("\nOpdateret");
                Console.WriteLine(tempCat);
            }
            else Console.WriteLine("Ingen kat med dette id eksistere");
        }

        private static void UpdateFish()
        {
            int fId = ConsoleInputHelper.ReadIntFromConsole("Hvilken fisk vil du ændre indtast (Id)\n" + AnimalRepo.FishToString());

            if (AnimalRepo.GetById(fId) is Fish)
            {
                Fish tempFish = (Fish)AnimalRepo.GetById(fId);

                string prop = ConsoleInputHelper.ReadStringFromConsole("\nHvad du vil ændre?\nNavn\nArt\nFødselsår\nVedligeholdelse\nAdoptions status\nVægt");
                switch (prop.ToLower())
                {
                    case "navn":
                        tempFish.Name = ConsoleInputHelper.ReadStringFromConsole($"\nNuværende Navn: {tempFish.Name}\nIndtast nyt navn");
                        break;

                    case "art":
                        tempFish.Species = ConsoleInputHelper.ReadStringFromConsole($"\nNuværende art: {tempFish.Species}\nIndtast ny art Infomation");
                        break;

                    case "vedligeholdelse":
                        tempFish.Maintainence = ConsoleInputHelper.ReadStringFromConsole($"\nVedligeholdelse: {tempFish.Maintainence}\nIndtast Vedligeholdelses information");
                        break;

                    case "fødselsår":
                        tempFish.BirthYear = ConsoleInputHelper.ReadIntFromConsole($"\nNuværende Fødselsår: {tempFish.BirthYear}\nIndtast nyt fødselsår");
                        break;

                    case "vægt":
                        tempFish.Weight = ConsoleInputHelper.ReadIntFromConsole($"\nGamle vægt {tempFish.Weight}\nIndtast nuværende vægt");
                        break;

                    case "adoptions status":
                        tempFish.IsUpForAdoption = ConsoleInputHelper.ReadBoolFromConsole($"\nAdoptions status: {(tempFish.IsUpForAdoption ? "Ja" : "Nej")}\nMulighed for adoption Ja/Nej");
                        break;
                        
                }
                Console.WriteLine("\nOpdateret");
                Console.WriteLine(tempFish);
            }
            else Console.WriteLine("Ingen fisk med dette id eksistere");
        }

        #endregion
    }
}
