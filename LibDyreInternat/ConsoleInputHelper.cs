using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using LibDyreInternat;

public static class ConsoleInputHelper
{
//Metoder der flytter logikken fra animal even handler til denne klasse for nemmere readblity i animal event handler, samt samler alle konsol indput handeling i en klasse
    public static int ReadIntFromConsole(string prompt)
    {
        int result;
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (int.TryParse(input, out result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Ugyldigt input. Indtast venligst et gyldigt heltal.");
            }
        }
    }

    public static string ReadStringFromConsole(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(input) && input.Length >= 2)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ugyldigt skal være mindst 2 tegn og ikke tomt.");
            }
        }
    }

    public static Sex ReadSexFromConsole()
    {
        while (true)
        {
            Console.WriteLine("\nIndtast køn: Han, Hun, Tvekønnet");
            string sexInput = Console.ReadLine().ToLower().Trim();

            try
            {
                switch (sexInput)
                {
                    case "han":
                        return Sex.male;
                    case "hun":
                        return Sex.female;

                    case "tvekønnet":
                        return Sex.hermaphrodite;
                    default:
                        throw new ArgumentException($"Unknown sex value: {sexInput}");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Ugyldigt input. Prøv igen\n");
            }
        }
    }

    public static bool ReadBoolFromConosle(string prompt)
    {
        Console.WriteLine(prompt);
        string isChildFriendly = Console.ReadLine().ToLower().Trim(); ;

        
        if (isChildFriendly == "ja")
        {
                return true;
        }
        else
        {
                return false;
        }
    }

}