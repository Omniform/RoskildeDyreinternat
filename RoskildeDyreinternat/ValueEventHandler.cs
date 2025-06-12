using LibDyreInternat;
using RoskildeDyreinternat;

public static class ValueEventHandler
{

    private static bool m_eventSuccess = false;


    public static void ValueAnimal(string key)
    {
        switch (key)
        {
            case "se":
                AnimalEventHandler.Show();
                break;
            case "tilfoj":
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
                MedicalLogEventHandler.Show();
                break;
            case "tilfoj":
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

			case "tilfoj":
				PersonEventHandler.Add();
                break;

			case "fjern":
                PersonEventHandler.Remove();
				break;

			case "ændr":
                PersonEventHandler.Update();
				break;
		}
	}

	public static void ValueEvent(in string key)
	{
        switch (key)
        {
            case "se":
                EventEventHandler.Show();
                break;
            case "semedmedlem":
                EventEventHandler.ShowWithMembers();
                break;
            case "tilfoj":
                EventEventHandler.Add();
                break;
            case "fjern":
                EventEventHandler.Remove();
                break;
            case "ændr":
                EventEventHandler.Update();
                break;
            case "tilfojmedlem":
                EventEventHandler.AddMember();
                break;
            case "fjernmedlem":
				EventEventHandler.RemoveMember();
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

			case "tilfoj":
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
    public static void ValueBooking(string key)
    {
        switch (key)
        {
            case "se":
                BookingEventHandler.Show();
                break;

            case "tilfoj":
                BookingEventHandler.Add();
                break;

            case "fjern":
                BookingEventHandler.Remove();
                break;

            case "ændr":
                BookingEventHandler.Update();
                break;
        }
    }
}
 