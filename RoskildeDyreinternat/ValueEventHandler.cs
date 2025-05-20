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
        string animal = "";
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
				m_eventSuccess = true;
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

	private static void ShowEvent()
	{
		Console.WriteLine(EventRepo.ReturnListAsString());
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
 