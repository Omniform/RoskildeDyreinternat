using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public static class MedicalLogRepo 
    {
        public static List<MedicalLog> medicalLogs = new List<MedicalLog>();
        public static void Add(string description, DateTime dateTime, Animal animal, string nameOfDoctor)
        {
            medicalLogs.Add(new(description, dateTime, animal, nameOfDoctor));
        }
        public static string AllToString()
        {
            string s = "";
            foreach (MedicalLog medicalLog in medicalLogs) { s += medicalLog.ToString() + "\n"; }
            return s + "\n";
        }
    }
}
