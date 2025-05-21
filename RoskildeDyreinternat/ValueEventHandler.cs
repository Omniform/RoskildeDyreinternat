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
				EventEventHandler.Show();
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
 