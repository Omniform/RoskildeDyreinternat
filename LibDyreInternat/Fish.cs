using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class Fish : Animal
    {
        public string Species { get; set; }
        public string Maintainence { get; set; }


        public Fish(string species, string maintainence, string name, int birthYear, int weight, Sex sex, bool isUpForAdoption) : base (name, birthYear, weight, sex, isUpForAdoption)
        {
            Species = species;
            Maintainence = maintainence;
        }

        public override string ToString()
        {
            string sex = "";
            switch (Sex)
            {
                case Sex.male:
                    sex = "Han";
                    break;
                case Sex.female:
                    sex = "Hun";
                    break;
                case Sex.hermaphrodite:
                    sex = "Tvekønnet";
                    break;
            }
            return $"ID: {Id}\nNavn: {Name}\nFødselsår: {BirthYear}\nWeight: {Weight}Kg\nKøn: {sex}\nArt: {Species}\nVedligeholdelse: {Maintainence}\nMulighed for adoption: {((IsUpForAdoption)? "Ja" : "Nej")}";
        }

    }
}
