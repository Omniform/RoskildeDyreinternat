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
        bool nameSucces = false;
        string name = "";
        DateOnly date = default;
        TimeOnly startTime = default;
        TimeOnly endTime = default;

        while (!nameSucces)
        {
            Console.WriteLine("Navn");
            name = Console.ReadLine();
            FormattingService.RemoveSpaces(ref name);
            if (!string.IsNullOrWhiteSpace(name))
            {
                nameSucces = true;
            }
        }

        while (!succeed)
        {
            Console.WriteLine("\nDato\nFormaterings exemple 12-02-2024");

            if (!DateOnly.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("\nInvalid formatering af dato");
                continue;
            }

            Console.WriteLine("\nStart tid\nFormaterings exemple 13:53");
            if (!TimeOnly.TryParse(Console.ReadLine(), out startTime))
            {
                Console.WriteLine("\nInvalid formatering af start tid");
                continue;
            }

            Console.WriteLine("\nSlut tid\nFormaterings exemple 13:53");
            if (!TimeOnly.TryParse(Console.ReadLine(), out endTime))
            {
                Console.WriteLine("\nInvalid formatering af slut tid");
                continue;
            }

            if (endTime.CompareTo(startTime) != 1)
            {
                Console.WriteLine("\nSlut tid skal være efter start tid");
                continue;
            }

            succeed = true;
        }

        bool personFound = false;
        Person? coordinator = null;
        string coordinatorId = "";
        while (!personFound)
        {
            Console.WriteLine("\nVælg koordinator ved deres id (for at se deres id indtast 'se')");
            coordinatorId = Console.ReadLine().Trim().ToLower();
            int.TryParse(coordinatorId, out int id);

            if (coordinatorId == "se")
            {
                Console.WriteLine($"\n{PersonRepo.AllToString()}");
                continue;
            }

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
                Console.WriteLine("\nIngen person med dette id");
            }
        }
        EventRepo.Add(new Event(name, date, startTime, endTime, coordinator!));

        Console.WriteLine("\nPerson er blevet tilføjet");
    }

    public static void Remove()
    {
        bool validID = false;
        int id = 0;
        string input = "";
        while (!validID)
        {
            Console.WriteLine("Vælg id på aktivitet\nSkriv 'se' for at se alle aktiviteter");
            input = Console.ReadLine().ToLower();
            FormattingService.RemoveSpaces(ref input);
            if (!int.TryParse(input, out id))
            {
                if (input == "se")
                {
                    Show();
                }
            }
            else
            {
                validID = EventRepo.Remove(id);
                if (validID)
                {
                    Console.WriteLine("\nAktivitet er fjernet");
                }
                else
                {
                    Console.WriteLine("\nId'et er ikke valid");
                }
            }
        }
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
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            FormattingService.RemoveSpaces(ref input);

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
        string? dateS = "";
        string? startTimeS = "";
        string? endTimeS = "";

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
            Console.WriteLine(PersonRepo.AllToString());
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