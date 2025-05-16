using LibDyreInternat;
using Library;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Xml.Linq;
using static LibDyreInternat.Person;


public static class ValueEventHandler
{

    private static bool m_eventSuccess = false;


    public static void ValueAnimal(string key)
    {
        string dyr = "";
        switch (key)
        {
            case "se":
                Console.WriteLine("Hvilke dyr vil de se\n");
                dyr = Console.ReadLine();
                switch (dyr.ToLower())
                {
                    case "hund":
                        Console.WriteLine(AnimalRepo.DogsToString());
                        break;
                    case "kat":
                        Console.WriteLine(AnimalRepo.CatsToString());
                        break;
                    case "fisk":
                        Console.WriteLine(AnimalRepo.FishToString());
                        break;
                }
                break;
            case "tilføj":
                Console.WriteLine("Hvilket dyr vil du tilføje\n");
                dyr = Console.ReadLine();
                switch (dyr.ToLower())
                {
                    case "hund":
                        AddDog();
                        break;
                    case "cat":
                        AddCat();
                        break;
                    case "fisk":
                        AddFish();
                        break;
                }
                break;
            case "fjern":
                Console.WriteLine("Hvilket dyr vil du fjerne\n");
                dyr = Console.ReadLine();
                switch (dyr.ToLower())
                {
                    case "hund":
                        RemoveDog();
                        break;
                    case "cat":
                        RemoveCat();
                        break;
                    case "fisk":
                        RemoveFish();
                        break;
                }
                break;
            case "ændr":
                Console.WriteLine("Hvilket dyr vl du ændre\n");
                dyr = Console.ReadLine();
                switch (dyr.ToLower())
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
        string sex = Console.ReadLine();
        Sex s;
        switch (sex)
        {
            case "Han":
                s = Sex.male;
                break;
            case "Hun":
                s = Sex.female;
                break;
            case "Tvekønnet":
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

        Console.WriteLine("");
        string isChildFriendly = Console.ReadLine();
        bool friendly;
        if (isChildFriendly == "Ja")
        {
            friendly = true;
        }
        else
        {
            friendly = false;
        }

        AnimalRepo.AddDog(race, friendly, foodPrefrences, chipNumber, name, birthYear, weight, s);

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
        string sex = Console.ReadLine();
        Sex s;
        switch (sex)
        {
            case "Han":
                s = Sex.male;
                break;
            case "Hun":
                s = Sex.female;
                break;
            case "Tvekønnet":
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

        Console.WriteLine("");
        string isChildFriendly = Console.ReadLine();
        bool friendly;
        if (isChildFriendly == "Ja")
        {
            friendly = true;
        }
        else
        {
            friendly = false;
        }

        AnimalRepo.AddCat(race, friendly, foodPrefrences, chipNumber, name, birthYear, weight, s);

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

        AnimalRepo.AddFish(name, species, maintainence, birthYear, weight, s);

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
                Console.WriteLine("Navn\nFoder præference\nChipnummer\nFødselsår\nBørnevenlig\n");
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
                        Console.WriteLine(tempDog.IsChildFriendly);
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
                Console.WriteLine("Navn\nFoder præference\nChipnummer\nFødselsår\nBørnevenlig\n");
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
                        Console.WriteLine(tempCat.IsChildFriendly);
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
                Console.WriteLine("Navn\nFødselsår\nVedligeholdelse\nVægt\n");
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
                }
                Console.WriteLine("\nOpdateret");
                Console.WriteLine(tempFish);
            }
        }
        else  Console.WriteLine("Ingen fisk med dette id eksistere");
    }

