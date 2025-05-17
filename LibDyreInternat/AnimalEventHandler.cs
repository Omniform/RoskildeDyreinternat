using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class AnimalEventHandler :IEventHandler
    {
        public static void Add()
        {
            string animal = "";
            Console.WriteLine("Hvilket dyr vil du tilføje\nHund, Kat, Fisk\n");
            animal = Console.ReadLine();
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
            }
        }
        public static void ShowAnimals()
        {
            string animal = "";
            Console.WriteLine("Hvilke dyr vil de se\nMuligheder: Hunde, Katte, Fisk, Alle Dyr\n");
            animal = Console.ReadLine();
            switch (animal.ToLower())
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
            }
        }
        public static void Update()
        {
            string animal = "";
            Console.WriteLine("Hvilket dyr vil du ændre\nHund, Kat, Fisk");
            animal = Console.ReadLine();
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
            }
        }
        public static void Remove()
        {
            string animal = "";
            Console.WriteLine("Hvilket dyr vil du fjerne\nHund, Kat, Fisk");
            animal = Console.ReadLine();
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
            }
        }
        

        #region Animal AddMethods
        private static void AddDog()
        {
            Console.WriteLine("Navn");
            string name = Console.ReadLine();

            Console.WriteLine("Fødselsår");
            int birthYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Weight");
            int weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast køn: Han, Hun, Tvekønnet");
            string sex = Console.ReadLine().ToLower();
            Sex s;
            switch (sex)
            {
                case "han":
                    s = Sex.male;
                    break;
                case "hun":
                    s = Sex.female;
                    break;
                case "tvekønnet":
                    s = Sex.hermaphrodite;
                    break;
                default:
                    throw new ArgumentException($"Unknown sex value: {sex}");
            }

            Console.WriteLine("Race");
            string race = Console.ReadLine();

            Console.WriteLine("Foder præferencer");
            string foodPrefrences = Console.ReadLine();

            Console.WriteLine("Chipnummer");
            int chipNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Børnevenlig Ja/Nej");
            string isChildFriendly = Console.ReadLine().ToLower();
            bool friendly;
            if (isChildFriendly == "ja")
            {
                friendly = true;
            }
            else
            {
                friendly = false;
            }

            Console.WriteLine("Muligehed for adoption");
            string isUpForAdoption = Console.ReadLine().ToLower();
            bool adoptionStatus;
            if (isUpForAdoption == "ja")
            {
                adoptionStatus = true;
            }
            else
            {
                adoptionStatus = false;
            }

            AnimalRepo.AddDog(race, friendly, foodPrefrences, chipNumber, name, birthYear, weight, s, adoptionStatus);

        }

        private static void AddCat()
        {
            Console.WriteLine("Navn");
            string name = Console.ReadLine();

            Console.WriteLine("Fødselsår");
            int birthYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Weight");
            int weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast køn: Han, Hun, Tvekønnet");
            string sex = Console.ReadLine().ToLower();
            Sex s;
            switch (sex)
            {
                case "han":
                    s = Sex.male;
                    break;
                case "hun":
                    s = Sex.female;
                    break;
                case "tvekønnet":
                    s = Sex.hermaphrodite;
                    break;
                default:
                    throw new ArgumentException($"Unknown sex value: {sex}");
            }

            Console.WriteLine("Race");
            string race = Console.ReadLine();

            Console.WriteLine("Foder præferencer");
            string foodPrefrences = Console.ReadLine();

            Console.WriteLine("Chipnummer");
            int chipNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Børnevenlig Ja/Nej");
            string isChildFriendly = Console.ReadLine().ToLower();
            bool friendly;
            if (isChildFriendly == "ja")
            {
                friendly = true;
            }
            else
            {
                friendly = false;
            }

            Console.WriteLine("Muligehed for adoption");
            string isUpForAdoption = Console.ReadLine().ToLower();
            bool adoptionStatus;
            if (isUpForAdoption == "ja")
            {
                adoptionStatus = true;
            }
            else
            {
                adoptionStatus = false;
            }

            AnimalRepo.AddCat(race, friendly, foodPrefrences, chipNumber, name, birthYear, weight, s, adoptionStatus);

        }


        private static void AddFish()
        {
            Console.WriteLine("Navn");
            string name = Console.ReadLine();

            Console.WriteLine("Art");
            string species = Console.ReadLine();

            Console.WriteLine("Fødselsår");
            int birthYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Vedligeholdelse");
            string maintainence = Console.ReadLine();

            Console.WriteLine("Weight");
            int weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast køn: Han, Hun, Tvekønnet");
            string sex = Console.ReadLine().ToLower();
            Sex s;
            switch (sex)
            {
                case "han":
                    s = Sex.male;
                    break;
                case "hun":
                    s = Sex.female;
                    break;
                case "tvekønnet":
                    s = Sex.hermaphrodite;
                    break;
                default:
                    throw new ArgumentException($"Unknown sex value: {sex}");
            }

            Console.WriteLine("Muligehed for adoption");
            string isUpForAdoption = Console.ReadLine();
            bool adoptionStatus;
            if (isUpForAdoption == "Ja")
            {
                adoptionStatus = true;
            }
            else
            {
                adoptionStatus = false;
            }

            AnimalRepo.AddFish(name, species, maintainence, birthYear, weight, s, adoptionStatus);

        }
        #endregion
        #region Animal RemoveMethods
        private static void RemoveDog()
        {
            Console.WriteLine("Hvilken hund vil du fjerne indtast (Id)\n\n");
            Console.WriteLine(AnimalRepo.DogsToString());
            int id = int.Parse(Console.ReadLine());
            Dog tempDog;
            if (AnimalRepo.GetById(id) is Dog)
            {
                tempDog = (Dog)AnimalRepo.GetById(id);
            }
        }


        private static void RemoveCat()
        {
            Console.WriteLine("Hvilken  vil du fjerne indtast (Id)\n\n");
            Console.WriteLine(AnimalRepo.CatsToString());
            int id = int.Parse(Console.ReadLine());
            Cat tempCat;
            if (AnimalRepo.GetById(id) is Cat)
            {
                tempCat = (Cat)AnimalRepo.GetById(id);
            }
        }

        private static void RemoveFish()
        {
            Console.WriteLine("Hvilken fisk vil du fjerne indtast (Id)\n\n");
            Console.WriteLine(AnimalRepo.FishToString());
            int id = int.Parse(Console.ReadLine());
            Fish tempFish;
            if (AnimalRepo.GetById(id) is Fish)
            {
                tempFish = (Fish)AnimalRepo.GetById(id);
            }
        }
        #endregion
        #region Animal UpdateMethods
        private static void UpdateDog()
        {
            Console.WriteLine("Hvilken hund vil du ændre indtast (Id)\n");
            Console.WriteLine(AnimalRepo.DogsToString());
            string hIdInput = Console.ReadLine();
            int hId;

            if (int.TryParse(hIdInput, out hId) && AnimalRepo.GetById(hId) is Dog)
            {
                Dog tempDog = (Dog)AnimalRepo.GetById(hId);
                if (tempDog is Dog)
                {
                    Console.WriteLine("\nHvad du vil ændre?");
                    Console.WriteLine("Navn\nFoder præference\nChipnummer\nFødselsår\nBørnevenlig\nAdoptions status\n");
                    string prop = Console.ReadLine();
                    switch (prop.ToLower())
                    {
                        case "navn":
                            Console.WriteLine($"\nNuværende Navn:");
                            Console.WriteLine(tempDog.Name);
                            Console.WriteLine("\nIndtast nyt navn");
                            string newName = Console.ReadLine();
                            tempDog.Name = newName;

                            break;
                        case "foder præference":
                            Console.WriteLine("\nNuværende Foder:");
                            Console.WriteLine(tempDog.FoodPrefrences);
                            Console.WriteLine("\nIndtast ny foder Infomation");
                            string newFoodInfo = Console.ReadLine();
                            tempDog.FoodPrefrences = newFoodInfo;
                            break;
                        case "chipnummer":
                            Console.WriteLine("\nNuværende chip nummer:");
                            Console.WriteLine(tempDog.ChipNumber);
                            Console.WriteLine("\nIndtast nyt chip nummer:");
                            string chipInput = Console.ReadLine();
                            int newChipNumber;

                            if (int.TryParse(chipInput, out newChipNumber))
                            {
                                tempDog.ChipNumber = newChipNumber;
                                Console.WriteLine("Chipnummer opdateret.");
                            }
                            else
                            {
                                Console.WriteLine("Ugyldigt chipnummer. Indtast venligst et gyldigt heltal.");
                            }
                            break;
                        case "fødselsår":
                            Console.WriteLine("\nNuværende Fødselsår:");
                            Console.WriteLine(tempDog.BirthYear);
                            Console.WriteLine("\nIndtast nyt fødselsår");
                            string fødselsInput = Console.ReadLine();
                            int newBirthYear;

                            if (int.TryParse(fødselsInput, out newBirthYear))
                            {
                                tempDog.BirthYear = newBirthYear;
                                Console.WriteLine("Fødselsår opdateret");
                            }
                            else
                            {
                                Console.WriteLine("Ugyldit fødselsår. Indtast venligst et gyldigt heltal.");
                            }
                            break;
                        case "vægt":
                            Console.WriteLine("\nGamle Vægt:");
                            Console.WriteLine(tempDog.Weight);
                            Console.WriteLine("\nIndtast nuværende vægt");
                            string weightInput = Console.ReadLine();
                            int newWeight;

                            if (int.TryParse(weightInput, out newWeight))
                            {
                                tempDog.Weight = newWeight;
                                Console.WriteLine("Vægt opdateret");
                            }
                            else
                            {
                                Console.WriteLine("Ugyldig vægt. Indtast venligst et gyldigt heltal.");
                            }
                            break;
                        case "børnevenlig":
                            Console.WriteLine("\nBørnevenlig");
                            Console.WriteLine((tempDog.IsChildFriendly)? "Ja" : "Nej");
                            Console.WriteLine("\nBørnevenlig Ja/Nej");
                            string input = Console.ReadLine().ToLower();
                            if (input == "ja")
                            {
                                tempDog.IsChildFriendly = true;
                            }
                            else
                            {
                                tempDog.IsChildFriendly = false;
                            }
                            break;
                        case "adoptions status":
                            Console.WriteLine("\nAdoptions status");
                            Console.WriteLine((tempDog.IsUpForAdoption)? "Adopteret" : "Ikke adopteret");
                            Console.WriteLine("\nMulighed for adoption Ja/Nej");
                            string adoptionInput = Console.ReadLine().ToLower();
                            if (adoptionInput == "ja")
                            {
                                tempDog.IsUpForAdoption = true;
                            }
                            else
                            {
                                tempDog.IsUpForAdoption = false;
                            }
                            break;
                    }
                    Console.WriteLine("\nOpdateret");
                    Console.WriteLine(tempDog);
                }
            }
            else Console.WriteLine("Ingen hund med dette id eksistere");
        }

        private static void UpdateCat()
        {
            Console.WriteLine("Hvilken kat vil du ændre indtast (Id)\n");
            Console.WriteLine(AnimalRepo.CatsToString());
            string cIdInput = Console.ReadLine();
            int cId;
            if (int.TryParse(cIdInput, out cId) && AnimalRepo.GetById(cId) is Cat)
            {
                Cat tempCat = (Cat)AnimalRepo.GetById(cId);
                if (tempCat is Cat)
                {
                    Console.WriteLine("\nVælge hvad du vil ændre");
                    Console.WriteLine("Navn\nFoder præference\nChipnummer\nFødselsår\nBørnevenlig\nAdoptions status\n");
                    string prop = Console.ReadLine();
                    switch (prop.ToLower())
                    {
                        case "navn":
                            Console.WriteLine("\nNuværende Navn:");
                            Console.WriteLine(tempCat.Name);
                            Console.WriteLine("\nIndtast nyt navn");
                            string newName = Console.ReadLine();
                            tempCat.Name = newName;
                            break;
                        case "foder præference":
                            Console.WriteLine("\nNuværende Foder:");
                            Console.WriteLine(tempCat.FoodPrefrences);
                            Console.WriteLine("\nIndtast nye Foder Infomation");
                            string newFoodInfo = Console.ReadLine();
                            tempCat.FoodPrefrences = newFoodInfo;
                            break;
                        case "chipnummer":
                            Console.WriteLine("\nNuværende Chip nummer:");
                            Console.WriteLine(tempCat.ChipNumber);
                            Console.WriteLine("\nIndtast nyt chip nummer");
                            string chipInput = Console.ReadLine();
                            int newChipNumber;

                            if (int.TryParse(chipInput, out newChipNumber))
                            {
                                tempCat.ChipNumber = newChipNumber;
                                Console.WriteLine("Chipnummer Opdateret");
                            }
                            else Console.WriteLine("Ugyldigt chip nummer");
                            break;
                        case "Fødselsår":
                            Console.WriteLine("\nNuværende Fødselsår:");
                            Console.WriteLine(tempCat.BirthYear);
                            Console.WriteLine("\nIndtast nyt fødselsår");
                            string birthInput = Console.ReadLine();
                            int newBirthYear;

                            if (int.TryParse(birthInput, out newBirthYear))
                            {
                                tempCat.BirthYear = newBirthYear;
                                Console.WriteLine("Fødselsår opdateret");
                            }
                            else Console.WriteLine("Ugyldigt fødselsår");
                            break;
                        case "vægt":
                            Console.WriteLine("\nGamle Vægt:");
                            Console.WriteLine(tempCat.Weight);
                            Console.WriteLine("\nIndtast nuværende vægt");
                            string weightInput = Console.ReadLine();
                            int newWeight;

                            if (int.TryParse(weightInput, out newWeight))
                            {
                                tempCat.Weight = newWeight;
                                Console.WriteLine("Vægt opdateret");
                            }
                            else Console.WriteLine("Ugyldigt vægt");
                            break;
                        case "børnevenlig":
                            Console.WriteLine("\nBørnevenlig");
                            Console.WriteLine((tempCat.IsChildFriendly)? "Ja" : "Nej");
                            Console.WriteLine("\nBørnevenlig Ja/Nej");
                            string input = Console.ReadLine().ToLower();
                            if (input == "ja")
                            {
                                tempCat.IsChildFriendly = true;
                            }
                            else
                            {
                                tempCat.IsChildFriendly = false;
                            }
                            break;
                        case "adoptions status":
                            Console.WriteLine("\nAdoptions status");
                            Console.WriteLine((tempCat.IsUpForAdoption)? "Adopteret" : "Ikke adopteret");
                            Console.WriteLine("\nMulighed for adoption Ja/Nej");
                            string adoptionInput = Console.ReadLine().ToLower();
                            if (adoptionInput == "ja")
                            {
                                tempCat.IsUpForAdoption = true;
                            }
                            else
                            {
                                tempCat.IsUpForAdoption = false;
                            }
                            break;
                    }
                    Console.WriteLine("\nOpdateret");
                    Console.WriteLine(tempCat);
                }

            }
            else Console.WriteLine("Ingen kat med dette id eksistere");
        }

        private static void UpdateFish()
        {
            Console.WriteLine("Hvilken fisk vil du ændre indtast (Id)\n");
            Console.WriteLine(AnimalRepo.FishToString());
            string fIdInput = Console.ReadLine();
            int fId;

            if (int.TryParse(fIdInput, out fId) && AnimalRepo.GetById(fId) is Fish)
            {
                Fish tempFish = (Fish)AnimalRepo.GetById(fId);
                if (tempFish is Fish)
                {
                    Console.WriteLine("\nVælg hvad du vil ændre");
                    Console.WriteLine("Navn\nFødselsår\nVedligeholdelse\nVægt\nAdoptions status\n");
                    string prop = Console.ReadLine();
                    switch (prop.ToLower())
                    {
                        case "navn":
                            Console.WriteLine("\nNuværende Navn:");
                            Console.WriteLine(tempFish.Name);
                            Console.WriteLine("\nIndtast nyt navn");
                            string newName = Console.ReadLine();
                            tempFish.Name = newName;
                            break;
                        case "fødselsår":
                            Console.WriteLine("\nFødselsår:");
                            Console.WriteLine(tempFish.BirthYear);
                            Console.WriteLine("\nIndtast nyt fødselsår");
                            string birthInput = Console.ReadLine();
                            int newBirthYear;

                            if (int.TryParse(birthInput, out newBirthYear))
                            {
                                tempFish.BirthYear = newBirthYear;
                            }
                            else
                            {
                                Console.WriteLine("Ugyldigt input. Indtast venligst et gyldigt heltal.");
                            }
                            break;
                        case "vedligeholdelse":
                            Console.WriteLine("\nVedligeholdelse:");
                            Console.WriteLine(tempFish.Maintainence);
                            Console.WriteLine("\nIndtast Maintainence");
                            string newMaintainence = Console.ReadLine();
                            tempFish.Maintainence = newMaintainence;
                            break;
                        case "vægt":
                            Console.WriteLine("\nGamle vægt:");
                            Console.WriteLine(tempFish.Weight);
                            Console.WriteLine("\nIndtast nuværende vægt");
                            string weightInput = Console.ReadLine();
                            int newWeight;

                            if (int.TryParse(weightInput, out newWeight))
                            {
                                tempFish.Weight = newWeight;
                            }
                            else
                            {
                                Console.WriteLine("Ugyldigt input. Indtast venligst et gyldigt heltal.");
                            }
                            break;
                            case "adoptions status":
                            Console.WriteLine("\nAdoptions status");
                            Console.WriteLine((tempFish.IsUpForAdoption)? "Adopteret" : "Ikke adopteret");
                            Console.WriteLine("\nMulighed for adoption Ja/Nej");
                            string adoptionInput = Console.ReadLine().ToLower();
                            if (adoptionInput == "ja")
                            {
                                tempFish.IsUpForAdoption = true;
                            }
                            else
                            {
                                tempFish.IsUpForAdoption = false;
                            }
                            break;
                    }
                    Console.WriteLine("\nOpdateret");
                    Console.WriteLine(tempFish);
                }
            }
            else Console.WriteLine("Ingen fisk med dette id eksistere");
        }

        #endregion
    }
}
