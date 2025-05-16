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
                Console.WriteLine("Hvilke dyr vil de se");
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
                Console.WriteLine("Hvilket dyr vil du tilføje");
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
                Console.WriteLine("Hvilket dyr vil du fjerne");
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
                Console.WriteLine("Hvilket dyr vl du ændre");
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
        Console.WriteLine("Hvilken hund vil du ændre indtast (Id)");
        Console.WriteLine(AnimalRepo.DogsToString());
        int hId = int.Parse(Console.ReadLine());
        Dog tempDog = (Dog)AnimalRepo.GetById(hId);
        if (tempDog is Dog)
        {
            Console.WriteLine("Hvad du vil ændre?");
            Console.WriteLine("Navn\nFoder præference\nChipnummer\nFødselsår\nBørnevenlig");
            string prop = Console.ReadLine();
            switch (prop.ToLower())
            {
                case "navn":
                    Console.WriteLine("Nuværende Navn:");
                    Console.WriteLine(tempDog.Name);
                    Console.WriteLine("Indtast nyt navn");
                    string newName = Console.ReadLine();
                    tempDog.Name = newName;
                    break;
                case "foder præference":
                    Console.WriteLine("Nuværende Foder:");
                    Console.WriteLine(tempDog.FoodPrefrences);
                    Console.WriteLine("Indtast ny foder Infomation");
                    string newFoodInfo = Console.ReadLine();
                    tempDog.FoodPrefrences = newFoodInfo;
                    break;
                case "chipnummer":
                    Console.WriteLine("Nuværende chip nummer:");
                    Console.WriteLine(tempDog.ChipNumber);
                    Console.WriteLine("Indtast nyt chip nummer");
                    int newChipNumber = int.Parse(Console.ReadLine());
                    tempDog.ChipNumber = newChipNumber;
                    break;
                case "Fødselsår":
                    Console.WriteLine("Nuværende Fødselsår:");
                    Console.WriteLine(tempDog.BirthYear);
                    Console.WriteLine("Indtast nyt fødselsår");
                    int newBirthYear = int.Parse(Console.ReadLine());
                    tempDog.BirthYear = newBirthYear;
                    break;
                case "vægt":
                    Console.WriteLine("Gamle Vægt:");
                    Console.WriteLine(tempDog.Weight);
                    Console.WriteLine("Indtast nuværende vægt");
                    int newWeight = int.Parse(Console.ReadLine());
                    tempDog.Weight = newWeight;
                    break;
                case "børnevenlig":
                    Console.WriteLine("Børnevenlig");
                    Console.WriteLine(tempDog.IsChildFriendly);
                    Console.WriteLine("Børnevenlig Ja/Nej");
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
        }
        // der skal laves noget try catch her
        else Console.WriteLine("Ingen hund med dette id eksistere");
    }

    private static void UpdateCat()
    {
        Console.WriteLine("Hvilken kat vil du ændre indtast (Id)");
        Console.WriteLine(AnimalRepo.CatsToString());
        int cId = int.Parse(Console.ReadLine());
        Cat tempCat;
        if (AnimalRepo.GetById(cId) is Cat)
        {
            tempCat = (Cat)AnimalRepo.GetById(cId);
            Console.WriteLine("Vælge hvad du vil ændre");
            Console.WriteLine("Navn\nFoder præference\nChipnummer\nFødselsår\nBørnevenlig");
            string prop = Console.ReadLine();
            switch (prop.ToLower())
            {
                case "navn":
                    Console.WriteLine("Nuværende Navn:");
                    Console.WriteLine(tempCat.Name);
                    Console.WriteLine("Indtast nyt navn");
                    string newName = Console.ReadLine();
                    tempCat.Name = newName;
                    break;
                case "foder præference":
                    Console.WriteLine("Nuværende Foder:");
                    Console.WriteLine(tempCat.FoodPrefrences);
                    Console.WriteLine("Indtast nye Foder Infomation");
                    string newFoodInfo = Console.ReadLine();
                    tempCat.FoodPrefrences = newFoodInfo;
                    break;
                case "chipnummer":
                    Console.WriteLine("Nuværende Chip nummer:");
                    Console.WriteLine(tempCat.ChipNumber);
                    Console.WriteLine("Indtast nyt chip nummer");
                    int newChipNumber = int.Parse(Console.ReadLine());
                    tempCat.ChipNumber = newChipNumber;
                    break;
                case "Fødselsår":
                    Console.WriteLine("Nuværende Fødselsår:");
                    Console.WriteLine(tempCat.BirthYear);
                    Console.WriteLine("Indtast nyt fødselsår");
                    int newBirthYear = int.Parse(Console.ReadLine());
                    tempCat.BirthYear = newBirthYear;
                    break;
                case "vægt":
                    Console.WriteLine("Gamle Vægt:");
                    Console.WriteLine(tempCat.Weight);
                    Console.WriteLine("Indtast nuværende vægt");
                    int newWeight = int.Parse(Console.ReadLine());
                    tempCat.Weight = newWeight;
                    break;
                case "børnevenlig":
                    Console.WriteLine("Børnevenlig");
                    Console.WriteLine(tempCat.IsChildFriendly);
                    Console.WriteLine("Børnevenlig Ja/Nej");
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
        }
    }
    private static void UpdateFish()
    {
        Console.WriteLine("Hvilken fisk vil du ændre indtast (Id)");
        Console.WriteLine(AnimalRepo.FishToString());
        int fId = int.Parse(Console.ReadLine());
        Fish tempFish;
        if (AnimalRepo.GetById(fId) is Fish)
        {
            tempFish = (Fish)AnimalRepo.GetById(fId);
            Console.WriteLine("Vælge hvad du vil ændre");
            Console.WriteLine("Navn\nFødselsår\nVedligeholdelse\nVægt");
            string prop = Console.ReadLine();
            switch (prop.ToLower())
            {
                case "navn":
                    Console.WriteLine("Nuværende Navn:");
                    Console.WriteLine(tempFish.Name);
                    Console.WriteLine("Indtast nyt navn");
                    string newName = Console.ReadLine();
                    tempFish.Name = newName;
                    break;
                case "fødselsår":
                    Console.WriteLine("Fødselsår:");
                    Console.WriteLine(tempFish.BirthYear);
                    Console.WriteLine("Indtast nyt fødselsår");
                    int newBirthYear = int.Parse(Console.ReadLine());
                    tempFish.BirthYear = newBirthYear;
                    break;
                case "vedligeholdelse":
                    Console.WriteLine("Vedligeholdelse:");
                    Console.WriteLine(tempFish.Maintainence);
                    Console.WriteLine("Indtast Maintainence");
                    string newMaintainence = Console.ReadLine();
                    tempFish.Maintainence = newMaintainence;
                    break;
                case "Vægt":
                    Console.WriteLine("Gamle vægt:");
                    Console.WriteLine(tempFish.Weight);
                    Console.WriteLine("Indtast nuværende vægt");
                    int newWeight = int.Parse(Console.ReadLine());
                    tempFish.Weight = newWeight;
                    break;
            }
        }
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
            catch (NoSearhResultException ex)
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
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Prøv igen, eller skriv fortryd");
            }
        }
    }

    public static void ValueActivity(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(ActivityRepo.ReturnListAsString());
                break;
            case "tilføj":
                AddActivity();
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
            catch (NoSearhResultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Prøv igen, eller skriv fortryd");
            }
        }
    }

    private static void AddActivity()
    {
        Console.WriteLine("Navn");
    }

}
 