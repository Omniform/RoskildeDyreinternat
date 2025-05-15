namespace LibDyreInternat
{
    public static class ActivityRepo
    {
        public static List<Activity> AllActivities { get; private set; } = new List<Activity>();
        private static List<Activity> filteredActivities = new List<Activity>();

        public static void Add(Activity activity)
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

        public static Activity? GetById(int id)
        {
            foreach (Activity activity in AllActivities)
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

            foreach (Activity activity in AllActivities)
            {
                s += activity.ToString() + "\n";
            }
            return s;
        }

        public static List<Activity> FilterActivitiesByName(string name)
        {
            foreach (Activity activity in AllActivities)
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