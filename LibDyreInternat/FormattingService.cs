namespace LibDyreInternat
{    
    public static class FormattingService
    {
        public static void RemoveSpacesRef(ref string s)
        {
            if (s.StartsWith(' '))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.ElementAt(i) != ' ')
                    {
                        s = s[i..];
                        break;
                    }
                }
            }

            if (s.EndsWith(' '))
            {
                for (int i = s.Length - 1; i > -1; i--)
                {
                    if (s.ElementAt(i) != ' ')
                    {
                        s = s[..(i + 1)];
                        break;
                    }
                }
            }
        }

        public static string RemoveSpaces(string s)
        {
            if (s.StartsWith(' '))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.ElementAt(i) != ' ')
                    {
                        s = s[i..];
                        break;
                    }
                }
            }

            if (s.EndsWith(' '))
            {
                for (int i = s.Length - 1; i > -1; i--)
                {
                    if (s.ElementAt(i) != ' ')
                    {
                        s = s[..(i + 1)];
                        break;
                    }
                }
            }

            return s;
        }
    }
}