    #endregion
    #region MedicalLogHandler
    public static void ValueMedicalLog(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(MedicalLogRepo.AllToString());
                break;
            case "tilfoj":
                AddMedicalLog();
                break;
            case "fjern":
                RemoveMedicalLog();
                break;
            case "ændr":
                UpdateMedicalLog();
                break;
        }
    }

    private static void AddMedicalLog()
    {
        Console.WriteLine("Hvilket dye vil du tilføje en log til?");
        Console.WriteLine(AnimalRepo.AllToString());
        Console.WriteLine("Indtast dyrets ID");
        int selectedId = int.Parse(Console.ReadLine());
        Console.WriteLine("Hvad er blevet undersøgt og/eller løst?");
        string description = Console.ReadLine();
        Console.WriteLine("Hvornår er undersøgelsen el.lign foretaget? (dd-MM-ÅÅÅÅ HH:mm)");
        DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm", null);
        Console.WriteLine("Hvem har foretaget undersogelsen?");
        string nameOfDoctor = Console.ReadLine();


        MedicalLogRepo.Add(description, dateTime, AnimalRepo.GetById(selectedId), nameOfDoctor);
    }

    private static void RemoveMedicalLog()
    {
        m_eventSuccess = false;
        MedicalLog medicalLog = null;
        Console.WriteLine(MedicalLogRepo.AllToString());
        Console.WriteLine("Hvilken log vil du fjerne? (Indtast ID)");
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                medicalLog = MedicalLogRepo.GetById(int.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne log? (ja/nej) ");
                Console.WriteLine("\n" + medicalLog);
                input = Console.ReadLine();
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
    private static void UpdateMedicalLog()
    {
        m_eventSuccess = false;
        MedicalLog medicalLog = null;
        Console.WriteLine(MedicalLogRepo.AllToString());
        Console.WriteLine("Hvilken log vil du ændre? (Indtast ID)");
        string input = Console.ReadLine();
        while (!m_eventSuccess)
        {

            if (input == "fortryd")
            {
                break;
            }
            try
            {
                medicalLog = MedicalLogRepo.GetById(int.Parse(input));


                Console.WriteLine("\n" + medicalLog);
                while (!m_eventSuccess)
                {
                    Console.WriteLine("\nHvad vil du gerne ændre?");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "dyr":
                            Console.WriteLine(AnimalRepo.AllToString() +
                                "\nHvilket er det nye dyr du vil tilknytte loggen?");
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
                            m_eventSuccess = true;
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
    #endregion
    public static void ValuePerson(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons));
                break;

            case "tilføj":
                CreateNewPerson();
                break;

            case "fjern":
                DeletePerson();
                break;

            case "ændr":
                UpdateInfo();
                break;
        }
    }

    private static void CreateNewPerson()
    {
        Console.WriteLine("Navn");
        string Name = Console.ReadLine();

        Console.WriteLine("Birthday");
        string Birthday = Console.ReadLine();

        Console.WriteLine("Address");
        string Address = Console.ReadLine();

        Console.WriteLine("TelephoneNumber");
        string TelephoneNumber = Console.ReadLine();

        Console.WriteLine("Email");
        string Email = Console.ReadLine();

        Console.WriteLine("Adgangs niveau\nAdmin = 1\nMedlem = 2\nKunde = 3");
        Person.Acceslevel PersonAccesLevel = (Person.Acceslevel)int.Parse(Console.ReadLine());
    }

    private static void DeletePerson()
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

    private static void UpdateInfo()
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

    public static void ValueEvent(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(EventRepo.ReturnListAsString());
                break;
            case "tilføj":
                AddEvent();
                break;
            case "fjern":
                RemoveEvent();
                break;
            case "ændr":
                break;

        }
    }

    public static void ValueBlog(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs));
                break;

            case "tilføj":
                CreateNewBlog();
                break;

            case "fjern":
                DeleteBlog();
                break;

            case "ændr":
                UpdateBlog();
                break;
        }
    }

    private static void CreateNewBlog()
    {
        Console.WriteLine("Title");
        string Title = Console.ReadLine();

        Console.WriteLine("Beskrivelse");
        string Description = Console.ReadLine();

        DateTime Date = DateTime.Now;
        Console.WriteLine("Dato er sat til " + Date.ToString());

        Console.WriteLine("Activity");
        Event Activity = EventRepo.FilterActivitiesByName(Console.ReadLine()).ElementAt(0);


        Console.WriteLine("Forfatter");
        string Author = Console.ReadLine();
    }

    private static void DeleteBlog()
    {
        Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
        Console.WriteLine("Hvilken blog vil du slette? Intast blog ID");
        m_eventSuccess = false;
        Blog blog = null;
        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                blog = BlogRepo.GetById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil slette denne blog? (ja/nej) ");
                Console.WriteLine("\n" + blog);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        BlogRepo.Delete(blog.Id);
                        Console.WriteLine("Blog er fjernet");
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

    private static void UpdateBlog()
    {
        Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
        Console.WriteLine("Hvilken blog vil du ændre? Indtast blog ID");
        m_eventSuccess = false;
        Blog blog = null;

        while (!m_eventSuccess)
        {
            string input = Console.ReadLine();
            if (input == "fortryd")
            {
                break;
            }
            try
            {
                blog = BlogRepo.GetById(Int32.Parse(input));
                m_eventSuccess = true;
                Console.WriteLine("\nEr du sikker på at du vil ændre denne blog? (ja/nej)");
                Console.WriteLine("\n" + blog);
                input = Console.ReadLine();

                if (input == "ja")
                {
                    Console.WriteLine("Hvilken egenskab vil du ændre?");
                    Console.WriteLine("1 - Title\n2 - Description\n3 - Date\n4 - Author");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Ny Title:");
                            blog.Title = Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("Ny Description:");
                            blog.Description = Console.ReadLine();
                            break;

                        case "3":
                            Console.WriteLine("Indtast en dato og tidspunkt (dd-MM-yyyy HH:mm):");
                            string inputDateTime = Console.ReadLine();

                            if (DateTime.TryParseExact(inputDateTime, "dd-MM-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                            {
                                Console.WriteLine("Gemmer dato og tid: " + parsedDateTime.ToString("dd-MM-yyyy HH:mm"));
                            }
                            else
                            {
                                Console.WriteLine("Ugyldigt format. Prøv igen.");
                            }
                            break;

                        case "4":
                            Console.WriteLine("Ny Author:");
                            blog.Author = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Ugyldigt valg, prøv igen.");
                            break;
                    }

                    Console.WriteLine("Blog er ændret!");
                }
            }
            catch (NoSearchResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Prøv igen, eller skriv fortryd");
            }
        }
    }

    private static void AddEvent()
    {
        Console.WriteLine("Navn");
        string name = FormattingService.RemoveSpaces(Console.ReadLine());

        Console.WriteLine("Dato\nFormaterings exemple 12-02-2024");
        DateOnly date = DateOnly.Parse(Console.ReadLine());

        Console.WriteLine("Start Tid\nFormaterings exemple 13-53");
        TimeOnly startTime = TimeOnly.Parse(Console.ReadLine());

        Console.WriteLine("Slut Tid\nFormaterings exemple 13-53");
        TimeOnly endTime = TimeOnly.Parse(Console.ReadLine());

        Console.WriteLine("Vælg koordinator ved deres id");
        bool personFound = false;
        int id = int.Parse(Console.ReadLine());
        Person? coordinator = null;
        while (!personFound)
        {
            foreach (var person in PersonRepo.AllPersons)
            {
                if (person.Id == id)
                {
                    coordinator = person;
                    personFound = true;
                }
            }
            if (coordinator == null)
            {
                Console.WriteLine("Ingen person med dette id");
            }
        }
        EventRepo.Add(new Event(name, date, startTime, endTime, coordinator));

        Console.WriteLine("Person er blevet tilføjet");
    }

	public static void RemoveEvent()
	{
		Console.WriteLine("Vælg id på aktivitet");
		int id = int.Parse(Console.ReadLine());
		EventRepo.Remove(id);
		Console.WriteLine("Aktivitet er fjernet");
    }

}
 