namespace LibDyreInternat
{
    public static class EventRepo
    {
        public static List<Event> AllActivities { get; private set; } = new List<Event>();
        private static List<Event> filteredActivities = new List<Event>();

        public static void Add(Event activity)
        {
            AllActivities.Add(activity);
        }

        public static bool Remove(int id)
        {
            for (int i = 0; i < AllActivities.Count; i++)
            {
                if (AllActivities.ElementAt(i).Id == id)
                {
                    AllActivities.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static Event? GetById(int id)
        {
            foreach (Event activity in AllActivities)
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

            foreach (Event activity in AllActivities)
            {
                s += activity.ToString() + "\n";
            }
            return s;
        }

        public static string ReturnListWithMembersAsString()
        {
            string s = "";
            string memberS = "";
            Person? person = null;

            for (int i = 0; i < AllActivities.Count; i++)
            {
                // person = AllActivities.ElementAt(i).Members.ElementAt(i);
                // if (person != null)
                // {
                //     s += $"{AllActivities.ElementAt(i)}\n{AllActivities.ElementAt(i).Members.ElementAt(i).Id}"
                // }
                for (int y = 0; y < AllActivities.ElementAt(i).Members.Count; y++)
                {
                    person = AllActivities.ElementAt(i).Members.ElementAt(y);
                    memberS += $"\n\nMedlem: {AllActivities.ElementAt(i).Id}\nId: {person.Id}\nNavn: {person.Name}\nEmail: {person.Email}";
                }
                s += AllActivities.ElementAt(i).ToString() + memberS;
            }
            // foreach (Event activity in AllActivities)
                // {
                //     s += $"{activity}\n{activity.Members}";
                // }
                return s;
        }

        public static List<Event> FilterActivitiesByName(string name)
        {
            foreach (Event activity in AllActivities)
            {
                if (activity.Name.ToLower().Contains(name.ToLower()))
                {
                    filteredActivities.Add(activity);
                }
            }
            return filteredActivities;
        }
    }
}