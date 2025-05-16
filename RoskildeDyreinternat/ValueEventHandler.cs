using LibDyreInternat;
using Library;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
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
                        ValueEventHandler.AddDog();
                        break;
                    case "cat":
                        ValueEventHandler.AddCat();
                        break;
                    case "fisk":
                        ValueEventHandler.AddFish();
                        break;
                }
                break;
            case "fjern":
                Console.WriteLine("Hvilket dyr vil du fjerne\n");
                dyr = Console.ReadLine();
                switch (dyr.ToLower())
                {
                    case "hund":
                        ValueEventHandler.RemoveDog();
                        break;
                    case "cat":
                        ValueEventHandler.RemoveCat();
                        break;
                    case "fisk":
                        ValueEventHandler.RemoveFish();
                        break;
                }
                break;
            case "ændr":
                Console.WriteLine("Hvilket dyr vl du ændre\n");
                dyr = Console.ReadLine();
                switch (dyr.ToLower())
                {
                    case "hund":
                        ValueEventHandler.UpdateDog();
                        break;
                    case "kat":
                        ValueEventHandler.UpdateCat();
                        break;
                    case "fisk":
                        ValueEventHandler.UpdateFish();
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
            catch (NoSearhResultException ex)
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
                Console.WriteLine("\nHvad vil du gerne ændre i denne log? (ja/nej) ");
                Console.WriteLine("\n" + medicalLog);
                input = Console.ReadLine();
                switch (input)
                {
                    case "hvem":
                        break;
                    case "dato":
                        break;
                    case "tidspunkt":
                        break;
                    case "dyrlæge":
                        break;
                    case "beskrivelse":
                        break;
                }
            }
            catch (NoSearhResultException ex)
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
                ChangePerson();
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
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    private static void ChangePerson()
    {
        Console.WriteLine(PersonRepo.ReturnListAsString(PersonRepo.AllPersons) + "\n");
        Console.WriteLine("Hvilken person vil du ændr? Intast persons ID");
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
                Console.WriteLine("\nEr du sikker på at du vil ændr denne person? (ja/nej)");
                Console.WriteLine("\n" + person);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        Console.WriteLine("Navn");
                        string newName = Console.ReadLine();

                        Console.WriteLine("Fødselsdag");
                        string newBirthday = Console.ReadLine();

                        Console.WriteLine("Adresse");
                        string newAddress = Console.ReadLine();

                        Console.WriteLine("Telefonnummer");
                        string newTelephoneNumber = Console.ReadLine();

                        Console.WriteLine("E-mail");
                        string newEmail = Console.ReadLine();

                        //Console.WriteLine("Brugerens adgangsniveau");
                        //string Acceslevel = Console.ReadLine();

                        Console.WriteLine("Person er ændret");
                        break;

                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    public static void ValueActivity(string key)
    {
        switch (key)
        {
            case "se":
                break;
            case "tilføj":
                break;
            case "fjern":
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
                ChangeBlog();
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
        Console.WriteLine("Dato er sat til "+ Date.ToString());

        Console.WriteLine("Activity");
        Activity Activity = ActivityRepo.FilterActivitiesByName(Console.ReadLine()).ElementAt(0);
        

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
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }

    private static void ChangeBlog()
    {
        Console.WriteLine(BlogRepo.ReturnListAsString(BlogRepo.AllBlogs) + "\n");
        Console.WriteLine("Hvilken blog vil du ændr? Intast blog ID");
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
                Console.WriteLine("\nEr du sikker på at du vil ændr denne blog? (ja/nej)");
                Console.WriteLine("\n" + blog);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        Console.WriteLine("Title");
                        string newTitle = Console.ReadLine();

                        Console.WriteLine("Description");
                        string newDescription = Console.ReadLine();

                        Console.WriteLine("Date");
                        DateTime newDate = DateTime.Now;

                        //Console.WriteLine("Activity");
                        //Activity newActivity = 

                        Console.WriteLine("Author");
                        string newAuthor = Console.ReadLine();

                        Console.WriteLine("Blog er ændret");
                        break;

                    case "nej":
                        break;
                }
            }
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("prov igen, eller skriv fortryd");
            }
        }
    }


}
 