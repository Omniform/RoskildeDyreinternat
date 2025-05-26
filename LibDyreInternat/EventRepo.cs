namespace LibDyreInternat
{
    public static class EventRepo
    {
        public static List<Event> AllEvents { get; private set; } = new List<Event>();
        private static List<Event> filteredEvents = new List<Event>();

        public static void Add(Event activity)
        {
            AllEvents.Add(activity);
        }

        public static void Add(in string name, in DateOnly date, in TimeOnly startTime, in TimeOnly endTime, in Person coordinator)
        {
            AllEvents.Add(new Event(name, date, startTime, endTime, coordinator));
        }

        public static bool Remove(int id)
        {
            for (int i = 0; i < AllEvents.Count; i++)
            {
                if (AllEvents.ElementAt(i).Id == id)
                {
                    AllEvents.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static Event? GetById(int id)
        {
            foreach (Event activity in AllEvents)
            {
                if (activity.Id == id)
                {
                    return activity;
                }
            }
            return null;
        }
        
        public static string ReturnListAsString()
        {
            string s = "";

            foreach (Event activity in AllEvents)
            {
                s += activity.ToString() + "\n";
            }
            return s;
        }

        // Takes all events and members in the event and returns it as a string
        public static string ReturnListWithMembersAsString()
        {
            string s = "";
            string memberS = "";
            Person? person = null;

            for (int i = 0; i < AllEvents.Count; i++)
            {
                for (int y = 0; y < AllEvents.ElementAt(i).Members.Count; y++)
                {
                    // Gets the member in the event list
                    person = AllEvents.ElementAt(i).Members.ElementAt(y);
                    memberS += $"\n\nMedlem: {AllEvents.ElementAt(i).Id}\nId: {person.Id}\nNavn: {person.Name}\nEmail: {person.Email}";
                }
                s += AllEvents.ElementAt(i).ToString() + memberS;
            }
            return s;
        }

        // Adds event to (filteredEvents) if event name contains parameter
        public static List<Event> FilterEventsByName(string name)
        {
            foreach (Event activity in AllEvents)
            {
                if (activity.Name.ToLower().Contains(name.ToLower()))
                {
                    filteredEvents.Add(activity);
                }
            }
            return filteredEvents;
        }
    }
}