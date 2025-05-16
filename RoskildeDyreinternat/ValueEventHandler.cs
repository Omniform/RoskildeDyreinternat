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
                Console.WriteLine("Hvilket dyr vil du fjerne");
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
                Console.WriteLine("Hvilket dyr vl du ændre");
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
        string Name = Console.ReadLine();

        Console.WriteLine("Fødselsår");
        int BirthYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Weight");
        int Weight = int.Parse(Console.ReadLine());

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
        string Race = Console.ReadLine();

        Console.WriteLine("Foder præferencer");
        string FoodPrefrences = Console.ReadLine();

        Console.WriteLine("Chipnummer");
        int ChipNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("");
        string IsChildFriendly = Console.ReadLine();
        bool Friendly;
        if (IsChildFriendly == "Ja")
        {
            Friendly = true;
        }
        else
        {
            Friendly = false;
        }

        AnimalRepo.AddDog(Race, Friendly, FoodPrefrences, ChipNumber, Name, BirthYear, Weight, s);

    }


    private static void AddCat()
    {
        Console.WriteLine("Navn");
        string Name = Console.ReadLine();

        Console.WriteLine("Fødselsår");
        int BirthYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Weight");
        int Weight = int.Parse(Console.ReadLine());

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
        string Race = Console.ReadLine();

        Console.WriteLine("Foder præferencer");
        string FoodPrefrences = Console.ReadLine();

        Console.WriteLine("Chipnummer");
        int ChipNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("");
        string IsChildFriendly = Console.ReadLine();
        bool Friendly;
        if (IsChildFriendly == "Ja")
        {
            Friendly = true;
        }
        else
        {
            Friendly = false;
        }

        AnimalRepo.AddCat(Race, Friendly, FoodPrefrences, ChipNumber, Name, BirthYear, Weight, s);

    }


    private static void AddFish()
    {
        Console.WriteLine("Navn");
        string Name = Console.ReadLine();

        Console.WriteLine("Fødselsår");
        int BirthYear = int.Parse(Console.ReadLine());

        Console.WriteLine("Weight");
        int Weight = int.Parse(Console.ReadLine());

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

        Console.WriteLine("Art");
        string Species = Console.ReadLine();

        Console.WriteLine("Vedligeholdelse");
        string Maintainence = Console.ReadLine();



        AnimalRepo.AddFish(Species, Maintainence, Name, BirthYear, Weight, s);

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
        Dog tempDog;
        if (AnimalRepo.GetById(hId) is Dog)
        {
            tempDog = (Dog)AnimalRepo.GetById(hId);
            Console.WriteLine("Vælge hvad du vil ændre");
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
                    Console.WriteLine("Indtast nye Foder Infomation");
                    string newFoodInfo = Console.ReadLine();
                    tempDog.FoodPrefrences = newFoodInfo;
                    break;
                case "chipnummer":
                    Console.WriteLine("Nuværende Chip nummer:");
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

        //Console.WriteLine("Activity");
        //Activity Activity = ActivityRepo.FilterActivityByName(Console.Readline()).ElementAt(0);
        //Activity Activity = 

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
 