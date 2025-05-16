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