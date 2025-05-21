using System.Runtime.CompilerServices;
using LibDyreInternat;

public class EventEventHandler : IEventHandler
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Show()
    {
        Console.WriteLine(EventRepo.ReturnListAsString());
    }

    public static void Add()
    {
        bool succeed = false;
        DateOnly date = default;
        TimeOnly startTime = default;
        TimeOnly endTime = default;

        Console.WriteLine("Navn");
        string name = Console.ReadLine().Trim();
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

        bool personFound = false;
        Person? coordinator = null;
        while (!personFound)
        {
            Console.WriteLine("Vælg koordinator ved deres id");
            int.TryParse(Console.ReadLine().Trim(), out int id);
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

    public static void Remove()
    {
        Console.WriteLine("Vælg id på aktivitet");
        bool validID = false;
        int id = 0;
        string input = "";
        while (!validID)
        {
            input = Console.ReadLine();
            FormattingService.RemoveSpacesRef(ref input);
            if (!int.TryParse(input, out id))
            {
                if (input == "se")
                {
                    Show();
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

    public static void Update()
    {
        Event? selectedEvent = null;
        bool succeed = false;
        int id = 0;

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