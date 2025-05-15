using LibDyreInternat;
using Library;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Xml.Linq;




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
            case "tilføj":
                break;
            case "fjern":
                break;
            case "ændr":
                break;

        }
    }

    public static void ValuePerson(string key)
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
 