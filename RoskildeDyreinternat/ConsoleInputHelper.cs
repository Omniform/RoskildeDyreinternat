using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using System.Transactions;
using LibDyreInternat;

public static class ConsoleInputHelper
{
//Metoder der flytter logikken fra animal even handler til denne klasse for nemmere readblity i animal event handler, samt samler alle konsol indput handeling i en klasse
    public static int ReadIntFromConsole(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (InputValidation.TryParseInt(input, out int result, out string errorMessage))
            {
                return result;
            }
            else Console.WriteLine(errorMessage);
        }
    }

    public static string ReadStringFromConsole(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (InputValidation.TryParseString(input, out string result, out string errorMessage))
            {
                return result;
            }
            else Console.WriteLine(errorMessage);
        }
    }
    public static Sex ReadSexFromConsole()
    {
        while (true)
        {
            Console.WriteLine("\nIndtast køn: Han, Hun, Tvekønnet");
            string sexInput = Console.ReadLine();

            if (InputValidation.TryParseSex(sexInput, out Sex sex, out string errorMessage))
            {
                return sex;
            }
            else Console.WriteLine(errorMessage);
            
        }
    }

    public static bool ReadBoolFromConsole(string prompt)
    {
        while (true)
        {

            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (InputValidation.TryParseBool(input, out bool result, out string errormessage))
            {
                return result;
            }
            else Console.WriteLine(errormessage);
        }


    }
    public static DateTime ReadDateTimeFromConsole(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (InputValidation.TryParseDateTime(input, out DateTime result, out string errorMessage))
            {
                return result;
            }
            else Console.WriteLine(errorMessage);
        }
    }

    public static DateOnly ReadDateFromConsole(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (InputValidation.TryParseDateOnly(input, out DateOnly result, out string errorMessage))
            {
                return result;
            }
            else Console.WriteLine(errorMessage);
        }
    }
    public static TimeOnly ReadTimeFromConsole(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();

            if (InputValidation.TryParseTimeOnly(input, out TimeOnly result, out string errorMessage))
            {
                return result;
            }
            else Console.WriteLine(errorMessage);
        }
    }
}