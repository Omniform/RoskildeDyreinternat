namespace LibDyreInternat
{    
    public static class FormattingService
    {
        public static void RemoveSpaces(ref string s)
        {
            if (s.StartsWith(' ') || s.EndsWith(' '))
            {
                int i = 0;
                int y = s.Length - 1;

                while (i < s.Length)
                {
                    if (s.ElementAt(i) != ' ')
                    {
                        break;
                    }
                    i++;
                }


                while (y > -1)
                {
                    if (s.ElementAt(y) != ' ')
                    {
                        break;
                    }
                    y--;
                }
                y = s.Length - (y + 1);
                s = s.Substring(i, s.Length - i - y);
            }
        }
    }
}