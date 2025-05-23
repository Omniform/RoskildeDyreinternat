using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public static class InputValidation
    {
        public static bool TryParseInt(string input, out int result, out string errorMessage)
        {
            result = 0;
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Input må ikke være tomt.";
                return false;
            }

            if (!int.TryParse(input, out result))
            {
                errorMessage = "Ikke Gyldigt";
                return false;
            }
            return true;
        }

        public static bool TryParseString(string input, out string result, out string errorMessage)
        {
            result = "";
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input) || input.Length <= 2)
            {
                errorMessage = "Ugyldigt input. Prøv igen";
                return false;
            }
            else
            {
                result = input.Trim();
                return true;
            }
        }

        public static bool TryParseSex(string input, out Sex sex, out string errorMessage)
        {
            sex = default;
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Input må ikke være tomt.";
                return false;
            }

            switch (input.ToLower().Trim())
            {
                case "han":
                    sex = Sex.male;
                    return true;
                case "hun":
                    sex = Sex.female;
                    return true;
                case "tvekønnet":
                    sex = Sex.hermaphrodite;
                    return true;
                default:
                    errorMessage = "Ugyldigt input. Indtast Han, Hun, eller Tvekønnet.";
                    return false;
            }
        }

        public static bool TryParseBool(string input, out bool result, out string errorMessage)
        {
            result = false;
            errorMessage = "";
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Input må ikke være tomt.";
                return false;
            }
            if (input.ToLower() == "ja")
            {
                result = true;
                return true;
            }
            else if (input.ToLower() == "nej")
            {
                result = false;
                return true;
            }
            else
            {
                errorMessage = "Ugyldigt input. Indtast Ja eller Nej.";
                return false;
            }
        }

        public static bool TryParseDateTime(string input, out DateTime result, out string errorMessage)
        {
            result = new DateTime();
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Input må ikke være tomt.";
                return false;
            }

            if (!DateTime.TryParse(input, out result))
            {
                errorMessage = "Ikke Gyldigt";
                return false;
            }
            return true;
        }

        public static bool TryParseDateOnly(string input, out DateOnly result, out string errorMessage)
        {
            result = new DateOnly();
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Input må ikke være tomt.";
                return false;
            }

            if (!DateOnly.TryParse(input, out result))
            {
                errorMessage = "Ikke Gyldigt";
                return false;
            }
            return true;
        }
        public static bool TryParseTimeOnly(string input, out TimeOnly result, out string errorMessage)
        {
            result = new TimeOnly();
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Input må ikke være tomt.";
                return false;
            }

            if (!TimeOnly.TryParse(input, out result))
            {
                errorMessage = "Ikke Gyldigt";
                return false;
            }
            return true;
        }
    }
}
