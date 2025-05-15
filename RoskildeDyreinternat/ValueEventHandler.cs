using LibDyreInternat;
using Library;
using System;
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
                    case "cat":
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

                break;

        }
    }
    #region AddDog
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

        AnimalRepo.AddDog(Race,Friendly,FoodPrefrences,ChipNumber,Name,BirthYear,Weight, s);
            
    }
    #endregion
    #region AddCat
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
    #endregion
    #region AddFish
    private static void AddFish()
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

        Console.WriteLine("Art");
        string Species = Console.ReadLine();

        Console.WriteLine("Foder præferencer");
        string FoodPrefrences = Console.ReadLine();

   

        AnimalRepo.AddFish(Species, FoodPrefrences, Name, BirthYear, Weight, s);

    }

    #endregion
    #region RemoveDog
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
    #endregion
    #region RemoveCat
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
    #endregion
    #region RemoveFish
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


        MedicalLogRepo.Add(description, dateTime, AnimalRepo.GetAnimalById(selectedId), nameOfDoctor);
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
                Console.WriteLine("\nEr du sikker på at du vil ændr denne person? (ja/nej) ");
                Console.WriteLine("\n" + person);
                input = Console.ReadLine();
                switch (input)
                {
                    case "ja":
                        PersonRepo.Delete(person.Id);
                        CreateNewPerson();
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
                break;
            case "tilføj":
                break;
            case "fjern":
                break;
            case "ændr":
                break;

        }
    }


}
 