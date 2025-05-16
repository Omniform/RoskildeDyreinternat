using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class MedicalLog
    {
        private static int idNext = 1;
        public int ID {  get; private set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public Animal Animal { get; set; }
        public string NameOfDoctor { get; set; }
        public MedicalLog(string description, DateTime dateTime, Animal animal, string nameOfDoctor) 
        {
            ID = idNext++;
            Description = description;
            DateTime = dateTime;
            Animal = animal;
            NameOfDoctor = nameOfDoctor;

        }
        public override string ToString()
        {
            return $"ID: {ID}\nHvem: {Animal.Name}\nDato: {DateTime.Date}, tidspunkt: {DateTime.Hour}.{DateTime.Minute}\nDyrlæge: {NameOfDoctor}\nBeskrivelse: {Description}\n";
        }
    }
}
