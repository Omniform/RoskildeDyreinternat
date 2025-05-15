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

        public static void AddCat(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex)
        {
            animalRepo.Add(new Cat(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, sex));
        }

        public static void AddFish(string species, string maintainence, string name, int birthYear, int weight, Sex sex)
        {
            animalRepo.Add(new Fish(species, maintainence, name, birthYear, weight, sex));
        }

        public static Animal GetAnimalById(int Id)
        {
            string s = "";
            Animal animal1 = null;
            foreach (Animal animal in animalRepo)
            {
                if (animal.Id == Id)
                {
                    s = animal.ToString();
                    animal1 = animal;
                   
                }
            }
            return animal1;

            //return $"{s}";
        }

        private static void RemoveAnimal(int Id)
        {
            foreach (Animal animal in animalRepo)
            {
                if (true)
                {

                }
            }


        }

        public static string AllToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo) { s += animal.ToString() + "\n"; }
            return s + "\n";
        }


    
    }
}
