using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public class Dog : Animal
    {
        public string Race { get; set; }
        public bool IsChildFriendly { get; set; }
        public string FoodPrefrences { get; set; }
        public int ChipNumber { get; set; }

        public Dog(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex, bool isUpForAdoption) : base(name, birthYear, weight, sex, isUpForAdoption)
        {
            Race = race;
            IsChildFriendly = isChildFriendly;
            FoodPrefrences = foodPrefrences;
            ChipNumber = chipNumber;
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
            return $"ID: {Id}\nNavn: {Name}\nFødselsår: {BirthYear}\nWeight: {Weight}Kg\nKøn: {sex}\nRace: {Race}\nBørnevenlig: {((IsChildFriendly)? "Ja":"Nej")}\nMulighed for adoption: {((IsUpForAdoption)? "Ja" : "Nej")}\nFoder: {FoodPrefrences}\nChipnummer: {ChipNumber}\n";
        }

    }
}
