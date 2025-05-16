using Library;
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
        public static void Remove(MedicalLog medicalLog)
        {
            medicalLogs.Remove(medicalLog);
        }
        public static MedicalLog? GetById(int id)
        {
            MedicalLog? medicalLog = null;
            foreach (MedicalLog mLog in medicalLogs)
            {
                if (mLog.ID == id) medicalLog = mLog;
            }
            if (medicalLog == null)
            {
                string msg = $"Din søgning gav ingen resultater. Vi fandt ingen lægelogs med det angivne ID";
                throw new NoSearhResultException(msg);
            }
            return medicalLog;
        }
        public static void Update(MedicalLog medicalLog, string infoToChange, string change)
        {
            switch (infoToChange.ToLower())
            {
                case "beskrivelse":
                    medicalLog.Description = change;
                    break;
                case "dyr":
                    medicalLog.Animal = AnimalRepo.GetById(int.Parse(change));
                    break;
                case "dato":
                    medicalLog.DateTime = DateTime.Parse(change);
                    break;
                case "læge":
                    medicalLog.NameOfDoctor = change;
                    break;
                default:
                    break;
            }
        }
        public static string AllToString()
        {
            string s = "";
            foreach (MedicalLog medicalLog in medicalLogs) { s += medicalLog.ToString() + "\n"; }
            return s + "\n";
        }
    }
}
