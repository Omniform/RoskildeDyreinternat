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
using static System.Runtime.InteropServices.JavaScript.JSType;


public static class ValueEventHandler
{

    private static bool m_eventSuccess = false;


    public static void ValueAnimal(string key)
    {
        switch (key)
        {
            case "se":
                AnimalEventHandler.ShowAnimals();
                break;
            case "tilføj":
                AnimalEventHandler.Add();
                break;
            case "fjern":
                AnimalEventHandler.Remove();
                break;
            case "ændr":
                AnimalEventHandler.Update();
                break;
        }
    }

    #region MedicalLogHandler
    public static void ValueMedicalLog(string key)
    {
        switch (key)
        {
            case "se":
                Console.WriteLine(MedicalLogRepo.AllToString());
                break;
            case "tilfoj":
                //AddMedicalLog();
                MedicalLogEventHandler.Add();
                break;
            case "fjern":
                MedicalLogEventHandler.Remove();
                break;
            case "ændr":
                MedicalLogEventHandler.Update();
                break;
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
				PersonEventHandler.CreateNewPerson();
                break;

			case "fjern":
                PersonEventHandler.DeletePerson();
				break;

			case "ændr":
                PersonEventHandler.UpdateInfo();
				break;
		}
	}

	public static void ValueEvent(in string key)
	{
		switch (key)
		{
			case "se":
				ShowEvent();
				break;
			case "tilføj":
				AddEvent();
				break;
			case "fjern":
				RemoveEvent();
				break;
			case "ændr":
				EditEvent();
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
                BlogEventHandler.CreateNewBlog();
				break;
				
			case "fjern":
                BlogEventHandler.DeleteBlog();
				break;

			case "ændr":
                BlogEventHandler.UpdateBlog();
				break;
		}
	}

    private static void AddEvent()
    {
        bool succeed = false;
        DateOnly date = default;
        TimeOnly startTime = default;
        TimeOnly endTime = default;
        
        Console.WriteLine("Navn");
        string name = FormattingService.RemoveSpaces(Console.ReadLine());
        while (!succeed)
        {
            Console.WriteLine("Dato\nFormaterings exemple 12-02-2024");

            if (!DateOnly.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid formatering af dato");
                continue;
            }

            Console.WriteLine("Start Tid\nFormaterings exemple 13:53");
            if (!TimeOnly.TryParse(Console.ReadLine(), out startTime))
            {
                Console.WriteLine("Invalid formatering af start tid");
                continue;
            }

            Console.WriteLine("Slut Tid\nFormaterings exemple 13:53");
            if (!TimeOnly.TryParse(Console.ReadLine(), out endTime))
            {
                Console.WriteLine("Invalid formatering af slut tid");
                continue;
            }

            succeed = true;
        }

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
                    break;
                }
            }
            if (coordinator == null)
            {
                Console.WriteLine("Ingen person med dette id");
            }
        }
        EventRepo.Add(new Event(name, date, startTime, endTime, coordinator!));

        Console.WriteLine("Person er blevet tilføjet");
    }

    private static void RemoveEvent()
    {
        Console.WriteLine("Vælg id på aktivitet");
        bool validID = false;
        int id = 0;
        string input = "";
        while (!validID)
        {
            input = Console.ReadLine();
            if (!int.TryParse(input, out id))
            {
                if (input == "se")
                {
                    ShowEvent();
                }
            }
            else
            {
                validID = true;
            }
        }
        EventRepo.Remove(id);
        Console.WriteLine("Aktivitet er fjernet");
    }

    private static void EditEvent()
    {
        Event? selectedEvent = null;
        bool succeed = false;
        int id;

        while (!succeed)
        {
            Console.WriteLine("Vælg id på aktivitet");
            int.TryParse(Console.ReadLine(), out id);

            selectedEvent = EventRepo.GetById(id);

            if (selectedEvent == null)
            {
                Console.WriteLine("Aktivitet med det given id ikke fundet");
                continue;
            }
            succeed = true;
        }
        succeed = false;
        Console.WriteLine("Hvad vil du ændre-----------\n-----------navn\n-----------dato\n-----------koordinator");
        while (!succeed)
        {
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "navn":
                    selectedEvent!.Name = input;
                    break;

                case "dato":
                    ChangeDateAndTime(selectedEvent);
                    break;
                case "koordinator":
                    ChangeCoordinator(selectedEvent);
                    break;
                default:
                    Console.WriteLine("Ugyldigt input prøv igen");
                    succeed = false;
                    break;
            }
            succeed = true;
        }
    }

    private static void ChangeDateAndTime(Event selectedEvent)
    {
        DateOnly date = default;
        TimeOnly startTime = default;
        TimeOnly endTime = default;
        string dateS = "";
        string startTimeS = "";
        string endTimeS = "";

        bool succeed = false;

        while (!succeed)
        {
            Console.WriteLine("Vælg dag\nformatering: 24-05-2025");
            dateS = Console.ReadLine();

            Console.WriteLine("Vælg start tid\nformatering: 09-30");
            startTimeS = Console.ReadLine();

            Console.WriteLine("Vælg slut tid\nformatering: 15-14");
            endTimeS = Console.ReadLine();

            if (!DateOnly.TryParse(dateS, out date))
            {
                Console.WriteLine("Dato formatering forkert");
                continue;
            }
            if (!TimeOnly.TryParse(startTimeS, out startTime))
            {
                Console.WriteLine("Start tid formatering forkert");
                continue;
            }
            if (!TimeOnly.TryParse(endTimeS, out endTime))
            {
                Console.WriteLine("Slut tid formatering forkert");
                continue;
            }

            succeed = true;
        }
        selectedEvent.ChangeDateAndTime(date, startTime, endTime);
    }

    private static void ChangeCoordinator(Event selectedEvent)
    {
        Person? coordinator;
        int coordinatorID;
        bool succeed = false;

        while (!succeed)
        {
            Console.WriteLine(PersonRepo.ReturnListAsString());
            Console.WriteLine("Vælg koordinator ved personens id");
            if (!int.TryParse(Console.ReadLine(), out coordinatorID))
            {
                Console.WriteLine("Du skal give en tal værdi");
                continue;
            }

            coordinator = PersonRepo.GetById(coordinatorID);

            if (coordinator == null)
            {
                Console.WriteLine("Person med det given id ikke fundet");
                continue;
            }

            selectedEvent.Coordinator = coordinator;
            succeed = true;
        }
    }
}
 