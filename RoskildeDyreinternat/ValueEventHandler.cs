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
	Console.WriteLine("Hvad vil du ændre");
	string input = Console.ReadLine();

		switch (input)
		{
			
		}
	}
}
 