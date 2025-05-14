using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LibDyreInternat
{
    public static class AnimalRepo
    {
        public static List<Animal> animalRepo = new List<Animal>();
        public static void AddDog(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex)
        {
            animalRepo.Add(new Dog(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, sex));
        }

        public static string AllToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo) { s += animalRepo.ToString() + "\n"; }
            return s + "\n";
        }

    }
}
